using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dulceria.Logica;
using Dulceria.Entidades;

namespace Dulceria
{
    public partial class Seguridad : Form
    {
        ICatalogos _usuarios = new LUsuarios();
        List<Eusuarios> usuarios = new List<Eusuarios>();
        ETransactionResult result;
        public Seguridad()
        {
            InitializeComponent();
        }

        private void Seguridad_Load(object sender, EventArgs e)
        {
            llenaGrid();
        }
        private void llenaGrid()
        {
            usuarios = _usuarios.GetAll(ref result).Cast<Eusuarios>().ToList();
            dgUsuarios.DataSource = null;
            dgUsuarios.DataSource = usuarios;
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgUsuarios.DataSource = null;
            var lista = usuarios.Where(y => y.nombre.ToUpper().Contains(txtBuscar.Text.Trim().ToUpper())).ToList();
            dgUsuarios.DataSource = lista;
        }

        private void dgUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Usuarios user = new Usuarios();
            user.nuevo = false;
            user.user = dgUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString();

            DialogResult dr = user.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                user.Close();
            }
            else if (dr == DialogResult.OK)
            {
                llenaGrid();
                user.Close();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            user.nuevo = true;

            DialogResult dr = user.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                user.Close();
            }
            else if (dr == DialogResult.OK)
            {
                llenaGrid();
                user.Close();
            }
        }


    }
}
