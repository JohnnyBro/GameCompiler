using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;
using System.Windows.Forms;
using GameCompiler.Graficadores;
using GameCompiler.Datos;

namespace GameCompiler.Analizadores

    
{

     
    public class Interprete: Grammar
    {
        //private static LinkedList<Background> lista_background = new LinkedList<Background>();
        //private static LinkedList<Figure> lista_figure = new LinkedList<Figure>();
        //private static LinkedList<Design> lista_design = new LinkedList<Design>();

        public static bool analizar1(String entrada)
        {
            Gramatica1 gramatica = new Gramatica1();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(entrada);
            ParseTreeNode raiz = arbol.Root;

            if (arbol.Root == null)
            {
                Analizadores.Error error;

                for (int i = 0; i < arbol.ParserMessages.Count(); i++)
                {
                    String tipo;
                    String mensaje = arbol.ParserMessages.ElementAt(i).Message;
                    int line = arbol.ParserMessages.ElementAt(i).Location.Line; ;
                    int column = arbol.ParserMessages.ElementAt(i).Location.Column;

                    if (arbol.ParserMessages.ElementAt(i).Message.Contains("Invalid"))
                    {
                        tipo = "Lexico";
                        error = new Error(tipo, mensaje, line, column);
                        Form1.LErrores.Add(error);
                    }
                    else
                    {
                        tipo = "Sintactico";
                        error = new Error(tipo, mensaje, line, column);
                        Form1.LErrores.Add(error);
                    }
                }
                return false;
            }
            else
            {
                Analizadores.Error error;
                for (int i = 0; i < arbol.ParserMessages.Count(); i++)
                {
                    String tipo;
                    String mensaje = arbol.ParserMessages.ElementAt(i).Message;
                    int line = arbol.ParserMessages.ElementAt(i).Location.Line; ;
                    int column = arbol.ParserMessages.ElementAt(i).Location.Column; ;
                    if (arbol.ParserMessages.ElementAt(i).Message.Contains("Invalid"))
                    {
                        tipo = "Lexico";
                        error = new Error(tipo, mensaje, line, column);
                        Form1.LErrores.Add(error);
                       
                    }
                    else
                    {
                        tipo = "Sintactico";
                        error = new Error(tipo, mensaje, line, column);
                        Form1.LErrores.Add(error);
                    }
                }
                Graficador r = new Graficador();
                r.graficar(arbol);
                recorrer(arbol.Root);
                //r.GraficarFlujo();
                //Ejecucion.Ejecutor ejecutor = new Ejecucion.Ejecutor();
                //ejecutor.ejecutarAST(arbol.Root);
                // ya tenes lo de consola
                //Form1 form = new Form1();
                //String consola = ejecutor.salida.ToString();
                return true;
            }
        }
        private static void recorrer(ParseTreeNode raiz)
        {


            switch (raiz.Term.Name)
            {
                case "START":
                    recorrer(raiz.ChildNodes[0]);
                    break;
                case "BODIES":
                    foreach (var item in raiz.ChildNodes)
                        recorrer(item);
                    break;
                case "BACKGROUNDS":
                    foreach (var item in raiz.ChildNodes)
                        recorrer(item);
                    break;
                case "BODIESBACKGROUND":
                    if(raiz.ChildNodes.Count==2)
                    {
                        obtener_datos_backgroud(raiz);
                    }
                    else
                    {
                        Analizadores.Error error = new Error("Sintactico", "Syntax error, expected: x-nombre, x-imagen", raiz.Span.Location.Line, raiz.Span.Location.Column);
                        Form1.LErrores.Add(error);
                    }
                    break;
                case "FIGURES":
                    foreach (var item in raiz.ChildNodes)
                        recorrer(item);
                    break;
                case "FIGUREBODIES":
                    obtener_datos_figure(raiz);
                    break;
                case "DESIGNS":
                    foreach (var item in raiz.ChildNodes)
                        recorrer(item);
                    break;
                case "DESIGNBODIES":
                    obtener_datos_design(raiz);
                    break;
                     

            }
        }

        private static void obtener_datos_design(ParseTreeNode raiz)
        {
            String nombre = "";
            String ruta = "";
            String tipo = "";
            double danio = 0;
            double puntos = 0;
            Analizadores.Error error;

            foreach(var item in raiz.ChildNodes)
            {
                switch (item.Term.Name)
                {

                    case "NAME":
                        try
                        {
                            nombre = item.ChildNodes[2].Token.Text;
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        break;
                    case "SOURCE":
                        try
                        {
                            ruta = item.ChildNodes[2].Token.Text;
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        break;
                    case "DESTRUCTION":
                        try
                        {
                            danio = evaluar_expresion(item.ChildNodes[2]);
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        break;
                    case "DESIGNTYPE":
                        try
                        {
                            tipo = item.ChildNodes[2].Token.Text;
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        break;
                    case "POINTS":
                        try
                        {
                            puntos = evaluar_expresion(item.ChildNodes[2]);
                            if (puntos < 0)
                            {
                                error = new Error("Semantico", "Semantic error, NO se acepta un valor final negativo ", item.Span.Location.Line, item.Span.Location.Column);
                                Form1.LErrores.Add(error);
                            }
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        break;
                    default:
                        error = new Error("Sintactico", "Syntax error, expected: x-nombre, x-imagen, x-tipo, x-destruir, x-creditos", item.Span.Location.Line, item.Span.Location.Column);
                        Form1.LErrores.Add(error);
                        break;
                }
            }
            if (nombre == "" || ruta == "" || tipo == "")
            {
                error = new Error("Sintactico", "Syntax error, expected: x-nombre, x-imagen, x-tipo ", raiz.Span.Location.Line, raiz.Span.Location.Column);
                Form1.LErrores.Add(error);
                return;
            }

            if(tipo=="x-bonus")
            {
                if(puntos==0)
                {
                    error = new Error("Sintactico", "Syntax error, expected: x-creditos dentro de " + tipo, raiz.Span.Location.Line, raiz.Span.Location.Column);
                    Form1.LErrores.Add(error);
                    return;
                }
                if(danio!=0)
                {
                    error = new Error("Semantico", "Semantic error, no se puede declarar x-destruir dentro de " + tipo, raiz.Span.Location.Line, raiz.Span.Location.Column);
                    Form1.LErrores.Add(error);
                    return;
                }
            }else if(tipo=="x-bomba" || tipo=="x-arma")
            {
                if(danio==0)
                {
                    error = new Error("Sintactico", "Syntax error, expected: x-destruir dentro de" + tipo, raiz.Span.Location.Line, raiz.Span.Location.Column);
                    Form1.LErrores.Add(error);
                    return;
                }
                if(puntos!=0)
                {
                    error = new Error("Semantico", "Semantic error, no se puede declarar x-creditos dentro de " + tipo, raiz.Span.Location.Line, raiz.Span.Location.Column);
                    Form1.LErrores.Add(error);
                    return;
                }
            }else if(tipo=="x-bloque" || tipo=="x-meta")
            {
                if(danio!=0 || puntos!=0)
                {
                    error = new Error("Semantico", "Semantic error, no se puede declarar x-creditos, x-destruir dentro de " + tipo, raiz.Span.Location.Line, raiz.Span.Location.Column);
                    Form1.LErrores.Add(error);
                    return;
                }
            }

            Design diseno = new Design(nombre, ruta, tipo, danio, puntos);
            Form1.lista_design.AddLast(diseno);
            


        }

        private static void obtener_datos_figure(ParseTreeNode raiz)
        {
            String nombre = "";
            String ruta = "";
            double vida = 100;
            double danio = 0;
            String tipo = "";
            String descripcion = "";
            Analizadores.Error error;
            int linea=0;
            int columna = 0;

            foreach(var item in raiz.ChildNodes)
            {

                switch(item.Term.Name)
                {
                    case "NAME":
                        try
                        {
                            nombre = item.ChildNodes[2].Token.Text;
                        }
                        catch (Exception)
                        {
                            
                            return;
                        }
                        
                        break;
                    case "SOURCE":
                        try
                        {
                            ruta = item.ChildNodes[2].Token.Text;
                        }
                        catch (Exception)
                        {
                            
                            return;
                        }   
                        break;
                    case "LIFE":
                        try
                        {
                            //VALIDAR EXP
                            vida = evaluar_expresion(item.ChildNodes[2]);
                            if(vida<0)
                            {
                                error = new Error("Semantico", "Semantic error, NO se acepta un valor final negativo ", item.Span.Location.Line, item.Span.Location.Column);
                                Form1.LErrores.Add(error);
                                return;
                            }
                        }
                        catch (Exception)
                        {

                            return;
                        }
                        break;
                    case "FIGURETYPE":
                        try
                        {
                            tipo = item.ChildNodes[2].Token.Text;
                        }
                        catch (Exception)
                        {

                            return;
                        }
                        break;
                    case "DESCRIPTION":
                        try
                        {
                            descripcion = item.ChildNodes[2].Token.Text;
                        }
                        catch (Exception)
                        {

                            return;
                        }
                        break;
                    case "DESTRUCTION":
                        try
                        {
                            linea = item.Span.Location.Line;
                            columna = item.Span.Location.Column;
                            danio = evaluar_expresion(item.ChildNodes[2]);
                            if (danio < 0)
                            {
                                error = new Error("Semantico", "Semantic error, NO se acepta un valor final negativo ", item.Span.Location.Line, item.Span.Location.Column);
                                Form1.LErrores.Add(error);
                                return;
                            }
                        }
                        catch (Exception)
                        {

                            return;
                        }
                        break;
                    default:
                        error = new Error("Sintactico", "Syntax error, expected: x-nombre, x-imagen, x-tipo,", item.Span.Location.Line, item.Span.Location.Column);
                        Form1.LErrores.Add(error);
                        break;
                }
            }

            if(tipo=="x-heroe")
            {
                if (danio != 0)
                {
                    error = new Error("Semantico", "Semantic error, no se puede declarar x-destruir dentro de un heroe.", linea, columna);
                    Form1.LErrores.Add(error);
                    return;
                }
                if(descripcion=="")
                {
                    descripcion = "Es el Heroe de la historia, tiene el poder derrotar a sus enemigos..";
                }
               
                
                
            }else if(tipo=="x-enemigo")
            {
                if(danio==0)
                {
                    error = new Error("Sintactico", "Sintax error, expected: x-destruir dentro de un enemigo", raiz.Span.Location.Line, raiz.Span.Location.Column);
                    Form1.LErrores.Add(error);
                    return;
                }

                if(descripcion=="")
                {
                    descripcion = "Hara todo lo posible para destruirte, ten mucho cuidado si lo encuentras..";
                }
                
            }
            if(nombre==""||ruta==""||tipo=="")
            {
                error = new Error("Sintactico", "Syntax error, expected: x-nombre, x-imagen, x-tipo ", raiz.Span.Location.Line, raiz.Span.Location.Column);
                Form1.LErrores.Add(error);
                return;
            }

            Figure figura = new Figure(nombre,ruta, vida, tipo, descripcion);
            Form1.lista_figure.AddLast(figura);

        }

        private static double evaluar_expresion(ParseTreeNode raiz)
        {
            Analizadores.Error error;
                switch (raiz.ChildNodes.Count)
            {
                case 3:
                    switch (raiz.ChildNodes[1].Token.Text)
                    {
                        case "+":
                            double val1 = evaluar_expresion(raiz.ChildNodes[0]);
                            double val2 = evaluar_expresion(raiz.ChildNodes[2]);
                            return val1 + val2;
                            
                        case"-":
                            double resta1 = evaluar_expresion(raiz.ChildNodes[0]);
                            double resta2 = evaluar_expresion(raiz.ChildNodes[2]);
                            return resta1 - resta2;
                        case "/":
                            double div1 = evaluar_expresion(raiz.ChildNodes[0]);
                            double div2 = evaluar_expresion(raiz.ChildNodes[2]);
                            if(div2==0)
                            {
                                error = new Error("Semantico", "Semantic error: No se puede dividirentre cero", raiz.Span.Location.Line, raiz.Span.Location.Column);
                                Form1.LErrores.Add(error);
                                return 0;
                            }
                            else
                            {
                                return (div1/div2);
                            }           
                        case "*":
                            double multi1 = evaluar_expresion(raiz.ChildNodes[0]);
                            double multi2 = evaluar_expresion(raiz.ChildNodes[2]);
                            return multi1 * multi2;
                    }
                    break;
                case 2:
                    return evaluar_expresion(raiz.ChildNodes[1]) * -1;

                case 1:
                    switch (raiz.Term.Name)
                    {
                        case "EXP":
                            return evaluar_expresion(raiz.ChildNodes[0]);
                        case "tokNumero":
                            return Convert.ToDouble(raiz.Token.Text);
                    }
                    break;
                   
                case 0:
                    switch (raiz.Term.Name)
                    {
                        case "EXP":
                            return evaluar_expresion(raiz.ChildNodes[0]);
                        case "tokNumero":
                            return Convert.ToDouble(raiz.Token.Text);
                    }
                    break;

            }
                return -200517803;
        }

        private static void obtener_datos_backgroud(ParseTreeNode raiz)
        {
            String nombre="";
            string ruta = "";
            Analizadores.Error error;
            
            foreach (var item in raiz.ChildNodes)
            {
                switch (item.Term.Name)
                {
                    case "NAME":
                        try
                        {
                            nombre = item.ChildNodes[2].Token.Text;
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        
                        break;
                    case "SOURCE":
                        try
                        {
                            ruta = item.ChildNodes[2].Token.Text;
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        break;
                    default:
                        error = new Error("Sintactico", "Syntax error, expected: x-nombre, x-imagen", item.Span.Location.Line, item.Span.Location.Column);
                        Form1.LErrores.Add(error);
                        break;
                }

            }

            Background back = new Background(nombre, ruta);
            Form1.lista_background.AddLast(back);
        }

        public void RecorrerListas()
        {
            LinkedListNode<Background> back = Form1.lista_background.First;
            LinkedListNode<Figure> figure = Form1.lista_figure.First;
            LinkedListNode<Design> design = Form1.lista_design.First;
            Console.WriteLine("***BACKGROUND***");
            while (back != null)
            {
                Console.WriteLine("\nNombre: " + back.Value.nombre);
                Console.WriteLine("Ruta: " + back.Value.ruta);
                Console.WriteLine("Ancho: " + back.Value.ancho);
                Console.WriteLine("Alto: " + back.Value.alto);
                Console.WriteLine("Utilizado: " + back.Value.seleccionado);
                back = back.Next;
            }

            Console.WriteLine(" ");
            Console.WriteLine("**FIGURE**");
            while (figure != null)
            {
                Console.WriteLine("\nNombre: " + figure.Value.nombre);
                Console.WriteLine("Ruta: " + figure.Value.ruta);
                Console.WriteLine("Vida: " + figure.Value.vida);
                Console.WriteLine("Tipo: " + figure.Value.tipo);
                Console.WriteLine("Descripcion: " + figure.Value.descripcion);
                Console.WriteLine("X: "+figure.Value.x);
                Console.WriteLine("Y: " + figure.Value.y);
                

                figure = figure.Next;
            }

            Console.WriteLine(" ");
            Console.WriteLine("**DESIGN**");

            while (design != null)
            {
                Console.WriteLine("\nNombre: " + design.Value.nombre);
                Console.WriteLine("Ruta: " + design.Value.ruta);
                Console.WriteLine("Tipo: " + design.Value.tipo);
                Console.WriteLine("Danio: " + design.Value.danio);
                Console.WriteLine("Puntos: " + design.Value.puntos);

                Console.WriteLine("Xinicial: " + design.Value.xini);
                Console.WriteLine("Xfinal: " + design.Value.xfin);
                Console.WriteLine("Yinicial: " + design.Value.yini);
                Console.WriteLine("Yfinal: " + design.Value.yfin);
             

                design = design.Next;
            }
        }
    }
}
