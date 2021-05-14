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
using log4net;

namespace Dulceria
{
    public partial class Productos : Form
    {
        ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public int ?codigoProducto = 0;
        private bool cambio = false;
        private decimal cantidadInicial = 0;
        public string usuario ="";
        ICatalogos _productos = new LProductos();
        ICatalogos _unidadMedida = new LUnidadMedida();
        ICatalogos _movimiento = new LMovimiento();
        ICatalogos _movimientoDetalle = new LMovimientoDetalle();
        
        public Productos()
        {
            InitializeComponent();
        }
        private void Productos_Load(object sender, EventArgs e)
        {
            if(codigoProducto == 0)
            {
                btnQD.Visible = false;
                nuevoproducto();
            }
            else
            {
                cambio = true;
                llenaPnatalla();
                btnQD.Visible = true;
            }
        }
        private void llenaPnatalla()
        {
            ETransactionResult result = new ETransactionResult();
            Eproductos prod = (Eproductos)_productos.Get(new Eproductos { idProducto = int.Parse(codigoProducto.ToString()) }, ref result);
            List<EunidadMedida> unidadMedida = _unidadMedida.GetAll(ref result).Cast<EunidadMedida>().ToList();

            cboUnidad.DisplayMember = "Descripcion";
            cboUnidad.ValueMember = "Id";
            cboUnidad.DataSource = unidadMedida.Select(p => new { Id = p.idUnidad, Descripcion = p.descripcion }).ToList();

            txtDescripcion.Text = prod.descripcion;
            txtCodigoBarras.Text = prod.codigoBarras;
            txtPrecio.Text = prod.precio.ToString();
            txtPrecioReal.Text = prod.precioReal.ToString();
            txtCantidad.Text = prod.cantidad.ToString();
            cantidadInicial = prod.cantidad;
            cboUnidad.SelectedValue = prod.idUnidad;
            chkEstado.Checked = prod.estado;
          
            txtIdProd.Text = codigoProducto.ToString();
        }
        private void nuevoproducto()
        {
            ETransactionResult result = new ETransactionResult();
            List<EunidadMedida> unidadMedida = _unidadMedida.GetAll(ref result).Cast<EunidadMedida>().ToList();
            var prod = _productos.GetAll(ref result).Cast<Eproductos>().ToList();

            int maxId = 0;

            if (prod.Count != 0)
            {
                maxId = prod.Select(x => x.idProducto).Max();
            }    
                  
            codigoProducto = maxId + 1;

            cboUnidad.DisplayMember = "Descripcion";
            cboUnidad.ValueMember = "Id";
            cboUnidad.DataSource = unidadMedida.Select(p => new { Id = p.idUnidad, Descripcion = p.descripcion }).ToList();

            txtIdProd.Text = codigoProducto.ToString();
            
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                if (!((e.KeyChar == (char)46)))
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        private void msjValida()
        {
            MessageBox.Show("Todos los campos deben de llenarse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == string.Empty)
            {
                msjValida();
                txtDescripcion.Focus();
                return;
            }
            if (txtCodigoBarras.Text == string.Empty)
            {
                msjValida();
                txtCodigoBarras.Focus();
                return;
            }
            if (txtPrecio.Text == string.Empty)
            {
                msjValida();
                txtPrecio.Focus();
                return;
            }

            if (txtPrecioReal.Text == string.Empty)
            {
                msjValida();
                txtPrecioReal.Focus();
                return;
            }

            if (txtCantidad.Text ==string.Empty)
            {
                msjValida();
                txtCantidad.Focus();
                return;
            }
            if (cboUnidad.SelectedIndex  == -1)
            {
                msjValida();
                cboUnidad.Focus();
                return;
            }
            try
            {
                ETransactionResult result = new ETransactionResult();
                Eproductos prod = new Eproductos();

                prod.idProducto = Convert.ToInt32(txtIdProd.Text);
                prod.idUnidad = Convert.ToInt32(cboUnidad.SelectedValue.ToString());
                prod.descripcion = txtDescripcion.Text;
                prod.codigoBarras = txtCodigoBarras.Text;
                prod.precio = Convert.ToDecimal(txtPrecio.Text);
                prod.precioReal = Convert.ToDecimal(txtPrecioReal.Text);
                prod.cantidad = Convert.ToDecimal(txtCantidad.Text);
                prod.estado = chkEstado.Checked;

                if (cambio)
                {
                    _productos.Update(prod, ref result);
                }
                else
                {
                    _productos.Insert(prod, ref result);    
                }

                if (result.result != 0)
                    throw new Exception(result.message);

                setMovimiento();
                MessageBox.Show("Se guardo el cambio correctamente.","Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                Log.Error("Error al guardar producto", ex);
                MessageBox.Show("Error al guardar el cambio: " + ex.Message + " " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }
        //private void btnEliminar_Click(object sender, EventArgs e)
        //{

        //    if (txtDescripcion.Text == string.Empty)
        //    {
        //        msjValida();
        //        txtDescripcion.Focus();
        //        return;
        //    }
        //    if (txtCodigoBarras.Text == string.Empty)
        //    {
        //        msjValida();
        //        txtCodigoBarras.Focus();
        //        return;
        //    }
        //    if (txtPrecio.Text == string.Empty)
        //    {
        //        msjValida();
        //        txtPrecio.Focus();
        //        return;
        //    }
        //    if (txtCantidad.Text == string.Empty)
        //    {
        //        msjValida();
        //        txtCantidad.Focus();
        //        return;
        //    }
        //    if (cboUnidad.SelectedIndex == -1)
        //    {
        //        msjValida();
        //        cboUnidad.Focus();
        //        return;
        //    }
        //    try
        //    {
        //        ETransactionResult result = new ETransactionResult();
        //        Eproductos prod = new Eproductos();

        //        prod.idProducto = Convert.ToInt32(txtIdProd.Text);

        //        if (cambio)
        //        {
        //            _productos.Delete(prod, ref result);
        //        }

        //        if (result.result != 0)
        //            throw new Exception(result.message);
        //        //setMovimiento();

        //        MessageBox.Show("Se Elimino el producto correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al eliminar el producto: " + ex.Message + " " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    this.DialogResult = DialogResult.OK;
        //    Close();

        //}
        public void setMovimiento()
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

            totalCantidad = Convert.ToDecimal(txtCantidad.Text) - cantidadInicial;
            idDetalle = (int)getIdMovimientoDet();            

            detalle.idDetalle = idDetalle;
            detalle.idMovimiento = mov.idMovimiento;
            detalle.tipoAfectacion = (totalCantidad < 0 ? "S" : "E");
            detalle.idProducto = Convert.ToInt32(txtIdProd.Text);
            detalle.cantidad = Math.Abs(totalCantidad);

            _movimiento.Insert(mov, ref result);
            if (result.result == 0)
            {
                _movimientoDetalle.Insert(detalle, ref result);

                if(result.result!=0)
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

        private void cboUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            var select = int.Parse(cboUnidad.SelectedValue.ToString());
            if (select == 1)
            {
                lblUnidad.Text = "KG";
            }
            else if (select == 2)
            {
                lblUnidad.Text = "Piezas";
            }
            else if (select == 3)
            {
                lblUnidad.Text = "Litros";
            }
            else if (select == 4)
            {
                lblUnidad.Text = "Metros";
            }

        }

        private void txtPrecioReal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                if (!((e.KeyChar == (char)46)))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void btnQD_Click(object sender, EventArgs e)
        {
            Impresion imp = new Impresion();
            ETransactionResult result = new ETransactionResult();
            Eproductos item = new Eproductos() { idProducto = int.Parse(txtIdProd.Text.Trim()) };
            item = (Eproductos)_productos.Get(item, ref result);

            imp.ImpQrProd(item);
        }
    }
}
