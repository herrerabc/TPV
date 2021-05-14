using Dulceria.Entidades;
using Dulceria.Logica;
using log4net;
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
    public partial class FrmCargaMasiva : Form
    {
        ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        int codigoProducto = 0;
        public string usuario = "";
        ICatalogos _productos = new LProductos();
        ICatalogos _Unidad = new LUnidadMedida();        
        ICatalogos _movimiento = new LMovimiento();
        ICatalogos _movimientoDetalle = new LMovimientoDetalle();

        public FrmCargaMasiva()
        {
            InitializeComponent();
        }

        private void FrmCargaMasiva_Load(object sender, EventArgs e)
        {
            ETransactionResult result = new ETransactionResult();
            var prod = _productos.GetAll(ref result).Cast<Eproductos>().ToList();
            var unidad = _Unidad.GetAll(ref result).Cast<EunidadMedida>().ToList();

            int maxId = 0;

            if (prod.Count != 0)
            {
                maxId = prod.Select(x => x.idProducto).Max();
            }

            codigoProducto = maxId + 1;

            var items = new List<Eproductos>() { new Eproductos { idProducto = codigoProducto } };
            this.idUnidadDataGridViewTextBoxColumn.DataSource = unidad;
            //dataGridView1.DataSource = items;

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!DgProductos.Rows[e.RowIndex].IsNewRow)
            {
                string valor = e.FormattedValue.ToString();
                decimal val = 0;
                // 4. Precio, 5. Precio Real, 6. Cantidad
                if (e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6)
                {
                    if (!decimal.TryParse(valor, out val))
                    {
                        MessageBox.Show("No se ha ingresado un valor numerico.");
                        DgProductos.Rows[e.RowIndex].ErrorText = "No se ha ingresado un valor numerico.";
                        e.Cancel = true;
                    }

                    if (val < 0)
                    {
                        MessageBox.Show("No se ha ingresado un valor positivo.");
                        DgProductos.Rows[e.RowIndex].ErrorText = "No se ha ingresado un valor positivo.";
                        e.Cancel = true;
                    }
                }
                if (e.ColumnIndex == 1)// Unidad de medida
                {
                    val = 0;

                    if (string.IsNullOrEmpty(valor))
                    {
                        MessageBox.Show("Debe seleccionar una unidad de medida.");
                        DgProductos.Rows[e.RowIndex].ErrorText = "Debe seleccionar una unidad de medida.";
                        e.Cancel = true;
                    }
                }

                if (e.ColumnIndex == 2 || e.ColumnIndex == 3)// 2. Producto 3. Codigo de barras
                {
                    val = 0;

                    if (string.IsNullOrEmpty(valor))
                    {
                        MessageBox.Show("El este campo no puede ir vacio.");
                        DgProductos.Rows[e.RowIndex].ErrorText = "El este campo no puede ir vacio.";
                        e.Cancel = true;
                    }

                    if (e.ColumnIndex == 3 && !decimal.TryParse(valor, out val))
                    {
                        MessageBox.Show("El codigo de barras debe ser un valor númerico.");
                        DgProductos.Rows[e.RowIndex].ErrorText = "El codigo de barras debe ser un valor númerico.";
                        e.Cancel = true;
                    }

                }
            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (DgProductos[0, e.RowIndex].Value == null || (int)DgProductos[0, e.RowIndex].Value == 0)
            {
                DgProductos[0, e.RowIndex].Value = codigoProducto;
                codigoProducto++;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var lista = getLista();
            ETransactionResult result = new ETransactionResult();
            string msg = string.Empty;

            foreach (Eproductos item in lista)
            {
                _productos.Update(item, ref result);
                if (result.result != 0)
                {
                    msg += "\n Error al actualizar el producto: " + item.descripcion + " - " + result.message;
                    Log.Error(msg);
                }
            }

            if (!string.IsNullOrEmpty(msg))
            {
                foreach (Eproductos item in lista)
                {
                    _productos.Delete(item, ref result);
                }

                MessageBox.Show(msg, "Error al guardar productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                lista.ForEach(x => setMovimiento(x));

                MessageBox.Show("Se actualizarón los datos correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }
        private List<Eproductos> getLista()
        {
            List<Eproductos> productos = new List<Eproductos>();
            foreach (DataGridViewRow item in DgProductos.Rows)
            {
                if (item.Cells[1].Value != null)
                {
                    if ((int)item.Cells[1].Value != 0)
                    {
                        Eproductos prods = new Eproductos();

                        prods.idProducto = (int)item.Cells[0].Value;
                        prods.idUnidad = (int)item.Cells[1].Value;
                        prods.descripcion = (string)item.Cells[2].Value;
                        prods.codigoBarras = (string)item.Cells[3].Value;
                        prods.precio = decimal.Parse(item.Cells[4].Value.ToString());
                        prods.precioReal = decimal.Parse(item.Cells[5].Value.ToString());
                        prods.cantidad = decimal.Parse(item.Cells[6].Value.ToString());
                        prods.estado = (bool)item.Cells[7].Value;

                        productos.Add(prods);
                    }
                }
            }

            return productos;
        }

        private void setMovimiento(Eproductos item)
        {
            EMovimiento mov = new EMovimiento();
            EMovimientoDetalle detalle = new EMovimientoDetalle();
            ETransactionResult result = new ETransactionResult();
            int idDetalle = 0;
            decimal totalCantidad = 0;

            mov.fecha = DateTime.Now;
            mov.idMovimiento = (int)getIdMovimiento();
            mov.idTipoMovimiento = "EPT";
            mov.usuario = usuario;
            mov.observacion = "";

            totalCantidad = item.cantidad;
            idDetalle = (int)getIdMovimientoDet();

            detalle.idDetalle = idDetalle;
            detalle.idMovimiento = mov.idMovimiento;
            detalle.tipoAfectacion = (totalCantidad < 0 ? "S" : "E");
            detalle.idProducto = item.idProducto;
            detalle.cantidad = Math.Abs(totalCantidad);

            _movimiento.Insert(mov, ref result);
            if (result.result == 0)
            {
                _movimientoDetalle.Insert(detalle, ref result);

                if (result.result != 0)
                    Log.Error("Error al insertar detalle movimiento: " + result.message);
            }
            else
                Log.Error("Error al insertar movimiento: " + result.message);

        }
        private int? getIdMovimiento()
        {
            ETransactionResult result = new ETransactionResult();
            var lista = _movimiento.GetAll(ref result).Cast<EMovimiento>().ToList();

            int maxid = 0;

            if (lista.Count != 0)
            {
                maxid = lista.Select(x => x.idMovimiento).Max();
            }
            maxid = maxid + 1;
            return maxid;
        }
        private int? getIdMovimientoDet()
        {
            ETransactionResult result = new ETransactionResult();

            var lista = _movimientoDetalle.GetAll(ref result).Cast<EMovimientoDetalle>().ToList();
            int maxid = 0;

            if (lista.Count != 0)
            {
                maxid = lista.Select(x => x.idDetalle).Max();
            }
            maxid = maxid + 1;
            return maxid;
        }
    }
}
