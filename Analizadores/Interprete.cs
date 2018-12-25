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
        private static LinkedList<Background> lista_background = new LinkedList<Background>();
        private static LinkedList<Figure> lista_figure = new LinkedList<Figure>();
        private static LinkedList<Design> lista_design = new LinkedList<Design>();

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
                    obtener_datos_backgroud(raiz);
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
            foreach(var item in raiz.ChildNodes)
            {
                switch (item.Term.Name)
                {

                    case "NAME":
                        nombre = item.ChildNodes[2].Token.Text;
                        break;
                    case "SOURCE":
                        ruta = item.ChildNodes[2].Token.Text;
                        break;
                    case "DESTRUCTION":
                        danio = evaluar_expresion(item.ChildNodes[2]);
                        break;
                    case "DESIGNTYPE":
                        tipo = item.ChildNodes[2].Token.Text;
                        break;
                    case "POINTS":
                        puntos = evaluar_expresion(item.ChildNodes[2]);
                        break;
                }
            }

            Design diseno = new Design(nombre, ruta, tipo, danio, puntos);
            lista_design.AddLast(diseno);


        }

        private static void obtener_datos_figure(ParseTreeNode raiz)
        {
            String nombre = "";
            String ruta = "";
            double vida = 0;
            double danio = 0;
            String tipo = "";
            String descripcion = "";
            foreach(var item in raiz.ChildNodes)
            {
                switch(item.Term.Name)
                {
                    case "NAME":
                        nombre=item.ChildNodes[2].Token.Text;
                        break;
                    case "SOURCE":
                        ruta = item.ChildNodes[2].Token.Text;
                        break;
                    case "LIFE":
                        //VALIDAR EXP
                       vida = evaluar_expresion(item.ChildNodes[2]);

                        break;
                    case "FIGURETYPE":
                        tipo = item.ChildNodes[2].Token.Text;
                        break;
                    case "DESCRIPTION":
                        descripcion = item.ChildNodes[2].Token.Text;
                        break;
                    case "DESTRUCTION":
                        danio = evaluar_expresion(item.ChildNodes[2]);
                        break;
                }
            }

            Figure figura = new Figure(nombre,ruta, vida, tipo, descripcion);
            lista_figure.AddLast(figura);

        }

        private static double evaluar_expresion(ParseTreeNode raiz)
        {
                switch (raiz.ChildNodes.Count)
            {
                case 3:
                    switch (raiz.ChildNodes[1].Token.Text)
                    {
                        case "+":
                            double val1 = evaluar_expresion(raiz.ChildNodes[0]);
                            double val2 = evaluar_expresion(raiz.ChildNodes[2]);
                           
                            if (val1 == -200517803 || val2 == -200517803)
                            {
                                return -200517803;
                            }
                            else
                            {
                                return val1 + val2;
                            }


                        case"-":
                            double resta1 = evaluar_expresion(raiz.ChildNodes[0]);
                            double resta2 = evaluar_expresion(raiz.ChildNodes[2]);
                            if(resta1==-200517803 || resta2==-200517803)
                            {
                                return -200517803;
                            }
                            else
                            {
                                return resta1 - resta2;
                            }
                            
                        case "/":
                            double div1 = evaluar_expresion(raiz.ChildNodes[0]);
                            double div2 = evaluar_expresion(raiz.ChildNodes[2]);
                            if(div2==0)
                            {
                                int linea = raiz.ChildNodes[2].Span.Location.Line;
                                int columna = raiz.ChildNodes[2].Span.Location.Column;
                                Error error = new Error("Semantico", "No se puede dividir por 0", linea, columna);
                                Form1.LErrores.Add(error);
                                return -200517803;
                            }
                            else
                            {
                                return div1 / div2;
                            }
                            
                        case "*":
                            double multi1 = evaluar_expresion(raiz.ChildNodes[0]);
                            double multi2 = evaluar_expresion(raiz.ChildNodes[2]);
                            if (multi1 == -200517803 || multi2 == -200517803)
                            {
                                return -200517803;
                            }
                            else
                            {
                                return multi1 * multi2;
                            }

                            

                            

                    }
                    break;
                case 2:
                    if (evaluar_expresion(raiz.ChildNodes[0]) == -200517803)
                    {
                        return -2005178003;
                    }else
                    {
                        return evaluar_expresion(raiz.ChildNodes[1]) * - 1;
                    }
                    
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

            foreach (var item in raiz.ChildNodes)
            {
                switch (item.Term.Name)
                {
                    case "NAME":
                        nombre = item.ChildNodes[2].Token.Text;
                        break;
                    case "SOURCE":
                        ruta = item.ChildNodes[2].Token.Text;
                        break;
                    default:
                        break;
                        //AGREGAR ERROR

                }

            }

            Background back = new Background(nombre, ruta);
            lista_background.AddLast(back);
        }

        public void RecorrerListas()
        {
            LinkedListNode<Background> back = lista_background.First;
            LinkedListNode<Figure> figure = lista_figure.First;
            LinkedListNode<Design> design = lista_design.First;
            Console.WriteLine("***BACKGROUND***");
            while(back!=null)
            {
                Console.WriteLine("Nombre: "+ back.Value.nombre);
                Console.WriteLine("Ruta: " + back.Value.ruta);

                back = back.Next;
            }

            Console.WriteLine(" ");
            Console.WriteLine("**FIGURE**");
            while(figure!=null)
            {
                Console.WriteLine("Nombre: "+figure.Value.nombre);
                Console.WriteLine("Ruta: "+figure.Value.ruta);
                Console.WriteLine("Vida: "+figure.Value.vida);
                Console.WriteLine("Tipo: "+figure.Value.tipo);
                Console.WriteLine("Descripcion: "+figure.Value.descripcion);

                figure = figure.Next;
            }

            Console.WriteLine(" ");
            Console.WriteLine("**DESIGN**");

            while(design!=null)
            {
                Console.WriteLine("Nombre: " + design.Value.nombre);
                Console.WriteLine("Ruta: " + design.Value.ruta);
                Console.WriteLine("Tipo: " + design.Value.tipo);
                Console.WriteLine("Danio: " + design.Value.danio);
                Console.WriteLine("Puntos: " + design.Value.puntos);

                design = design.Next;
            }
        }
    }
}
