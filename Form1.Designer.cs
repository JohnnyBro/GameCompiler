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
            this.itemGuardarComo = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.eJECUTARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEjecutarConf = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEjecutarEsc = new System.Windows.Forms.ToolStripMenuItem();
            this.tABLADESIMBOLOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemErrores = new System.Windows.Forms.ToolStripMenuItem();
            this.aYUDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mANUALUSUARIOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mANUALTECNICOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCERCADEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPestanas = new System.Windows.Forms.TabControl();
            this.txtConsola = new FastColoredTextBoxNS.FastColoredTextBox();
            this.btnJugar = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConsola)).BeginInit();
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
            this.itemGuardarComo,
            this.itemSalir});
            this.aRCHIVOToolStripMenuItem.Name = "aRCHIVOToolStripMenuItem";
            this.aRCHIVOToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.aRCHIVOToolStripMenuItem.Text = "ARCHIVO";
            // 
            // itemNuevo
            // 
            this.itemNuevo.Name = "itemNuevo";
            this.itemNuevo.Size = new System.Drawing.Size(168, 22);
            this.itemNuevo.Text = "NUEVO";
            this.itemNuevo.Click += new System.EventHandler(this.itemNuevo_Click);
            // 
            // itemAbrir
            // 
            this.itemAbrir.Name = "itemAbrir";
            this.itemAbrir.Size = new System.Drawing.Size(168, 22);
            this.itemAbrir.Text = "ABRIR";
            this.itemAbrir.Click += new System.EventHandler(this.itemAbrir_Click);
            // 
            // itemGuardar
            // 
            this.itemGuardar.Name = "itemGuardar";
            this.itemGuardar.Size = new System.Drawing.Size(168, 22);
            this.itemGuardar.Text = "GUARDAR";
            this.itemGuardar.Click += new System.EventHandler(this.itemGuardar_Click);
            // 
            // itemGuardarComo
            // 
            this.itemGuardarComo.Name = "itemGuardarComo";
            this.itemGuardarComo.Size = new System.Drawing.Size(168, 22);
            this.itemGuardarComo.Text = "GUARDAR COMO";
            // 
            // itemSalir
            // 
            this.itemSalir.Name = "itemSalir";
            this.itemSalir.Size = new System.Drawing.Size(168, 22);
            this.itemSalir.Text = "SALIR";
            this.itemSalir.Click += new System.EventHandler(this.itemSalir_Click);
            // 
            // eJECUTARToolStripMenuItem
            // 
            this.eJECUTARToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemEjecutarConf,
            this.itemEjecutarEsc,
            this.tABLADESIMBOLOSToolStripMenuItem,
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
            // tABLADESIMBOLOSToolStripMenuItem
            // 
            this.tABLADESIMBOLOSToolStripMenuItem.Name = "tABLADESIMBOLOSToolStripMenuItem";
            this.tABLADESIMBOLOSToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.tABLADESIMBOLOSToolStripMenuItem.Text = "TABLA DE SIMBOLOS";
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
            this.mANUALUSUARIOToolStripMenuItem,
            this.mANUALTECNICOToolStripMenuItem,
            this.aCERCADEToolStripMenuItem});
            this.aYUDAToolStripMenuItem.Name = "aYUDAToolStripMenuItem";
            this.aYUDAToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.aYUDAToolStripMenuItem.Text = "AYUDA";
            // 
            // mANUALUSUARIOToolStripMenuItem
            // 
            this.mANUALUSUARIOToolStripMenuItem.Name = "mANUALUSUARIOToolStripMenuItem";
            this.mANUALUSUARIOToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.mANUALUSUARIOToolStripMenuItem.Text = "MANUAL USUARIO";
            // 
            // mANUALTECNICOToolStripMenuItem
            // 
            this.mANUALTECNICOToolStripMenuItem.Name = "mANUALTECNICOToolStripMenuItem";
            this.mANUALTECNICOToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.mANUALTECNICOToolStripMenuItem.Text = "MANUAL TECNICO";
            // 
            // aCERCADEToolStripMenuItem
            // 
            this.aCERCADEToolStripMenuItem.Name = "aCERCADEToolStripMenuItem";
            this.aCERCADEToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.aCERCADEToolStripMenuItem.Text = "ACERCA DE ";
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
            this.btnJugar.Location = new System.Drawing.Point(72, 264);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(138, 65);
            this.btnJugar.TabIndex = 3;
            this.btnJugar.Text = "JUGAR";
            this.btnJugar.UseVisualStyleBackColor = true;
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 598);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aRCHIVOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemNuevo;
        private System.Windows.Forms.ToolStripMenuItem itemAbrir;
        private System.Windows.Forms.ToolStripMenuItem itemGuardar;
        private System.Windows.Forms.ToolStripMenuItem itemGuardarComo;
        private System.Windows.Forms.ToolStripMenuItem itemSalir;
        private System.Windows.Forms.ToolStripMenuItem eJECUTARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aYUDAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemEjecutarConf;
        private System.Windows.Forms.ToolStripMenuItem itemEjecutarEsc;
        private System.Windows.Forms.ToolStripMenuItem tABLADESIMBOLOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemErrores;
        private System.Windows.Forms.ToolStripMenuItem mANUALUSUARIOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mANUALTECNICOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aCERCADEToolStripMenuItem;
        private System.Windows.Forms.TabControl tabPestanas;
        private FastColoredTextBoxNS.FastColoredTextBox txtConsola;
        private System.Windows.Forms.Button btnJugar;
    }
}

