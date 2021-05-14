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
    public partial class gridProductos : Form
    {
        ICatalogos _productos = new LProductos();
        List<Eproductos> productos = null;
        public string usuario = "";
        public gridProductos()
        {
            InitializeComponent();
        }

        private void gridProductos_Load(object sender, EventArgs e)
        {            
            llenagrid();            
        }
        private void llenagrid()
        {
            ETransactionResult result = new ETransactionResult();
            productos = _productos.GetAll(ref result).Cast<Eproductos>().ToList();

            dgProductos.DataSource = null;
            dgProductos.DataSource = productos.Select(x => new
            {
                Producto = x.idProducto,
                CodigoBarras = x.codigoBarras,
                Descripcion =x.descripcion,
                Precio = x.precio,
                Existencia = x.cantidad,
                Estado = (x.estado) ? "Activo" : "Inactivo"
            }).ToList();            
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Productos prod = new Productos();
            prod.usuario = usuario;

            DialogResult dr = prod.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                prod.Close();
            }
            else if (dr == DialogResult.OK)
            {
                llenagrid();
                prod.Close();
            }

        }

        private void dgProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Productos prod = new Productos();
            prod.usuario = usuario;
            prod.codigoProducto = Convert.ToInt32(dgProductos.Rows[e.RowIndex].Cells[0].Value.ToString());

            DialogResult dr = prod.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                prod.Close();
            }
            else if (dr == DialogResult.OK)
            {
                llenagrid();
                prod.Close();
            }                                
        }
        private void btnCodigos_Click_1(object sender, EventArgs e)
        {
            //Impresion2 imp = new Impresion2();

            //List<Model.productos> prod = new List<Model.productos>();
            //using (var con = new Model.dulceriaEntities())
            //{
            //    prod = (from x in con.productos
            //            select x).ToList();
            //}

            //imp.Run(prod, "");

            FrmCargaMasiva prod = new FrmCargaMasiva();
            prod.usuario = usuario;
            
            DialogResult dr = prod.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                llenagrid();
                prod.Close();
            }
            else if (dr == DialogResult.OK)
            {
                llenagrid();
                prod.Close();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgProductos.DataSource = null;
            var lista =
                productos.Select(x => new
                {
                    Producto = x.idProducto,
                    CodigoBarras = x.codigoBarras,
                    Descripcion = x.descripcion,
                    Precio = x.precio,
                    Existencia = x.cantidad,
                    Estado = (x.estado) ? "Activo" : "Inactivo"
                }).Where(y => (y.Descripcion.ToUpper().Contains(txtBuscar.Text.Trim().ToUpper()) || y.CodigoBarras.Trim().Contains(txtBuscar.Text.Trim().ToUpper()))).ToList();

            dgProductos.DataSource = lista;
        }

        private void btnEdicion_Click(object sender, EventArgs e)
        {
            EdicionMasiva prod = new EdicionMasiva();
            prod.usuario = usuario;
            DialogResult dr = prod.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                llenagrid();
                prod.Close();
            }
            else if (dr == DialogResult.OK)
            {
                llenagrid();
                prod.Close();
            }
        }
    }
}
