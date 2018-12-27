﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCompiler.Datos
{
    public class Figure
    {
        public String nombre;
        public String ruta;
        public Double vida;
        public String tipo;
        public String descripcion;
        public double x;
        public double y;

        public Figure(String name, String source, Double life, String type, String description)
        {
            this.nombre = name;
            this.ruta = source;
            this.vida = life;
            this.tipo = type;
            this.descripcion = description;
        }

        public void  agregar_posiciones(double posx, double posy)
        {
            this.x = posx;
            this.y = posy;
        }

       
    }
}
