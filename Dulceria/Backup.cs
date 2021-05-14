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
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dig = new FolderBrowserDialog();

            if(dig.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = dig.SelectedPath;
                btnBackup.Enabled = true;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtFile.Text))
            {
                MessageBox.Show("Debe ingresar la carpeta donde se alojara el respaldo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                LBackup db = new LBackup();
                ETransactionResult res =  new ETransactionResult();

                btnBackup.Enabled = false;
                btnBuscar.Enabled = false;

                db.setBackup(txtFile.Text, ref res);

                if(res.result == 0)
                {
                    MessageBox.Show("Se ha realizado el respaldo de la base de datos satisfactoriamente.","Exito", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Se ha generado un error en la generación del respado: " + res.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                btnBuscar.Enabled = true;
                txtFile.Text = string.Empty;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
