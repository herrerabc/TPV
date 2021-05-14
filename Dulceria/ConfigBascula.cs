using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dulceria
{
    public partial class ConfigBascula : Form
    {
        public ConfigBascula()
        {
            InitializeComponent();
        }

        private void ConfigBascula_Load(object sender, EventArgs e)
        {
            cboPortName.DataSource = SerialPort.GetPortNames();
            cboDataBits.DataSource = new string[] {"4","5","6","7","8"};
            cboParity.DataSource = new string[] { "Even", "Odd", "None", "Mark", "Space" };
            cboStop.DataSource = new string[] { "1", "1.5", "2" };
            cboBitSecond.DataSource = new string[] { "75", "110", "134", "150", "300", "600", "1200", "1800", "2800", "4800", "7200", "9600", "14400" };

            string portName, dataBits, parity, stop, bitsSecond;

            portName = ConfigurationManager.AppSettings["PortName"].ToString();
            bitsSecond = ConfigurationManager.AppSettings["BitsSecond"].ToString();
            parity = ConfigurationManager.AppSettings["Parity"].ToString();
            dataBits = ConfigurationManager.AppSettings["DataBits"].ToString();
            stop = ConfigurationManager.AppSettings["StopBits"].ToString();

            if(!string.IsNullOrEmpty(portName))
                cboPortName.SelectedItem = portName;

            if (!string.IsNullOrEmpty(bitsSecond))
                cboBitSecond.SelectedItem = bitsSecond;

            if (!string.IsNullOrEmpty(parity))
                cboParity.SelectedItem = parity;

            if (!string.IsNullOrEmpty(dataBits))
                cboDataBits.SelectedItem = dataBits;

            if (!string.IsNullOrEmpty(stop))
                cboStop.SelectedItem = stop;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["PortName"].Value = cboPortName.SelectedValue.ToString();
                config.AppSettings.Settings["BitsSecond"].Value = cboBitSecond.SelectedValue.ToString();
                config.AppSettings.Settings["Parity"].Value = cboParity.SelectedValue.ToString();
                config.AppSettings.Settings["DataBits"].Value = cboDataBits.SelectedValue.ToString();
                config.AppSettings.Settings["StopBits"].Value = cboStop.SelectedValue.ToString(); 
                config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");

                MessageBox.Show("Se han actualizado los parametros correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.None);

                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los parametros: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
