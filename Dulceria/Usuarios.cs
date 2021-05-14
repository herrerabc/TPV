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

namespace Dulceria
{
    public partial class Usuarios : Form
    {
        public bool nuevo;
        public string user;
        ICatalogos _usuarios = new LUsuarios();
        Eusuarios usuario = new Eusuarios();
        ETransactionResult result;
        public Usuarios()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(validar())
            {
                usuario = new Eusuarios();

                usuario.usuario = txtUser.Text;
                usuario.passwd = txtPassword.Text;
                usuario.nombre = txtName.Text;
                usuario.apellidoP = txtApellidoP.Text;
                usuario.apellidoM = txtApellidoM.Text;
                usuario.estatus = chkEstado.Checked;
                usuario.roll = (cboRol.Text == "Administrador" ? "ADMIN" : "CAJA");

                try
                {

                    if (!nuevo)
                    {
                        _usuarios.Update(usuario, ref result);
                    }
                    else
                    {
                        _usuarios.Insert(usuario, ref result);
                    }

                    if (result.result != 0)
                        throw new Exception(result.message);

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al guardar el registro: " + ex.Message + " " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
        private bool validar()
        {
            bool bandera = true;
            StringBuilder mensaje = new StringBuilder();

            if(string.IsNullOrEmpty(txtUser.Text))
            {
                mensaje.Append("\n No se ha ingresado usuario.");
                bandera = false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                mensaje.Append("\n No se ha ingresado password.");
                bandera = false;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                mensaje.Append("\n No se ha ingresado nombre.");
                bandera = false;
            }

            if (string.IsNullOrEmpty(txtApellidoP.Text))
            {
                mensaje.Append("\n No se ha ingresado Apellido Paterno.");
                bandera = false;
            }

            if (string.IsNullOrEmpty(txtApellidoM.Text))
            {
                mensaje.Append("\n No se ha ingresado Apellido Materno.");
                bandera = false;
            }

            if(!bandera)
                MessageBox.Show(mensaje.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return bandera;

        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            if (!nuevo)
            {
                txtUser.Enabled = false;

                usuario.usuario = user;
                usuario = (Eusuarios)_usuarios.Get(usuario, ref result);

                if (result.result == 0)
                {
                    txtUser.Text = usuario.usuario;
                    txtPassword.Text = usuario.passwd;
                    txtName.Text = usuario.nombre;
                    txtApellidoP.Text = usuario.apellidoP;
                    txtApellidoM.Text = usuario.apellidoM;
                    chkEstado.Checked = (bool)usuario.estatus;
                    cboRol.SelectedText = (usuario.roll == "ADMIN") ? "Administrador" : "Cajero";
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
