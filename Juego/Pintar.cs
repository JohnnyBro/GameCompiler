using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GameCompiler.Juego
{
    public class Pintar
    {
        PictureBox[,] tablero = new PictureBox[30, 30];
        Panel panel = new Panel();
        public Pintar()
        {

        }

        public void PintarTablero()
        {
            int alto=30;
            int ancho=30;
            string ruta = "C:\\Users\\JohnnyBravo\\Desktop\\Proyecto1Reportes\\Images\\bomba.png";
            for(int j=0; j<ancho; j++)
            {
                for(int i=0; i<alto; i++)
                {
                    tablero[i,j]=new PictureBox();
                    panel.Controls.Add(tablero[i,j]);
                    tablero[i, j].Width = ancho;
                    tablero[i, j].Height = alto;
                    tablero[i, j].Top = alto * j;
                    tablero[i, j].Left = alto * i;
                    tablero[i, j].BackColor = Color.Blue;
                    //tablero[i, j].Image = Image.FromFile(ruta);
                }
            }
        }
    }
}
