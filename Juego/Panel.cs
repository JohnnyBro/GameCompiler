﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCompiler.Juego
{
    public partial class Panel : Form
    {
        public Panel()
        {
            InitializeComponent();
            //pintarTablero(20);
        }
        PictureBox[,] tablero = new PictureBox[20, 20];
        
        private void button1_Click(object sender, EventArgs e)
        {
            string ruta = "C:\\Users\\JohnnyBravo\\Desktop\\Proyecto1Reportes\\Images\\bomba.png";

            //this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            //this.pictureBox1.Name = "pictureBox1";
            //this.pictureBox1.Size = new System.Drawing.Size(52, 51);
            //this.pictureBox1.TabIndex = 0;
            //this.pictureBox1.TabStop = false;

            
            PictureBox pic1 = new PictureBox();
            pic1.Name = "pictureBox";
            pic1.Size = new Size(50, 50);
            pic1.Location = new Point(100, 100);
            pic1.Image = Resize(ruta, 10);
            panel1.Controls.Add(pic1);
            
            pictureBox1.Image = Resize(ruta, 10);

            
            
        }

        public static Bitmap Resize(string img, int porCiento)
        {
            Bitmap image = (Bitmap)Bitmap.FromFile(img);

            //float nPercent = ((float)porCiento / 100);
            float nPercent = porCiento;

            //int destinoWidth = (int)(image.Width * nPercent); int destinoHeight = (int)(image.Height * nPercent);

            int destinoWidth = (int)porCiento; 
            int destinoHeight = (int)porCiento;
            Bitmap Imagen2 = new Bitmap(destinoWidth, destinoHeight);

            using (Graphics g = Graphics.FromImage((Image)Imagen2)) 
            { 
                g.DrawImage(image, 0, 0, destinoWidth,destinoHeight); 
            }

            image.Dispose(); 
            
            return (Imagen2); 
        }





        PictureBox picture = new PictureBox
        {
            Name = "pictureBox",
            Size = new Size(16, 16),
            Location = new Point(100, 100),
            //Image = Image.FromFile("hello.jpg"),
        };

        private void Panel_Load(object sender, EventArgs e)
        {
            //Pintar pintar = new Pintar();
            // pintar.PintarTablero();
            pintarTablero(20);
        }
        public void pintarTablero(int n)
        {
            int tamanio = 800 / n;
            //int alto = 30;
            //int ancho = 30;
            string ruta = "C:\\Users\\JohnnyBravo\\Desktop\\Proyecto1Reportes\\Images\\bomba.png";
            
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    tablero[i, j] = new PictureBox();
                    this.Controls.Add(tablero[i, j]);
                    tablero[i, j].Width = tamanio;
                    tablero[i, j].Height = tamanio;
                    tablero[i, j].Top = tamanio*j;
                    tablero[i, j].Left = tamanio*i;
                    //tablero[i, j].BackColor = Color.Blue;
                    //Bitmap image = (Bitmap)Bitmap.FromFile(ruta);

                    tablero[i, j].Image = Resize(ruta,tamanio);
                }
            }
        }
    }
}
