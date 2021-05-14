using Dulceria.Entidades;
using Dulceria.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace Dulceria
{    
    public partial class Principal : Form
    {
        public Eusuarios cajero = new Eusuarios();
        ETransactionResult result = null;
        public string usr = "";
        private string nombre = "";
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            label1.Text = "Usuario: " + cajero.nombre + " " + cajero.apellidoP + " " + cajero.apellidoM;
            usr = cajero.usuario; 
            nombre = cajero.nombre + " " + cajero.apellidoP + " " + cajero.apellidoM;

            if (cajero.roll != "ADMIN")
            {
                administraciónToolStripMenuItem.Visible = false;                
                reportesToolStripMenuItem.Visible = false;
            }         
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            
        }



        private void seguridadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Seguridad hijo1 = new Seguridad();
            hijo1.TopLevel = false;
            hijo1.FormBorderStyle = FormBorderStyle.None;
            hijo1.Dock = DockStyle.Fill;
            //hijo1.usuario = usr;
            this.panel1.Controls.Add(hijo1);
            this.panel1.Tag = hijo1;
            hijo1.Show();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            gridProductos hijo1 = new gridProductos();
            hijo1.usuario = usr;
            hijo1.TopLevel = false;
            hijo1.FormBorderStyle = FormBorderStyle.None;
            hijo1.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(hijo1);
            this.panel1.Tag = hijo1;
            hijo1.Show();
        }



        private void reporteDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Reporte hijo1 = new Reporte();
            hijo1.TopLevel = false;
            hijo1.FormBorderStyle = FormBorderStyle.None;
            hijo1.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(hijo1);
            this.panel1.Tag = hijo1;
            hijo1.Show();
        }

        private void parametrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parametros conf = new Parametros();
            
            DialogResult dr = conf.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                conf.Close();
            }
            else if (dr == DialogResult.OK)
            {
                conf.Close();
            }
        }

        private void respaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup conf = new Backup();

            DialogResult dr = conf.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                conf.Close();
            }
            else if (dr == DialogResult.OK)
            {
                conf.Close();
            }
        }

        private void lnkSalir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea cerrar sesión?", "Salir", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                Close();
            }
            else if (result == DialogResult.No)
            {
                return;
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        private void venderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Venta hijo1 = new Venta();
            hijo1.TopLevel = false;
            hijo1.FormBorderStyle = FormBorderStyle.None;
            hijo1.Dock = DockStyle.Fill;
            hijo1.usuario = usr;
            hijo1.nombre = nombre;
            this.panel1.Controls.Add(hijo1);
            this.panel1.Tag = hijo1;
            hijo1.Show();
        }

        private void imprimirUltimoTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IVenta _venta = new LVenta();
            var ultimoTicket = _venta.GetUltimoTicket(ref result);

            Impresion imp = new Impresion();
            imp.Run(ultimoTicket, true);
        }

        private void cancelaciónDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Devolucion hijo1 = new Devolucion();
            hijo1.TopLevel = false;
            hijo1.FormBorderStyle = FormBorderStyle.None;
            hijo1.Dock = DockStyle.Fill;
            
            this.panel1.Controls.Add(hijo1);
            this.panel1.Tag = hijo1;
            hijo1.Show();
        }

        private void configuracionBasculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigBascula conf = new ConfigBascula();

            DialogResult dr = conf.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                conf.Close();
            }
            else if (dr == DialogResult.OK)
            {
                conf.Close();
            }
        }

        private void reporteDeExistenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            ReporteExistencia hijo1 = new ReporteExistencia();
            hijo1.TopLevel = false;
            hijo1.FormBorderStyle = FormBorderStyle.None;
            hijo1.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(hijo1);
            this.panel1.Tag = hijo1;
            hijo1.Show();
        }
    }
}
