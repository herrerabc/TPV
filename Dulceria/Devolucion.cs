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
    public partial class Devolucion : Form
    {
        IVenta _venta = new LVenta();
        
        int ticket = 0;

        public Devolucion()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            
            var numeric = int.TryParse(txtTicket.Text, out ticket);

            if(numeric)
            {
                ETransactionResult result = null;
                EImpresion item = new EImpresion();

                
                var encabezado = _venta.getEncTicket(new Eticket { idTicket = ticket }, ref result);

                if (encabezado != null)
                {
                    if(encabezado.cancelado)
                    {
                        MessageBox.Show("Este Ticket ya se encuentra cancelado.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro el ticket " + txtTicket.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                item = _venta.GetTicketVenta(ticket, ref result);

                if(result.result != 0)
                {
                    MessageBox.Show("Error al consultar el ticket " + ticket.ToString() + ":" + result.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(item.idTicket != 0)
                {
                    txtObservacion.Enabled = true;
                    btnCancelar.Enabled = true;

                    txtTicket.Text = string.Empty;
                    txtFecha.Text = item.fecha.ToString();
                    txtUsuario.Text = item.usuario.ToUpper();
                    txtTotal.Text = item.detalle.Sum(x => Math.Round(x.total, 2, MidpointRounding.AwayFromZero)).ToString();

                    var lista = item.detalle.Select(x => new {
                        CodigoDeBarrras = x.codigoBarras,
                        Cantidad = x.cantidad,
                        Descripcion = x.descripcion,
                        PrecioUnitario = x.precio,
                        Total = x.total
                    }).ToList();

                    dgTicket.DataSource = null;
                    dgTicket.DataSource = lista.ToList();

                }
                else
                {
                    MessageBox.Show("No se encontro el ticket "+txtTicket.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se ha ingresado un ticket valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Devolucion_Load(object sender, EventArgs e)
        {
            btnCancelar.Enabled = false;
            txtObservacion.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro de cancelar este ticket?.", "Cancelación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                if(string.IsNullOrEmpty(txtObservacion.Text))
                {
                    MessageBox.Show("Debe ingresar un motivo de cancelación.");
                    return;
                }

                ETransactionResult result = null;
                var encabezado = _venta.getEncTicket(new Eticket { idTicket = ticket }, ref result);

                encabezado.cancelado = true;
                encabezado.observacion = txtObservacion.Text;

                _venta.CancelaVenta(encabezado, ref result);

                if(result.result !=0)
                {
                    MessageBox.Show("Error al cancelar el ticket " + ticket.ToString() + ":" + result.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Se ha cancelado el ticket correctamente, asegurece que la mercancia devuelta se encuentre en buen estado.");


                    txtFecha.Text = string.Empty;
                    txtTotal.Text = string.Empty;
                    txtUsuario.Text = string.Empty;
                    txtObservacion.Text = string.Empty;
                    dgTicket.DataSource = null;

                    btnCancelar.Enabled = false;
                    txtObservacion.Enabled = false;
                }

            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
