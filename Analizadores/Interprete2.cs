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
                //recorrer(arbol.Root);
                //r.GraficarFlujo();
                //Ejecucion.Ejecutor ejecutor = new Ejecucion.Ejecutor();
                //ejecutor.ejecutarAST(arbol.Root);
                // ya tenes lo de consola
                //Form1 form = new Form1();
                //String consola = ejecutor.salida.ToString();
                return true;
            }
        }
    }
}
