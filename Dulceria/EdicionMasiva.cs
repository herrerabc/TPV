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
using log4net;

namespace Dulceria
{
    public partial class EdicionMasiva : Form
    {
        ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        LProductos _prods = new LProductos();
        ICatalogos _unidadMedida = new LUnidadMedida();
        ICatalogos _movimiento = new LMovimiento();
        ICatalogos _movimientoDetalle = new LMovimientoDetalle();
        public string usuario = "";

        public EdicionMasiva()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EdicionMasiva_Load(object sender, EventArgs e)
        {
            List<Eproductos> items = new List<Eproductos>();

            ETransactionResult _result = new ETransactionResult();
            items = _prods.GetAll(ref _result).Cast<Eproductos>().ToList();

            dataGridView1.DataSource = items;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            List<Eproductos> products = (List<Eproductos>)dataGridView1.DataSource;
            List<Eproductos> items = new List<Eproductos>();
            ETransactionResult _result = new ETransactionResult();
            items = _prods.GetAll(ref _result).Cast<Eproductos>().ToList();
            StringBuilder message = new StringBuilder();


            var UpItems = (from grid in products
                           join it in items on grid.idProducto equals it.idProducto
                           where  (it.cantidad != grid.cantidad || it.codigoBarras != grid.codigoBarras
                           || it.precio != grid.precio || it.precioReal != grid.precioReal)
                           select grid).ToList();

            //Validaciones
            foreach (Eproductos item in UpItems)
            {
                string error = string.Empty;
                error = validaProducto(item);
                if (!string.IsNullOrEmpty(error))
                    message.Append(error);
            }

            if (!string.IsNullOrEmpty(message.ToString()))
            {
                MessageBox.Show(message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ETransactionResult result = new ETransactionResult();
                string msg = string.Empty;

                var UpCantidad = (from grid in UpItems
                                   join it in items on grid.idProducto equals it.idProducto
                                   where it.cantidad != grid.cantidad
                                   select grid).ToList();
                
                foreach(Eproductos item in UpItems)
                {
                    _prods.Update(item, ref result);
                    if(result.result != 0)
                    {
                        msg += "\n Error al actualizar el producto: "+ item.descripcion+ " - " + result.message;
                        Log.Error(msg);
                    }
                }

                UpCantidad.ForEach(x => setMovimiento((items.First(y => y.idProducto == x.idProducto).cantidad), x));

                if (!string.IsNullOrEmpty(msg))
                {
                    MessageBox.Show(msg, "Error al guardar productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Se actualizarón los datos correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }


        }
        private string validaProducto(Eproductos item)
        {
            string validacion = string.Empty;

            if (string.IsNullOrEmpty(item.descripcion))
            {
                validacion += "\n La descripción del producto " + item.idProducto.ToString() + " no puede ir vacia.";
            }
            if (string.IsNullOrEmpty(item.codigoBarras))
            {
                validacion += "\n El Codigo de Barras del producto " + item.idProducto.ToString() + " no puede ir vacio.";
            }

            return validacion;
        }
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                // 4. Precio, 5. Precio Real, 6. Cantidad
                if (e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6)
                {
                    string valor = e.FormattedValue.ToString();
                    decimal val = 0;

                    if (!decimal.TryParse(valor, out val))
                    {
                        MessageBox.Show("No se ha ingresado un valor numerico.");
                        dataGridView1.Rows[e.RowIndex].ErrorText = "No se ha ingresado un valor numerico.";
                        e.Cancel = true;
                    }

                    if (val < 0)
                    {
                        MessageBox.Show("No se ha ingresado un valor positivo.");
                        dataGridView1.Rows[e.RowIndex].ErrorText = "No se ha ingresado un valor positivo.";
                        e.Cancel = true;
                    }                    
                }                
            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void setMovimiento(decimal cantidadInicial, Eproductos item)
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

            totalCantidad = item.cantidad - cantidadInicial;
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
