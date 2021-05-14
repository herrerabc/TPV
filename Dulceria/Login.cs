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
    public partial class Login : Form
    {
        private ICatalogos _usuarios = new LUsuarios();
        ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Login()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            Eusuarios user =null;
            ETransactionResult result = new ETransactionResult();
            user = (Eusuarios)_usuarios.Get(new Eusuarios { usuario = txt_usr.Text.Trim()}, ref result); 

            if (user != null && user.passwd == txt_passwd.Text.Trim() && user.estatus == true)
            {

                txt_usr.Clear();
                txt_passwd.Clear();

                
                this.SendToBack();
                this.Hide();

                //Principal principal = new Principal();
                //principal.cajero = user;
                //principal.Show();


                Principal Principal = new Principal();
                Principal.cajero = user;
                DialogResult dr = Principal.ShowDialog(this);

                if (dr == DialogResult.Cancel)
                {
                    Principal.Close();
                    this.BringToFront();
                    this.Show();
                }
                else if (dr == DialogResult.OK)
                {
                    Principal.Close();
                    this.BringToFront();
                    this.Show();
                }
                txt_usr.Focus();
            }
            else
            {
                //Log.Error("Error de inicio de sesión: Ususario o Password incorrecto " + result.message);
                txt_usr.Clear();
                txt_passwd.Clear();
                txt_usr.Focus();
                MessageBox.Show("Usuario ó contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txt_usr.Focus();
        }

        private void txt_passwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btn_aceptar.PerformClick();
            }
        }
    }
}
