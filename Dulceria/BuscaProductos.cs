using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dulceria.Entidades;
using Dulceria.Logica;

namespace Dulceria
{    
    public partial class BuscaProductos : Form
    {
        ICatalogos _productos = new LProductos();
        ICatalogos _unidad = new LUnidadMedida();
        ETransactionResult result = null;
        List<Eproductos> productos = null;
        List<EunidadMedida> unidades = new List<EunidadMedida>();

        public string codigoBarras = "";
        public BuscaProductos()
        {
            InitializeComponent();
        }

        private void BuscaProductos_Load(object sender, EventArgs e)
        {
            var lista = _productos.GetAll(ref result);
            productos = lista.Cast<Eproductos>().Where(y=> y.estado == true).OrderBy(x => x.descripcion).ToList();
            unidades = _unidad.GetAll(ref result).Cast<EunidadMedida>().ToList();

            var ds = productos.Join(unidades, a => a.idUnidad, b => b.idUnidad, (a, b) => new {
                CodigoBarras = a.codigoBarras,
                Producto = a.descripcion,
                Existencia = a.cantidad,
                Unidad = b.descripcion,
                PrecioUnitario = a.precio,
                Estado = a.estado ? "Activo" : "Inactivo"
            }).ToList();

            DGBusqueda.DataSource = ds;
        }


        private void DGBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal cantidad = 0;

            decimal.TryParse(DGBusqueda.Rows[e.RowIndex].Cells["Existencia"].Value.ToString(), out cantidad);

            if(cantidad == 0)
            {
                MessageBox.Show("No hay existencia del producto seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            codigoBarras = DGBusqueda.Rows[e.RowIndex].Cells["CodigoBarras"].Value.ToString();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DGBusqueda.DataSource = null;
            result = null;
                        
            var lista = productos.Join(unidades, a => a.idUnidad, b => b.idUnidad, (a, b) => new {
                CodigoBarras = a.codigoBarras,
                Producto = a.descripcion,
                Existencia = a.cantidad,
                Unidad = b.descripcion,
                PrecioUnitario = a.precio,
                Estado = a.estado ? "Activo" : "Inactivo"
            }).Where(y => y.Producto.ToUpper().Contains(textBox1.Text.Trim().ToUpper())).ToList();
            DGBusqueda.DataSource = lista;
        }
    }
}
