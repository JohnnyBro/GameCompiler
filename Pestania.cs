using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace GameCompiler
{
    public class Pestania : TabPage
    {
        private Form frm;

        public Pestania(MyFormPage frm_contenido)
        {
            this.frm = frm_contenido;
            this.Controls.Add(frm_contenido.pnl);
            this.Text = frm_contenido.Text;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                frm.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class MyFormPage : Form
    {
        public string nombre;
        public Panel pnl;
        public FastColoredTextBoxNS.FastColoredTextBox txtEntrada;

    }
}
