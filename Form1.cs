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
using GameCompiler.Datos;
using System.Windows.Forms;
namespace GameCompiler
{
    public partial class Form1 : Form
    {
        public static string nombreJugador = "";
        public static string imagenJugador = "";
        public static double vidaJugador = 0;
        bool seleccionarJugador = false;
        int nuevo = 0;
        String ruta = "";
        int tamLista;
        int contador = 0;
        Figure aux;
        public static List<Error> LErrores = new List<Error>();
        public static LinkedList<Background> lista_background = new LinkedList<Background>();
        public static LinkedList<Figure> lista_figure = new LinkedList<Figure>();
        public static LinkedList<Design> lista_design = new LinkedList<Design>();
        static ListaPestanas LP = new ListaPestanas();
        Juego.Celda[,] matrizControl;
        public Form1()
        {
            InitializeComponent();
            //mostrarImagenes("inicio");
            lblNombre.Visible = false;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lecturaInicial();
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
                //Se limpiaN laS listas cada vez que se compila para que no muestre errores ni datos anteriores a su correcion.
                LErrores.Clear();
                lista_design.Clear();
                lista_figure.Clear();
                lista_background.Clear();
                txtConsola.Text = "";
                //Ejecucion.Ejecutor ejecutor=new Ejecucion.Ejecutor();
                string entrada = LP.leerEntrada(tabPestanas.SelectedTab.Text);
                bool resultado = Analizadores.Interprete.analizar1(LP.leerEntrada(tabPestanas.SelectedTab.Text));
                // txtConsola.Text = ejecutor.MostrarSalida();
                //bool resultado2 = Analizadores.Interprete.analizar2(LP.leerEntrada(pestanas1.SelectedTab.Text), pestanas1.SelectedTab.Name);    

                if (resultado == true && LErrores.Count==0)
                {

                    MessageBox.Show("ANALISIS  COMPLETADO");
                    Analizadores.Interprete inter = new Interprete();
                    inter.RecorrerListas();
                    aux = lista_figure.First();
                    tamLista = lista_figure.Count;
                    mostrarImagenes("inicio");
                
                }
                else
                {

                    MessageBox.Show("EXISTEN ERRORES LEXICOS O SINTACTICOS");
                    foreach(var item in LErrores)
                    {
                        txtConsola.Text = txtConsola.Text + "*" + item.tipo + "  " + item.mensaje + "  Linea: " + item.linea + "  Columna: " + item.columna+"\n"; 
                    }
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
            string imagenPanel = "";
            int tamano = 0;
            if(seleccionarJugador==true)
            {
               
                
                foreach(var item in Form1.lista_background)
                {
                    if(item.seleccionado==true)
                    {
                        imagenPanel = item.ruta;
                        imagenPanel = imagenPanel.Replace("\"", " ");
                        tamano = (int)item.alto;
                    }
                }

                //matrizControl = new Juego.Celda[tamano, tamano];
                crearMatrizControl(tamano);
                Juego.Panel juego = new Juego.Panel();
                juego.BackgroundImage = Image.FromFile(imagenPanel);
                Juego.Panel.n = tamano;
                juego.nombre = nombreJugador;
                juego.vida = vidaJugador;
                juego.Show();
            }else
            {
                MessageBox.Show("Seleccione un personaje..");
            }
            
            //juego.pintar pintar = new juego.pintar();
            //pintar.pintartablero();
        }

        private void crearMatrizControl(int n)
        {
            matrizControl = new Juego.Celda[n, n];

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    //matrizControl[i, j] = new Juego.Celda();
                    //if (i == 10 && j == 10)
                    //{
                    //    //panelJuego.Controls.Remove(tablero[i, j]);
                    //}
                    ////this.Controls.Add(tablero[i, j]);
                    //tablero[i, j].Width = tamanio;
                    //tablero[i, j].Height = tamanio;
                    //tablero[i, j].Top = tamanio * j;
                    //tablero[i, j].Left = tamanio * i;
                    ////tablero[i, j].BackColor = Color.Blue;
                    ////Bitmap image = (Bitmap)Bitmap.FromFile(ruta);

                    //tablero[i, j].Image = Resize(ruta, tamanio);
                }
            }
        }

        private void itemEjecutarEsc_Click(object sender, EventArgs e)
        {
            if (tabPestanas.SelectedTab.Text != "")
            {
                //Se limpiaN las listas cada vez que se compila para que no muestre errores ni datos anteriores a su correcion.
                LErrores.Clear();
                txtConsola.Text = "";
                //Ejecucion.Ejecutor ejecutor=new Ejecucion.Ejecutor();
                string entrada = LP.leerEntrada(tabPestanas.SelectedTab.Text);
                //MessageBox.Show(entrada);
                bool resultado = Analizadores.Interprete2.analizar2(LP.leerEntrada(tabPestanas.SelectedTab.Text));
                // txtConsola.Text = ejecutor.MostrarSalida();
                //bool resultado2 = Analizadores.Interprete.analizar2(LP.leerEntrada(pestanas1.SelectedTab.Text), pestanas1.SelectedTab.Name);    

                if (resultado == true)
                {

                    MessageBox.Show("ANALISIS  COMPLETADO");
                    Analizadores.Interprete inter = new Interprete();
                    inter.RecorrerListas();
                    
                }
                else
                {

                    MessageBox.Show("EXISTEN ERRORES LEXICOS O SINTACTICOS");
                    foreach (var item in LErrores)
                    {
                        txtConsola.Text = txtConsola.Text + "*" + item.tipo + "  " + item.mensaje + "  Linea: " + item.linea + "  Columna: " + item.columna + "\n";
                    }
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

        public   void mostrarImagenes(string accion)
        {
            lblNombre.Visible = true;
            switch(accion)
            {
                    
                case "inicio":
                    if (tamLista > contador)
                    {
                        ruta = lista_figure.ElementAt(contador).ruta;
                        ruta = ruta.Replace("\"", " ");
                        Bitmap img = (Bitmap)Bitmap.FromFile(ruta);
                        img.MakeTransparent();
                        pictureBox1.Image = img;
                        lblNombre.Text = lista_figure.ElementAt(contador).nombre;
                        string des = "";
                        des = lista_figure.ElementAt(contador).descripcion;
                        des = des.Replace("\"", " ");
                        txtDescripcion.Text = des;

                        imagenJugador = ruta;
                        nombreJugador = lista_figure.ElementAt(contador).nombre;
                        vidaJugador = lista_figure.ElementAt(contador).vida;
                        
                    }
                    break;
                case "siguiente":
                    contador++;
                    if (contador<tamLista)
                    {
                        ruta = lista_figure.ElementAt(contador).ruta;
                        ruta = ruta.Replace("\"", " ");
                        //ruta.ToString().Replace('"',' ');
                        pictureBox1.Image = Image.FromFile(ruta);
                        lblNombre.Text = lista_figure.ElementAt(contador).nombre;
                        string des = "";
                        des = lista_figure.ElementAt(contador).descripcion;
                        des = des.Replace("\"", " ");
                        txtDescripcion.Text = des;

                        imagenJugador = ruta;
                        nombreJugador = lista_figure.ElementAt(contador).nombre;
                        vidaJugador = lista_figure.ElementAt(contador).vida;
                    }
                    else
                    {
                        contador--;
                    }
                    break;
                case "anterior":
                    contador--;
                    if (contador>=0)
                    {
                        ruta = lista_figure.ElementAt(contador).ruta;
                        ruta = ruta.Replace("\"", " ");
                        //ruta.ToString().Replace('"',' ');
                        pictureBox1.Image = Image.FromFile(ruta);
                        lblNombre.Text = lista_figure.ElementAt(contador).nombre;
                        string des = "";
                        des = lista_figure.ElementAt(contador).descripcion;
                        des = des.Replace("\"", " ");
                        txtDescripcion.Text = des;

                        imagenJugador = ruta;
                        nombreJugador = lista_figure.ElementAt(contador).nombre;
                        vidaJugador = lista_figure.ElementAt(contador).vida;
                    }
                    else
                    {
                        contador++;
                    }
                    break;
                default:
                    MessageBox.Show("ERROR DEL SISTEMA");
                    break;
            }

            

            
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            seleccionarJugador = false;
            mostrarImagenes("siguiente");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            seleccionarJugador = false;
            mostrarImagenes("anterior");
        }

        private void itemCerrarPestana_Click(object sender, EventArgs e)
        {
            if (tabPestanas.SelectedTab != null)
            {
                if (MessageBox.Show("DESEA GUARDAR LOS CAMBIOS?", "GUARDAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //savefiledialog guardar = new savefiledialog();
                    //guardar.filter = "psc|*.psc";
                    //guardar.title = "guardar archivos .psc";
                    //guardar.showdialog();
                    //messagebox.show(guardar.filename);
                    //system.io.file.writealltext(guardar.filename, lp.leerentrada(tabpestanas.selectedtab.text));
                    //tabpestanas.selectedtab.dispose();


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
                    String nombre = tabPestanas.SelectedTab.Text;
                    //MessageBox.Show(nombre);
                    tabPestanas.SelectedTab.Dispose();
                }
            }
            else
            {
                MessageBox.Show("NO EXISTEN PESTANAS POR CERRAR");
            }
        }

        private void itemTablaSimbolos_Click(object sender, EventArgs e)
        {
            try
            {
                String path = "C:\\Users\\JohnnyBravo\\Desktop\\Proyecto1Reportes\\TablaSimbolos\\TSimbolos.html";
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
            Reportes.TablaSimbolos tabla = new Reportes.TablaSimbolos();
            tabla.ReporteTablaSimbolos();

            try
            {

                Process.Start("C:\\Users\\JohnnyBravo\\Desktop\\Proyecto1Reportes\\TablaSimbolos\\TSimbolos.html");
            }
            catch (Exception g)
            {
                Console.WriteLine("Exception: " + g.Message);
            }
        }

        public void lecturaInicial()
        {
            string ruta = "C:\\Users\\JohnnyBravo\\Desktop\\Proyecto1Reportes\\ArchivosEntrada\\Entrada1.xconf";
            if (!string.IsNullOrEmpty(ruta))
            {
                
                //MessageBox.Show(ruta);
                string leer = File.ReadAllText(ruta);
                bool resultado = Analizadores.Interprete.analizar1(leer);
                if (resultado == true && LErrores.Count == 0)
                {
                    MessageBox.Show("ANALISIS  COMPLETADO");
                    Analizadores.Interprete inter = new Interprete();
                    inter.RecorrerListas();
                    aux = lista_figure.First();
                    tamLista = lista_figure.Count;
                    mostrarImagenes("inicio");

                }
                else
                {
                    MessageBox.Show("EXISTEN ERRORES LEXICOS O SINTACTICOS");
                    foreach (var item in LErrores)
                    {
                        txtConsola.Text = txtConsola.Text + "*" + item.tipo + "  " + item.mensaje + "  Linea: " + item.linea + "  Columna: " + item.columna + "\n";
                    }
                }



   

            }
            else
            {
                MessageBox.Show("Error con la ruta del archivo inicial");
            }
        }

        private void itemAcercaDe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desarrollado por: \n Johnny Mike Bravo Zamora\n Ingenieria Usac");
        }

        private void itemManualUsuario_Click(object sender, EventArgs e)
        {
            try
            {

                Process.Start("D:\\DICIEMBRE 2018\\Compi1\\Proyecto1\\Manuales\\ManualUsuario.pdf");
            }
            catch (Exception g)
            {
                Console.WriteLine("Exception: " + g.Message);
            }
        }

        private void itemManualTecnico_Click(object sender, EventArgs e)
        {
            try
            {

                Process.Start("D:\\DICIEMBRE 2018\\Compi1\\Proyecto1\\Manuales\\ManualTecnico.pdf");
            }
            catch (Exception g)
            {
                Console.WriteLine("Exception: " + g.Message);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            seleccionarJugador = true;
            MessageBox.Show(lblNombre.Text + " seleccionado..");
        }

 

     

   

      
    }
}
