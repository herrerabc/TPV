using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using Dulceria.Logica;
using Dulceria.Entidades;
using System.Configuration;

namespace Dulceria
{
    public partial class Bascula : Form
    {
        SerialPort puerto = null;
        public string codigoBarras = "";
        public string cantidaKG = "";
        private bool _pesar = true;
        ICatalogos _productos = new LProductos();
        public Bascula()
        {
            InitializeComponent();
        }

        private void Bascula_Load(object sender, EventArgs e)
        {
            llenaCombo();            
            //Task.Run(() => iniciatimer());
        }
       private void llenaCombo()
        {
            ETransactionResult result = new ETransactionResult();
            List<Eproductos> productos = _productos.GetAll(ref result).Cast<Eproductos>().Where(x => x.idUnidad == 1 && x.estado == true).ToList();

            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = productos.Select(p => new { Id = p.idProducto, Descripcion = p.descripcion }).OrderBy(x=> x.Descripcion).ToList();
        
        }          
        
        private void conectar()
        {   
            try
            {
                string portName, dataBits, parity, stop, bitsSecond;

                portName = ConfigurationManager.AppSettings["PortName"].ToString();
                bitsSecond = ConfigurationManager.AppSettings["BitsSecond"].ToString();
                parity = ConfigurationManager.AppSettings["Parity"].ToString();
                dataBits = ConfigurationManager.AppSettings["DataBits"].ToString();
                stop = ConfigurationManager.AppSettings["StopBits"].ToString();
                
                puerto = new SerialPort();

                puerto.PortName = portName;
                puerto.BaudRate = int.Parse(bitsSecond);
                puerto.DataBits = int.Parse(dataBits);

                switch (parity)
                {
                    case "Even":
                        puerto.Parity = Parity.Even;
                        break;
                    case "Odd":
                        puerto.Parity = Parity.Odd;
                        break;
                    case "None":
                        puerto.Parity = Parity.None;
                        break;
                    case "Mark":
                        puerto.Parity = Parity.Mark;
                        break;
                    case "Space":
                        puerto.Parity = Parity.Space;
                        break;
                }

                switch (stop)
                {
                    case "1":
                        puerto.StopBits = StopBits.One;
                        break;
                    case "1.5":
                        puerto.StopBits = StopBits.OnePointFive;
                        break;
                    case "2":
                        puerto.StopBits = StopBits.Two;
                        break;
                }
                /* Para la impresora de Chayo*/
                puerto.Handshake = Handshake.None;                
                puerto.ReadTimeout = 900;
                puerto.WriteTimeout = 900;
                /****************************/

                if (puerto.IsOpen) puerto.Close();

                //abrimos el puerto
                puerto.Open();


                CheckForIllegalCrossThreadCalls = false;

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Capa datos. Error estableciendo la conexion."  + ex.Message);
            }
        }
        private bool Desconectar()
        {
            try
            {
                if (puerto.IsOpen) puerto.Close();

                
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Capa datos. Error cerrando la conexión de puerto serie." + ex.Message);
            }
            return true;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            calcular();
        }
        
        public void iniciatimer()
        {
            while (_pesar)
            {
                calcular();
                Thread.Sleep(1000);
            }
        }
        public void calcular()
        {
            string x = "";

            conectar();
            if (puerto.IsOpen)
            {
                puerto.Write("P");
                bool _continuar = true;
                ETransactionResult result = new ETransactionResult();
                while (_continuar)
                {
                    x = puerto.ReadExisting();
                    if (x.Trim().Length > 0) _continuar = false;
                }
                Desconectar();
                x = (x.Trim().Length == 0) ? "0" : x.Trim();

                lblGramaje.Text = x.Trim();

                //x = x.ToUpper().Replace("KG", "").Trim();
                x = x.ToUpper().Replace("K", "").Trim();
                x = x.ToUpper().Replace("G", "").Trim();
                decimal cantidad = Convert.ToDecimal(x);

                int idprod = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                var producto = (Eproductos)_productos.Get(new Eproductos { idProducto = idprod }, ref result);


                lblPrecio.Text = "$ "+ Math.Round((cantidad * producto.precio), 2, MidpointRounding.AwayFromZero).ToString();
            }
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _pesar = false;
            int idprod = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            ETransactionResult result = new ETransactionResult();
            var producto = (Eproductos)_productos.Get(new Eproductos { idProducto = idprod }, ref result);

            codigoBarras = producto.codigoBarras;

            string x = "";
            x = lblGramaje.Text.ToUpper().Replace("K", "").Trim();
            x = x.ToUpper().Replace("G", "").Trim();

            cantidaKG = (Convert.ToDecimal(x)).ToString();            
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pesar = false;
            Thread.Sleep(1000);
            _pesar = true;
            Task.Run(() => iniciatimer());
        }
    }
}
