using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCompiler
{
    class ListaPestanas
    {
        static List<Form2> Lpestanias = new List<Form2>();

        public ListaPestanas()
        {
            // Lpestanias = null;
        }

        public void insertarPestania(Form2 pestania)
        {
            Lpestanias.Add(pestania);
        }

        public string leerEntrada(string name)
        {
            string cuadroTexto = "";
            foreach (Form2 elemento in Lpestanias)
            {
                if (elemento.nombre == name)
                {
                    cuadroTexto = elemento.txtEntrada.Text;
                    //int contador = 0;

                    break;
                }
            }
            return cuadroTexto;
        }
    }
}
