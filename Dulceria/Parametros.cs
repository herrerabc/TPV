using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dulceria
{
    public partial class Parametros : Form
    {
        public Parametros()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTelefono.Text))
            {
                txtTelefono.Text = " -- -- -- -- --";
            }
            try
            {

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["Telefono"].Value = txtTelefono.Text;
                config.AppSettings.Settings["Domicilio"].Value = txtDomicilio.Text;
                config.AppSettings.Settings["Razon"].Value = txtRazon.Text;
                config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");

                MessageBox.Show("Se han actualizado los parametros correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.None);

                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al actualizar los parametros: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Parametros_Load(object sender, EventArgs e)
        {
            txtTelefono.Text = ConfigurationManager.AppSettings["Telefono"].ToString();
            txtDomicilio.Text = ConfigurationManager.AppSettings["Domicilio"].ToString();
            txtRazon.Text = ConfigurationManager.AppSettings["Razon"].ToString();
        }
    }
}
