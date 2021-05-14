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

namespace Dulceria
{
    public partial class CargaMasiva : Form
    {
        public CargaMasiva()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open CSV File";
            openFileDialog1.Filter = "CSV Files (*.csv)|*.csv";

            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                txtFile.Text = openFileDialog1.FileName;
                btnCargar.Enabled = true;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFile.Text))
            {
                MessageBox.Show("Debe ingresar la ruta del archivo CSV.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                LCargaMasiva db = new LCargaMasiva();
                ETransactionResult res = new ETransactionResult();

                btnCargar.Enabled = false;
                btnBuscar.Enabled = false;

                db.SetProductos(txtFile.Text, ref res);

                if (res.result == 0)
                {
                    MessageBox.Show("Se ha realizado la carga masiva exitosamente.", "Exito", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Se ha generado un error en la carga masiva: " + res.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                btnBuscar.Enabled = true;
                txtFile.Text = string.Empty;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
