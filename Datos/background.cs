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
        public double ancho;
        public double alto;
        public bool seleccionado;

        public Background(String nom,String ruta)
        {
            this.nombre = nom;
            this.ruta = ruta;
            this.seleccionado = false;
        }

        public void agregarValores(double x, double y)
        {
            this.ancho = x;
            this.alto = y;
            seleccionado = true;
        }

    }
}
