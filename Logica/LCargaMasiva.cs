using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;
using System.IO;
using Dulceria.Entidades;
using Dulceria.AccesoDatos;

namespace Dulceria.Logica
{
    public class LCargaMasiva
    {
        Daproductos _productos = new Daproductos();
        DaunidadMedida _unidadMedida = new DaunidadMedida();
        DaMovimiento _movimiento = new DaMovimiento();
        DaMovimientoDetalle _movimientoDetalle = new DaMovimientoDetalle();

        public void SetProductos(string directorio, ref ETransactionResult res)
        {
            res = new ETransactionResult();
            List<Eproductos> prods = new List<Eproductos>();
            try
            {
                using (var reader = new StreamReader(directorio))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    prods = csv.GetRecords<Eproductos>().ToList();
                }


                Daproductos db = new Daproductos();

                var prod = db.productos_GetAll(ref res).Cast<Eproductos>().ToList();
                int maxId = 0;

                if (prod.Count != 0)
                {
                    maxId = prod.Select(x => x.idProducto).Max();
                }



                int codigoProducto = maxId + 1;

                bool bandera = false;
                StringBuilder mensaje = new StringBuilder();

                foreach(Eproductos item in prods)
                {
                    item.idProducto = codigoProducto;
                    codigoProducto++;
                }

                foreach(Eproductos item in prods)
                {
                    res = new ETransactionResult();
                    saveProducto(item, ref res);

                    if (res.result ==1)
                    {
                        bandera = true;
                        mensaje.Append("\n No se pudo guardar el producto " + item.descripcion + " :" + res.message);
                    }
                }

                res = new ETransactionResult();
                if(!string.IsNullOrEmpty(mensaje.ToString()))
                {
                    res.result = 1;
                    res.message = mensaje.ToString();
                }                                             
            }
            catch(Exception ex)
            {
                res.result = 1;
                res.message = ex.Message;
            }
        }

        private void saveProducto(Eproductos item, ref ETransactionResult res)
        {
            Daproductos db = new Daproductos();

            db.productos_Insert(item, ref res);

            if (res.result == 0)
            { 
                EMovimiento mov = new EMovimiento();
                EMovimientoDetalle detalle = new EMovimientoDetalle();
                ETransactionResult result = new ETransactionResult();
                int idDetalle = 0;
                decimal totalCantidad = 0;

                mov.fecha = DateTime.Now;
                mov.idMovimiento = (int)getIdMovimiento();
                mov.idTipoMovimiento = "EPT";
                mov.usuario = "admin";

                totalCantidad = item.cantidad;
                idDetalle = (int)getIdMovimientoDet();

                detalle.idDetalle = idDetalle;
                detalle.idMovimiento = mov.idMovimiento;
                detalle.tipoAfectacion = "E";
                detalle.idProducto = item.idProducto;
                detalle.cantidad = totalCantidad;

                _movimiento.Movimiento_Insert(mov, ref result);
                if (result.result == 0)
                {
                    _movimientoDetalle.MovimientoDetalle_Insert(detalle, ref result);
                }
            }
        }
        private int? getIdMovimiento()
        {
            ETransactionResult result = new ETransactionResult();
            var lista = _movimiento.Movimiento_GetAll(ref result).Cast<EMovimiento>().ToList();

            int maxid = 0;

            if(lista.Count != 0)
            {
               maxid = lista.Select(x => x.idMovimiento).Max();
            }
            maxid = maxid + 1;
            return maxid;
        }
        private int? getIdMovimientoDet()
        {
            ETransactionResult result = new ETransactionResult();

            var lista = _movimientoDetalle.MovimientoDetalle_GetAll(ref result).Cast<EMovimientoDetalle>().ToList();
            int maxid = 0;

            if (lista.Count != 0)
            {
                maxid = lista.Select(x => x.idDetalle).Max();
            }
            maxid = maxid + 1;
            return maxid;
        }
        public void GetCsv()
        {
            using (var reader = new StreamWriter(@"c:\backup"))
            using (var csv = new CsvWriter(reader, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<Eproductos>();
            }

        }
    }
}
