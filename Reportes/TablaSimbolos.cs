using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace GameCompiler.Reportes
{
    class TablaSimbolos
    {
        public TablaSimbolos()
        {

        }

        public void ReporteTablaSimbolos()
        {



            //CREANDO ARCHIVO .HTML
            try
            {
                //SE BORRA EL ARCHIVO POR SI EXISTIERA PARA MANTENER LOS ERRORES ACTUALIZADOS

                StreamWriter sw = new StreamWriter("C:\\Users\\JohnnyBravo\\Desktop\\Proyecto1Reportes\\TablaSimbolos\\TSimbolos.html");
                sw.WriteLine("<!DOCTYPE html>");
                sw.WriteLine("<html>");
                sw.WriteLine("\t<head>");
                sw.WriteLine("\t\t<meta charset=\"utf-8\">");
                sw.WriteLine("\t\t<link rel=\"stylesheet\" type=\"text/css\" href=\"TSimbolos.css\"> ");
                sw.WriteLine("\t\t<title>REPORTE DE ERRORES</title>");
                sw.WriteLine("\t</head>");
                sw.WriteLine("\t<body>");
                sw.WriteLine("\t\t<h1>REPORTE TABLA DE SIMBOLOS</h1>");
                sw.WriteLine("\t\t<div id=\"main-container\">");
                sw.WriteLine("\t\t<table class=\"egt\">");
                sw.WriteLine("\t\t<thead>");
                sw.WriteLine("\t\t\t<tr>");
                sw.WriteLine("\t\t\t\t<th>\tNOMBRE\t</th>");
                sw.WriteLine("\t\t\t\t<th>\tTIPO\t</th>");
                //sw.WriteLine("\t\t\t\t<th>\tCOLUMNA\t</th>");
                //sw.WriteLine("\t\t\t\t<th>\tMENSAJE\t</th>");
                sw.WriteLine("\t\t\t</tr>");
                sw.WriteLine("\t\t</thead");

                foreach(var item in Form1.lista_figure)
                {
                    sw.WriteLine("\t\t\t<tr>");
                    sw.WriteLine("\t\t\t\t<td>\t{0}\t</td>", item.nombre);
                    sw.WriteLine("\t\t\t\t<td>\t{0}\t</td>", item.tipo);
                    sw.WriteLine("\t\t\t</tr>");
                }
                
                foreach(var item in Form1.lista_design)
                {
                    sw.WriteLine("\t\t\t<tr>");
                    sw.WriteLine("\t\t\t\t<td>\t{0}\t</td>", item.nombre);
                    sw.WriteLine("\t\t\t\t<td>\t{0}\t</td>", item.tipo);
                    sw.WriteLine("\t\t\t</tr>");
                }

                sw.WriteLine("\t\t</table");
                sw.WriteLine("\t\t</div>");
                sw.WriteLine("\t</body>");
                sw.WriteLine("</html>");

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            //CREANDO ARCHIVO .CSS
            try
            {
                //
                //#5858FA
                StreamWriter sw = new StreamWriter("C:\\Users\\JohnnyBravo\\Desktop\\Proyecto1Reportes\\TablaSimbolos\\TSimbolos.css");
                sw.WriteLine("body{background: #632432; font-family: Arial;}");
                sw.WriteLine("#main-container{margin: 150px auto; width: 600px;}");
                sw.WriteLine("table{background-color: white; text-align:left; border-collapse: collapse; width: 100%;}");
                sw.WriteLine("th,td{padding: 20px;}");
                sw.WriteLine("thead{background-color: #246355; border-bottom: solid 5px #0F362D; color: white; }");
                sw.WriteLine("tr:nth-child(even){background-color: #ddd;}");
                sw.WriteLine("tr:hover td{background-color: #369681; color: white;}");
                sw.WriteLine("h1{background-color:#246355; ");
                sw.WriteLine("\t color: white;");
                sw.WriteLine("\t text-align: center;}");
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }

    }
}
