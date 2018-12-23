namespace GameCompiler
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPestanaIn = new FastColoredTextBoxNS.FastColoredTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPestanaIn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPestanaIn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 286);
            this.panel1.TabIndex = 0;
            // 
            // txtPestanaIn
            // 
            this.txtPestanaIn.AutoCompleteBracketsList = new char[] {
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
            this.txtPestanaIn.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.txtPestanaIn.BackBrush = null;
            this.txtPestanaIn.CharHeight = 14;
            this.txtPestanaIn.CharWidth = 8;
            this.txtPestanaIn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPestanaIn.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtPestanaIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPestanaIn.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.txtPestanaIn.IsReplaceMode = false;
            this.txtPestanaIn.Location = new System.Drawing.Point(0, 0);
            this.txtPestanaIn.Name = "txtPestanaIn";
            this.txtPestanaIn.Paddings = new System.Windows.Forms.Padding(0);
            this.txtPestanaIn.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtPestanaIn.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtPestanaIn.ServiceColors")));
            this.txtPestanaIn.Size = new System.Drawing.Size(684, 286);
            this.txtPestanaIn.TabIndex = 0;
            this.txtPestanaIn.Zoom = 100;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 286);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPestanaIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FastColoredTextBoxNS.FastColoredTextBox txtPestanaIn;
    }
}