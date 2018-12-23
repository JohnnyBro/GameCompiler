using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCompiler.Datos
{
    public class Background
    {
        public string nombre;
        public string ruta;

        public Background(String nom,String ruta)
        {
            this.nombre = nom;
            this.ruta = ruta;   
        }
    }
}
