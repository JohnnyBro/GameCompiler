using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCompiler.Analizadores
{
     public class Error
    {
        public String tipo;
        public String mensaje;
        public int linea;
        public int columna;

        public Error(String type, String message, int line, int colum)
        {
            this.tipo = type;
            this.linea = line;
            this.columna = colum;
            this.mensaje = message;
        }
    }
}
