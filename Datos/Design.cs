using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCompiler.Datos
{
    public class Design
    {
        public string nombre;
        public string ruta;
        public string tipo;
        public double danio;
        public double puntos;

        public double xini;
        public double xfin;
        public double yini;
        public double yfin;


       public Design(string name, string source, string type, double danio, double points)
        {
            this.nombre = name;
            this.ruta = source;
            this.tipo = type;
            this.danio = danio;
            this.puntos = points;
        }

       public void agregarPosiciones(double xi, double xf, double yi, double yf)
        {
            this.xini = xi;
            this.xfin = xf;
            this.yini = yi;
            this.yfin = yf;
        }
    }
}
