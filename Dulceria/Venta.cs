using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Dulceria.Entidades;
using Dulceria.Logica;

namespace Dulceria
{
    public partial class Venta : Form
    {
        ICatalogos _productos = new LProductos();
        IVenta _venta = new LVenta();
        ETransactionResult result = null;
        SerialPort puerto = null;
        private List<ETicketVenta> venta = new List<ETicketVenta>();
        public Eproductos busqueda = new Eproductos();
        public string usuario = "";
        public string nombre = "";

        public Venta()
        {
            InitializeComponent();
        }

       
        private void Venta_Load(object sender, EventArgs e)
        {
            Limpiar();
            txt_producto.Focus();
        }
        
        private void txt_producto_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)13)
            {
                if(string.IsNullOrEmpty(txtCantidad.Text.Trim()))
                {
                    txtCantidad.Text = "1";
                }
                
                setVenta(txt_producto.Text);
                txt_producto.Text = string.Empty;
                txtCantidad.Text = "1";
            }
        }
        private void setVenta(string producto)
        {
            ETicketVenta item = new ETicketVenta();
            decimal cantidad = getCantidad(producto);
            var prod = _productos.GetAll(ref result).Cast<Eproductos>().ToList();


            item = (from vta in prod
                    where vta.codigoBarras == producto.Trim() && vta.estado == true
                    select new ETicketVenta()
                    {
                        Producto = vta.idProducto
                        ,
                        Descripcion = vta.descripcion
                        ,
                        Cantidad = cantidad
                        ,
                        Iva = 0
                        ,
                        Precio = vta.precio
                        ,
                        Total = vta.precio * cantidad //vta.idUnidad == 1 ? ((cantidad / 1000) * vta.precio) : (vta.precio * cantidad)
                        }).FirstOrDefault();

            if(item != null)venta.Add(item);

            
            venta = (from vta in venta
                     group vta by new { id = vta.Producto, des = vta.Descripcion, precio = vta.Precio } into gs
                     select new ETicketVenta()
                     {
                         Producto = gs.Key.id
                         ,
                         Descripcion = gs.Key.des
                         ,
                         Precio = gs.Key.precio
                         ,
                         Iva = 0
                         ,
                         Cantidad = gs.Sum(a => a.Cantidad)
                         ,
                         Total = gs.Sum(a => a.Total)
                     }).ToList();

            dtVenta.DataSource = null;
            dtVenta.DataSource = venta.ToList();
            txtTotal.Text = Math.Round(venta.Sum(p => (decimal)p.Total), 2, MidpointRounding.AwayFromZero).ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (venta.Count > 0)
            {
                
                if (_venta.SetVenta(venta, usuario, ref result))
                {
                    //MessageBox.Show("La venta se genero exitosamente.", "Venta", MessageBoxButtons.OK, MessageBoxIcon.None);
                    var imp = _venta.GetUltimoTicket(ref result);
                    PrintReport(imp);
                    MessageBox.Show("La venta se genero exitosamente.", "Venta", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Limpiar();

                }
                else
                {
                    MessageBox.Show("La venta tuvo error al generarse, intente nuevamente." + result.message, "Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PrintReport(EImpresion item)
        {
            Impresion imp = new Impresion();
            imp.Run(item, false);
        }

        private void linkProducto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BuscaProductos frm = new BuscaProductos();
            frm.ShowDialog(this);
            txt_producto.Text = frm.codigoBarras;
            txt_producto.Focus();
            SendKeys.Send("{ENTER}");
        }

        private decimal getCantidad(string producto)
        {
            decimal cantidad = 0;
            cantidad = Convert.ToDecimal(txtCantidad.Text);
            return cantidad;           
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Bascula bas = new Bascula();
            bas.ShowDialog(this);            
            txtCantidad.Text = bas.cantidaKG;
            txt_producto.Text = bas.codigoBarras;
            bas.Dispose();        
            txt_producto.Focus();
            SendKeys.Send("{ENTER}");
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            venta.Clear();
            dtVenta.DataSource = null;
            
            txt_producto.Focus();
            txtCantidad.Text = "1";
            txtIva.Text = "0";
            txt_producto.Text = "";
            txtTotal.Text = "0";
        }

        private void dtVenta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int producto = 0;
            string descripcion = "";
            DialogResult respuesta;
            producto = Convert.ToInt32(dtVenta.Rows[e.RowIndex].Cells["Producto"].Value.ToString());
            descripcion = dtVenta.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();

            respuesta = MessageBox.Show("¿Desea eliminar el producto: " + descripcion + " de esta venta?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                dtVenta.DataSource = null;

                venta = (from x in venta
                              where x.Producto != producto
                              select x).ToList();

                dtVenta.DataSource = venta.ToList();
                txtTotal.Text = Math.Round(venta.Sum(p => (decimal)p.Total), 2, MidpointRounding.AwayFromZero).ToString();
            }
        }

    }
}
