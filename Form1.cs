using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;
using GameCompiler.Analizadores;
using GameCompiler.Graficadores;

namespace GameCompiler
{
    public partial class Form1 : Form
    {
        int nuevo = 0;
        public static List<Error> LErrores = new List<Error>();
        static ListaPestanas LP = new ListaPestanas();
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void itemSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void itemNuevo_Click(object sender, EventArgs e)
        {
            nuevo++;

            Form2 pestana = new Form2();
            pestana.Text = "Nuevo " + nuevo.ToString();
            pestana.nombre = "Nuevo " + nuevo.ToString();
            LP.insertarPestania(pestana);
            tabPestanas.TabPages.Add(new Pestania(pestana));
        }

        private void itemAbrir_Click(object sender, EventArgs e)
        {
            String ruta = "";
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Configuracion|*.xconf|Escenario|*.xesc";
            file.Title = "GAME COMPILER FILES";
            file.ShowDialog();
            if (!string.IsNullOrEmpty(file.FileName))
            {
                ruta = file.FileName;
                //MessageBox.Show(ruta);
                string leer = File.ReadAllText(ruta);

                Form2 pestana = new Form2();
                pestana.Text = file.SafeFileName;
                pestana.txtEntrada.Text = leer;
                pestana.nombre = file.SafeFileName;

                LP.insertarPestania(pestana);
                tabPestanas.TabPages.Add(new Pestania(pestana));

            }
        }

        private void itemGuardar_Click(object sender, EventArgs e)
        {
            String ruta = "";

            if (tabPestanas.SelectedTab != null)
            {
                if(ruta=="")
                {
                    SaveFileDialog guardar = new SaveFileDialog();
                    guardar.Filter = "Configuracion|*.xconf|Escenario|*.xesc";
                    guardar.Title = "GAME COMPILER FILES";
                    guardar.ShowDialog();
                    ruta = guardar.FileName;
                    try
                    {
                        System.IO.File.WriteAllText(ruta, LP.leerEntrada(tabPestanas.SelectedTab.Text));
                        MessageBox.Show("El archivo se guardo correctamente.");
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    try
                    {
                        System.IO.File.WriteAllText(ruta, LP.leerEntrada(tabPestanas.SelectedTab.Text));
                        MessageBox.Show("El archivo se guardo correctamente.");
                    }
                    catch (Exception)
                    {

                    }
                }
                
                
            }
            else
            {
                MessageBox.Show("NO EXISTE INFORMACION  PARA GUARDAR");
            }
        }

        private void itemEjecutarConf_Click(object sender, EventArgs e)
        {
            if (tabPestanas.SelectedTab.Text != "")
            {
                //Ejecucion.Ejecutor ejecutor=new Ejecucion.Ejecutor();
                string entrada = LP.leerEntrada(tabPestanas.SelectedTab.Text);
                //MessageBox.Show(entrada);
                bool resultado = Analizadores.Interprete.analizar1(LP.leerEntrada(tabPestanas.SelectedTab.Text));
                // txtConsola.Text = ejecutor.MostrarSalida();
                //bool resultado2 = Analizadores.Interprete.analizar2(LP.leerEntrada(pestanas1.SelectedTab.Text), pestanas1.SelectedTab.Name);    

                if (resultado == true)
                {

                    MessageBox.Show("ANALISIS 1 COMPLETADO");
                    Analizadores.Interprete inter = new Interprete();
                    inter.RecorrerListas();
                
                }
                else
                {

                    MessageBox.Show("EXISTEN ERRORES LEXICOS O SINTACTICOS");
                }

                /*if (resultado2 == true)
                {
                    MessageBox.Show("ANALISIS 2 COMPLETADO");
                    abrirImagen2();
                }
                else
                {

                    MessageBox.Show("EXISTEN ERRORES LEXICOS O SINTACTICOS entrada 2");
                }*/

            }
            else
            {
                MessageBox.Show("INGRESE ALGUN TEXTO");
            }

            for (int i = 0; i < LErrores.Count; i++)
            {
                Console.WriteLine("Error: {0} Linea: {1} Columna: {2} ", LErrores[i].tipo, LErrores[i].linea, LErrores[i].columna);
            }
        }

        private void itemErrores_Click(object sender, EventArgs e)
        {
            try
            {
                String path = "C:\\Users\\JohnnyBravo\\Desktop\\Proyecto1Reportes\\Errores\\Errores.html";
                if (File.Exists(path))
                {
                    File.Delete(path);
                    Console.WriteLine("Elimino el archivo html***");
                }

            }
            catch (Exception f)
            {
                Console.WriteLine("Exception: " + f.Message);
            }
            Reportes.RepErrores errores = new Reportes.RepErrores();
            errores.ReporteErrores();
            try
            {

                Process.Start("C:\\Users\\JohnnyBravo\\Desktop\\Proyecto1Reportes\\Errores\\Errores.html");
            }
            catch (Exception g)
            {
                Console.WriteLine("Exception: " + g.Message);
            }
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            Juego.Panel juego = new Juego.Panel();
            juego.Show();
        }

        private void itemEjecutarEsc_Click(object sender, EventArgs e)
        {
            if (tabPestanas.SelectedTab.Text != "")
            {
                //Ejecucion.Ejecutor ejecutor=new Ejecucion.Ejecutor();
                string entrada = LP.leerEntrada(tabPestanas.SelectedTab.Text);
                //MessageBox.Show(entrada);
                bool resultado = Analizadores.Interprete2.analizar2(LP.leerEntrada(tabPestanas.SelectedTab.Text));
                // txtConsola.Text = ejecutor.MostrarSalida();
                //bool resultado2 = Analizadores.Interprete.analizar2(LP.leerEntrada(pestanas1.SelectedTab.Text), pestanas1.SelectedTab.Name);    

                if (resultado == true)
                {

                    MessageBox.Show("ANALISIS 1 COMPLETADO");
                    Analizadores.Interprete inter = new Interprete();
                    inter.RecorrerListas();

                }
                else
                {

                    MessageBox.Show("EXISTEN ERRORES LEXICOS O SINTACTICOS");
                }

                /*if (resultado2 == true)
                {
                    MessageBox.Show("ANALISIS 2 COMPLETADO");
                    abrirImagen2();
                }
                else
                {

                    MessageBox.Show("EXISTEN ERRORES LEXICOS O SINTACTICOS entrada 2");
                }*/

            }
            else
            {
                MessageBox.Show("INGRESE ALGUN TEXTO");
            }

            for (int i = 0; i < LErrores.Count; i++)
            {
                Console.WriteLine("Error: {0} Linea: {1} Columna: {2} ", LErrores[i].tipo, LErrores[i].linea, LErrores[i].columna);
            }

        }



   

      
    }
}
