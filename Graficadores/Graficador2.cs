using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;
using System.IO;


namespace GameCompiler.Graficadores
{
    class Graficador2
    {
        public String desktop;
        private StringBuilder graphivz;
        private StringBuilder graphviz2;
        private int contador;

        public Graficador2()
        {
            desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            this.generarRutas();
        }

        private void generarRutas()
        {
            String desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            List<String> rutas = new List<String>();
            rutas.Add(desktop + "\\Proyecto1Reportes");
            rutas.Add(desktop + "\\Proyecto1Reportes\\Arbol");
            foreach (String item in rutas)
            {
                if (!System.IO.Directory.Exists(item))
                {
                    System.IO.DirectoryInfo dir = System.IO.Directory.CreateDirectory(item);
                }
            }
        }

        private void generarDOT_PNG(String rdot, String rpng)
        {
            System.IO.File.WriteAllText(rdot, graphivz.ToString());
            String comandodot = "C:\\Graphviz\\bin\\dot.exe -Tpng " + rdot + " -o " + rpng + " ";
            var command = string.Format(comandodot);
            var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + command);
            var proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            proc.WaitForExit();
        }

        private void generarDOT_PNG2(String rdot, String rpng)
        {
            System.IO.File.WriteAllText(rdot, graphviz2.ToString());
            String comandodot = "C:\\Graphviz\\bin\\dot.exe -Tpng " + rdot + " -o " + rpng + " ";
            var command = string.Format(comandodot);
            var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + command);
            var proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            proc.WaitForExit();
        }

        public void graficar(ParseTree arbol)
        {
            graphivz = new StringBuilder();
            contador = 0;
            String rdot = desktop + "\\Proyecto1Reportes\\Arbol\\arbol2.dot";
            String rpng = desktop + "\\Proyecto1Reportes\\Arbol\\arbol2.png";
            graphivz.Append("digraph G {\r\n node[shape=rectangle, style=filled, color=khaki1, fontcolor=black]; \r\n");
            Arbol_listar_enlazar(arbol.Root, contador);
            graphivz.Append("}");
            this.generarDOT_PNG(rdot, rpng);
        }

        private void Arbol_listar_enlazar(ParseTreeNode nodo, int num)
        {
            if (nodo != null)
            {
                graphivz.Append("node" + num + " [ label = \"" + nodo.Term.ToString() + "\"];\r\n");
                int tam = nodo.ChildNodes.Count;
                int actual;
                for (int i = 0; i < tam; i++)
                {
                    contador = contador + 1;
                    actual = contador;
                    Arbol_listar_enlazar(nodo.ChildNodes[i], contador);
                    graphivz.Append("\"node" + num + "\"->\"node" + actual + "\";\r\n");
                }
            }
        }

        public void abrirArbol(String ruta)
        {
            if (!File.Exists(ruta))
                return;

            try
            {
                System.Diagnostics.Process.Start(ruta);
            }
            catch (Exception ex)
            {
                //Error :|
                Console.WriteLine(ex);
            }
        }

        public void GraficarFlujo()
        {
            string proceso = "TAREA";
            graphviz2 = new StringBuilder();
            String rdot = desktop + "\\Proyecto1Reportes\\Arbol\\flujo2.dot";
            String rpng = desktop + "\\Proyecto1Reportes\\Arbol\\flujo2.png";
            graphviz2.Append("digraph G {\r\n nodeInicio[shape=ellipse, style=filled, color=khaki1, fontcolor=black]; \r\n");
            graphviz2.Append("nodeFin[shape=doublecircle,style=filled, color=khaki1, fontcolor=black]; \r\n");
            graphviz2.Append("node[shape=diamond,style=filled, color=khaki1, fontcolor=black]; \r\n");
            graphviz2.Append("nodeInicio[label=\"INICIO\"];\r\n");
            graphviz2.Append("nodeFin[label=\"FIN\"];\r\n");
            graphviz2.Append("node[label=\"" + proceso + "\"];\r\n");
            graphviz2.Append("\"nodeInicio\"->\"node\";\r\n");
            graphviz2.Append("\"node\"->\"nodoFin\";\r\n");
            graphviz2.Append("}");
            this.generarDOT_PNG2(rdot, rpng);
        }
    }
}
