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
    class Interprete2 : Grammar
    {

        public static bool analizar2(String entrada)
        {
            Gramatica2 gramatica = new Gramatica2();
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
                Graficador2 r = new Graficador2();
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

        //recorrer el arbol
        private static void recorrer(ParseTreeNode raiz)
        {
            switch(raiz.Term.Name)
            {
                case "INICIO":
                    obtener_datos_inicio(raiz);
                    try
                    {   
                        recorrer(raiz.ChildNodes[9]);
                    }
                    catch (Exception)
                    {
                        
                        return;
                    }  
                    break;
                case "CUERPOS":
                    foreach(var item in raiz.ChildNodes)
                    {
                        recorrer(item);
                    }
                    break;
                case "CPERSONAJES":
                    foreach(var item in raiz.ChildNodes)
                    {
                        recorrer(item);
                    }
                    break;
                case "CPAREDES":
                    foreach(var item in raiz.ChildNodes)
                    {
                        recorrer(item);
                    }
                    break;
                case "CEXTRAS":
                    foreach(var item in raiz.ChildNodes)
                    {
                        recorrer(item);
                    }
                    break;
                case "CMETAS":
                    foreach(var item in raiz.ChildNodes)
                    {
                        recorrer(item);
                    }
                    break;
                case "CHEROES":
                    foreach(var item in raiz.ChildNodes)
                    {
                        recorrer(item);
                    }
                    break;
                case "CHEROE":
                    obtener_datos_heroe(raiz);
                    break;
                case "CVILLANOS":
                    foreach(var item in raiz.ChildNodes)
                    {
                        recorrer(item);
                    }
                    break;
                case "CVILLANO":
                    obtener_datos_villano(raiz);
                    break;
                case "CPARED":
                    obtener_datos_pared(raiz);
                    break;
                case "CARMAS":
                    foreach(var item in raiz.ChildNodes)
                    {
                        recorrer(item);
                    }
                    break;
                case "CARMA":
                    obtener_datos_armas(raiz);
                    break;
                case "CBONUS":
                    foreach(var item in raiz.ChildNodes)
                    {
                        recorrer(item);
                    }
                    break;
                case "CBONU":
                    obtener_datos_bonus(raiz);
                    break;
                case "CMETA":
                    obtener_datos_meta(raiz);
                    break;
                default:
                    break;
            }
        }

        private static void obtener_datos_meta(ParseTreeNode raiz)
        {
            String nombre = "";
            double posx = 0;
            double posy = 0;

            try
            {
                nombre = raiz.ChildNodes[0].Token.Text;
                posx = evaluar_expresion(raiz.ChildNodes[1]);
                posy = evaluar_expresion(raiz.ChildNodes[3]);
            }
            catch (Exception)
            {

                return;
            }

            foreach (var item in Form1.lista_design)
            {
                if (item.nombre == nombre && item.tipo == "x-meta")
                {
                    item.agregarPosiciones(posx, 0, posy, 0);
                }
            }
        }

        private static void obtener_datos_bonus(ParseTreeNode raiz)
        {
            String nombre = "";
            double posx = 0;
            double posy = 0;

            try
            {
                nombre = raiz.ChildNodes[0].Token.Text;
                posx = evaluar_expresion(raiz.ChildNodes[1]);
                posy = evaluar_expresion(raiz.ChildNodes[3]);
            }
            catch (Exception)
            {
                
                return;
            }

            foreach (var item in Form1.lista_design)
            {
                if (item.nombre == nombre && item.tipo == "x-bonus")
                {
                    item.agregarPosiciones(posx, 0, posy, 0);
                }
            }

        }

        private static void obtener_datos_armas(ParseTreeNode raiz)
        {
            String nombre = "";
            double posx = 0;
            double posy = 0;

            try
            {
                nombre = raiz.ChildNodes[0].Token.Text;
                posx = evaluar_expresion(raiz.ChildNodes[1]);
                posy = evaluar_expresion(raiz.ChildNodes[3]);
            }
            catch (Exception)
            {
                
                return;
            }

            foreach(var item in Form1.lista_design)
            {
                if(item.nombre==nombre)
                {
                    if(item.tipo=="x-arma" || item.tipo=="x-bomba")
                    {
                        item.agregarPosiciones(posx, 0, posy, 0);
                    }
                    
                }
            }
        }

        private static void obtener_datos_pared(ParseTreeNode raiz)
        {
            String nombre = "";
            try
            {
                nombre = raiz.ChildNodes[0].Token.Text;
            }
            catch (Exception)
            {
                
                return;
            }
            evaluar_posiciones(raiz.ChildNodes[1], nombre);
            
        }

        private static void evaluar_posiciones(ParseTreeNode raiz, string nombre)
        {
            double xi = 0;
            double xf = 0;
            double yi = 0;
            double yf = 0;
            Error error;

            switch(raiz.ChildNodes.Count)
            {
                case 3:
                    try
                    {
                        if (raiz.ChildNodes[0].ChildNodes.Count == 1)
                        {
                            xi = evaluar_expresion(raiz.ChildNodes[0].ChildNodes[0]);
                        }
                        else if(raiz.ChildNodes[0].ChildNodes.Count==4)
                        {
                            xi = evaluar_expresion(raiz.ChildNodes[0].ChildNodes[0]);
                            xf = evaluar_expresion(raiz.ChildNodes[0].ChildNodes[3]);
                        }

                        if(raiz.ChildNodes[2].ChildNodes.Count==1)
                        {
                            yi = evaluar_expresion(raiz.ChildNodes[2].ChildNodes[0]);
                        }
                        else if(raiz.ChildNodes[2].ChildNodes.Count==4)
                        {
                            yi = evaluar_expresion(raiz.ChildNodes[2].ChildNodes[0]);
                            yf = evaluar_expresion(raiz.ChildNodes[2].ChildNodes[3]);
                        }
                    }
                    catch (Exception)
                    {
                        
                        return;
                    }
                    break;
                default:
                    error = new Error("Sintactico", "Syntax error, expected: tokNumero", raiz.Span.Location.Line, raiz.Span.Location.Column);
                    Form1.LErrores.Add(error);
                    break;
            }
            foreach(var item in Form1.lista_design)
            {
                if(item.nombre==nombre && item.tipo=="x-bloque")
                {
                    item.agregarPosiciones(xi, xf, yi, yf);
                }
            }

        }

        private static void obtener_datos_villano(ParseTreeNode raiz)
        {
            string nombre = "";
            double posx = 0;
            double posy = 0;
            try
            {
                nombre = raiz.ChildNodes[0].Token.Text;
                posx = evaluar_expresion(raiz.ChildNodes[1]);
                posy = evaluar_expresion(raiz.ChildNodes[3]);
            }
            catch (Exception)
            {
                return;
            }

            foreach(var item in Form1.lista_figure)
            {
                if(item.nombre==nombre && item.tipo=="x-enemigo")
                {
                    item.agregar_posiciones(posx, posy);
                }
            }
        }

        private static void obtener_datos_heroe(ParseTreeNode raiz)
        {
            string nombre = "";
            double posx = 0;
            double posy = 0;
            try
            {
                nombre = raiz.ChildNodes[0].Token.Text;
                posx = evaluar_expresion(raiz.ChildNodes[1]);
                posy = evaluar_expresion(raiz.ChildNodes[3]);
            }
            catch (Exception)
            {
                return;
            }

            foreach(var item in Form1.lista_figure)
            {
                if(item.nombre==nombre && item.tipo=="x-heroe")
                {
                    item.agregar_posiciones(posx, posy);
                }
            }

        }

        private static void obtener_datos_inicio(ParseTreeNode raiz)
        {
            String nombreFondo = "";
            double ancho = 0;
            double alto = 0;
            try
            {
                nombreFondo = raiz.ChildNodes[2].Token.Text;
                ancho = evaluar_expresion(raiz.ChildNodes[5]);
                alto = evaluar_expresion(raiz.ChildNodes[8]);
            }
            catch (Exception)
            {
                
                return;
            }

            foreach (var item in Form1.lista_background)
            {
                if (item.nombre == nombreFondo)
                {
                    item.agregarValores(ancho, alto);
                }
            }


            
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

                        case "-":
                            double resta1 = evaluar_expresion(raiz.ChildNodes[0]);
                            double resta2 = evaluar_expresion(raiz.ChildNodes[2]);
                            return resta1 - resta2;
                        case "/":
                            double div1 = evaluar_expresion(raiz.ChildNodes[0]);
                            double div2 = evaluar_expresion(raiz.ChildNodes[2]);
                            if (div2 == 0)
                            {
                                error = new Error("Semantico", "Semantic error: No se puede dividirentre cero", raiz.Span.Location.Line, raiz.Span.Location.Column);
                                Form1.LErrores.Add(error);
                                return 0;
                            }
                            else
                            {
                                return (div1 / div2);
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
    }
}
