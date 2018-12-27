namespace GameCompiler
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aRCHIVOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCerrarPestana = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.eJECUTARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEjecutarConf = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEjecutarEsc = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTablaSimbolos = new System.Windows.Forms.ToolStripMenuItem();
            this.itemErrores = new System.Windows.Forms.ToolStripMenuItem();
            this.aYUDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemManualUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.itemManualTecnico = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPestanas = new System.Windows.Forms.TabControl();
            this.txtConsola = new FastColoredTextBoxNS.FastColoredTextBox();
            this.btnJugar = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConsola)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aRCHIVOToolStripMenuItem,
            this.eJECUTARToolStripMenuItem,
            this.aYUDAToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1094, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aRCHIVOToolStripMenuItem
            // 
            this.aRCHIVOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemNuevo,
            this.itemAbrir,
            this.itemGuardar,
            this.itemCerrarPestana,
            this.itemSalir});
            this.aRCHIVOToolStripMenuItem.Name = "aRCHIVOToolStripMenuItem";
            this.aRCHIVOToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.aRCHIVOToolStripMenuItem.Text = "ARCHIVO";
            // 
            // itemNuevo
            // 
            this.itemNuevo.Name = "itemNuevo";
            this.itemNuevo.Size = new System.Drawing.Size(170, 22);
            this.itemNuevo.Text = "NUEVO";
            this.itemNuevo.Click += new System.EventHandler(this.itemNuevo_Click);
            // 
            // itemAbrir
            // 
            this.itemAbrir.Name = "itemAbrir";
            this.itemAbrir.Size = new System.Drawing.Size(170, 22);
            this.itemAbrir.Text = "ABRIR";
            this.itemAbrir.Click += new System.EventHandler(this.itemAbrir_Click);
            // 
            // itemGuardar
            // 
            this.itemGuardar.Name = "itemGuardar";
            this.itemGuardar.Size = new System.Drawing.Size(170, 22);
            this.itemGuardar.Text = "GUARDAR COMO";
            this.itemGuardar.Click += new System.EventHandler(this.itemGuardar_Click);
            // 
            // itemCerrarPestana
            // 
            this.itemCerrarPestana.Name = "itemCerrarPestana";
            this.itemCerrarPestana.Size = new System.Drawing.Size(170, 22);
            this.itemCerrarPestana.Text = "CERRAR PESTANA";
            this.itemCerrarPestana.Click += new System.EventHandler(this.itemCerrarPestana_Click);
            // 
            // itemSalir
            // 
            this.itemSalir.Name = "itemSalir";
            this.itemSalir.Size = new System.Drawing.Size(170, 22);
            this.itemSalir.Text = "SALIR";
            this.itemSalir.Click += new System.EventHandler(this.itemSalir_Click);
            // 
            // eJECUTARToolStripMenuItem
            // 
            this.eJECUTARToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemEjecutarConf,
            this.itemEjecutarEsc,
            this.itemTablaSimbolos,
            this.itemErrores});
            this.eJECUTARToolStripMenuItem.Name = "eJECUTARToolStripMenuItem";
            this.eJECUTARToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.eJECUTARToolStripMenuItem.Text = "EJECUTAR";
            // 
            // itemEjecutarConf
            // 
            this.itemEjecutarConf.Name = "itemEjecutarConf";
            this.itemEjecutarConf.Size = new System.Drawing.Size(223, 22);
            this.itemEjecutarConf.Text = "ARCHIVO CONFIGURACION";
            this.itemEjecutarConf.Click += new System.EventHandler(this.itemEjecutarConf_Click);
            // 
            // itemEjecutarEsc
            // 
            this.itemEjecutarEsc.Name = "itemEjecutarEsc";
            this.itemEjecutarEsc.Size = new System.Drawing.Size(223, 22);
            this.itemEjecutarEsc.Text = "ARCHIVO ESCENARIO";
            this.itemEjecutarEsc.Click += new System.EventHandler(this.itemEjecutarEsc_Click);
            // 
            // itemTablaSimbolos
            // 
            this.itemTablaSimbolos.Name = "itemTablaSimbolos";
            this.itemTablaSimbolos.Size = new System.Drawing.Size(223, 22);
            this.itemTablaSimbolos.Text = "TABLA DE SIMBOLOS";
            this.itemTablaSimbolos.Click += new System.EventHandler(this.itemTablaSimbolos_Click);
            // 
            // itemErrores
            // 
            this.itemErrores.Name = "itemErrores";
            this.itemErrores.Size = new System.Drawing.Size(223, 22);
            this.itemErrores.Text = "ERRORES";
            this.itemErrores.Click += new System.EventHandler(this.itemErrores_Click);
            // 
            // aYUDAToolStripMenuItem
            // 
            this.aYUDAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemManualUsuario,
            this.itemManualTecnico,
            this.itemAcercaDe});
            this.aYUDAToolStripMenuItem.Name = "aYUDAToolStripMenuItem";
            this.aYUDAToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.aYUDAToolStripMenuItem.Text = "AYUDA";
            // 
            // itemManualUsuario
            // 
            this.itemManualUsuario.Name = "itemManualUsuario";
            this.itemManualUsuario.Size = new System.Drawing.Size(177, 22);
            this.itemManualUsuario.Text = "MANUAL USUARIO";
            this.itemManualUsuario.Click += new System.EventHandler(this.itemManualUsuario_Click);
            // 
            // itemManualTecnico
            // 
            this.itemManualTecnico.Name = "itemManualTecnico";
            this.itemManualTecnico.Size = new System.Drawing.Size(177, 22);
            this.itemManualTecnico.Text = "MANUAL TECNICO";
            this.itemManualTecnico.Click += new System.EventHandler(this.itemManualTecnico_Click);
            // 
            // itemAcercaDe
            // 
            this.itemAcercaDe.Name = "itemAcercaDe";
            this.itemAcercaDe.Size = new System.Drawing.Size(177, 22);
            this.itemAcercaDe.Text = "ACERCA DE ";
            this.itemAcercaDe.Click += new System.EventHandler(this.itemAcercaDe_Click);
            // 
            // tabPestanas
            // 
            this.tabPestanas.Location = new System.Drawing.Point(355, 27);
            this.tabPestanas.Name = "tabPestanas";
            this.tabPestanas.SelectedIndex = 0;
            this.tabPestanas.Size = new System.Drawing.Size(700, 325);
            this.tabPestanas.TabIndex = 1;
            // 
            // txtConsola
            // 
            this.txtConsola.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtConsola.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.txtConsola.BackBrush = null;
            this.txtConsola.CharHeight = 14;
            this.txtConsola.CharWidth = 8;
            this.txtConsola.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConsola.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtConsola.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.txtConsola.IsReplaceMode = false;
            this.txtConsola.Location = new System.Drawing.Point(355, 377);
            this.txtConsola.Name = "txtConsola";
            this.txtConsola.Paddings = new System.Windows.Forms.Padding(0);
            this.txtConsola.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtConsola.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtConsola.ServiceColors")));
            this.txtConsola.Size = new System.Drawing.Size(700, 188);
            this.txtConsola.TabIndex = 2;
            this.txtConsola.Zoom = 100;
            // 
            // btnJugar
            // 
            this.btnJugar.Location = new System.Drawing.Point(232, 540);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(92, 25);
            this.btnJugar.TabIndex = 3;
            this.btnJugar.Text = "JUGAR";
            this.btnJugar.UseVisualStyleBackColor = true;
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(36, 327);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(130, 38);
            this.btnAnterior.TabIndex = 5;
            this.btnAnterior.Text = "ANTERIOR";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(172, 327);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(130, 38);
            this.btnSiguiente.TabIndex = 6;
            this.btnSiguiente.Text = "SIGUIENTE";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(33, 295);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 20);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "label1";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(36, 377);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(266, 71);
            this.txtDescripcion.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(36, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 254);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(93, 454);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(152, 53);
            this.btnSeleccionar.TabIndex = 9;
            this.btnSeleccionar.Text = "SELECCIONAR";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 598);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.txtConsola);
            this.Controls.Add(this.tabPestanas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConsola)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aRCHIVOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemNuevo;
        private System.Windows.Forms.ToolStripMenuItem itemAbrir;
        private System.Windows.Forms.ToolStripMenuItem itemGuardar;
        private System.Windows.Forms.ToolStripMenuItem itemSalir;
        private System.Windows.Forms.ToolStripMenuItem eJECUTARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aYUDAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemEjecutarConf;
        private System.Windows.Forms.ToolStripMenuItem itemEjecutarEsc;
        private System.Windows.Forms.ToolStripMenuItem itemTablaSimbolos;
        private System.Windows.Forms.ToolStripMenuItem itemErrores;
        private System.Windows.Forms.ToolStripMenuItem itemManualUsuario;
        private System.Windows.Forms.ToolStripMenuItem itemManualTecnico;
        private System.Windows.Forms.ToolStripMenuItem itemAcercaDe;
        private System.Windows.Forms.TabControl tabPestanas;
        private FastColoredTextBoxNS.FastColoredTextBox txtConsola;
        private System.Windows.Forms.Button btnJugar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ToolStripMenuItem itemCerrarPestana;
        private System.Windows.Forms.Button btnSeleccionar;
    }
}

