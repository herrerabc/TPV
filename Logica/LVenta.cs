using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dulceria.Entidades;
using Dulceria.AccesoDatos;

namespace Dulceria.Logica
{
    public class LVenta : IVenta
    {
        public bool SetVenta(List<ETicketVenta> venta, string usr, ref ETransactionResult result)
        {
            bool res = true;

            EMovimiento mov = new EMovimiento();
            Daproductos _prod = new Daproductos();
            List<EMovimientoDetalle> movdet = new List<EMovimientoDetalle>();
            int idDetalle = 0;
            mov.fecha = DateTime.Now;
            mov.idMovimiento = (int)getIdMovimiento();
            mov.idTipoMovimiento = "VTA";
            mov.observacion = "";
            mov.usuario = usr;

            idDetalle = (int)getIdMovimientoDetalle();
            foreach (ETicketVenta det in venta)
            {

                EMovimientoDetalle detalle = new EMovimientoDetalle();

                detalle.idDetalle = idDetalle;
                detalle.idMovimiento = mov.idMovimiento;
                detalle.tipoAfectacion = "S";
                detalle.idProducto = det.Producto;
                detalle.cantidad = det.Cantidad;

                idDetalle += 1;
                movdet.Add(detalle);
            }
            var prods = _prod.productos_GetAll(ref result).Cast<Eproductos>().ToList();

            var invInsuficiente = movdet.Join(prods, _mov => _mov.idProducto, _prods => _prods.idProducto,
                (_mov, _prods) => new { Cantidad = _prods.cantidad - _mov.cantidad }).Where(
                x=> x.Cantidad < 0).ToList().Count; 

            if(invInsuficiente > 0)
            {
                result.result = -1;
                result.message = "No se puede vender mas producto que el existente.";
                return false;
            }

            Eticket ticket = new Eticket();
            List<EdetalleTicket> detTic = new List<EdetalleTicket>();

            ticket.idTicket = (int)getIdTicket();
            ticket.usuario = usr;
            ticket.fecha = DateTime.Now;
            ticket.total = venta.Sum(p => p.Total);
            ticket.observacion = "";
            ticket.cancelado = false;

            idDetalle = (int)getIdTicketDet();
            foreach (ETicketVenta det in venta)
            {
                EdetalleTicket detalle = new EdetalleTicket();

                detalle.idDetalle = idDetalle;
                detalle.idTicket = ticket.idTicket;
                detalle.fecha = DateTime.Now;
                detalle.idProducto = det.Producto;
                detalle.cantidad = det.Cantidad;
                detalle.precio = det.Precio;
                detalle.total = det.Total;

                idDetalle += 1;

                detTic.Add(detalle);
            }

            var _productos = _prod.productos_GetAll(ref result);
            _productos = _productos.Join(movdet, x => x.idProducto, y => y.idProducto,
                (x, y) => x).ToList();

            if (saveTicket(ticket, ref result))
            {
                if (saveDetalleTicket(detTic, ref result))
                {
                    if (saveMovimiento(mov, ref result))
                    {
                        if (!saveDetalleMov(movdet, ref result))
                        {
                            rollbackVenta(_productos, ticket.idTicket, mov.idMovimiento);
                        }
                        else res = true;
                    }
                    else rollbackVenta(_productos, ticket.idTicket, mov.idMovimiento);
                }
                else rollbackVenta(_productos, ticket.idTicket, mov.idMovimiento);
            }
            else rollbackVenta(_productos, ticket.idTicket, mov.idMovimiento);

            return res;
        }
        public EImpresion GetUltimoTicket(ref ETransactionResult result)
        {
            Daticket daLista = new Daticket();
            return daLista.ticket_GetLast(ref result);
        }

        private bool saveTicket(Eticket ticket, ref ETransactionResult result)
        {
            bool res = false;

            Daticket _ticket = new Daticket();
            _ticket.ticket_Insert(ticket, ref result);

            if (result.result == 0) res = true;

            return res;
        }
        private bool saveDetalleTicket(List<EdetalleTicket> detalle, ref ETransactionResult result)
        {
            bool res = true;
            DadetalleTicket daDetalle = new DadetalleTicket();
            
            foreach(EdetalleTicket det in detalle)
            {
                daDetalle.detalleTicket_Insert(det, ref result);
                if(result.result != 0)
                {
                    res = false;
                    return res;
                }
            }
            return res;
        }
        private bool saveMovimiento(EMovimiento mov, ref ETransactionResult result)
        {
            bool res = true;
            DaMovimiento _movimiento = new DaMovimiento();

            _movimiento.Movimiento_Insert(mov, ref result);
            if (result.result != 0) res = false;

            return res;
        }
        private bool saveDetalleMov(List<EMovimientoDetalle> detalle, ref ETransactionResult result)
        {
            bool res = true;
            DaMovimientoDetalle daDetalle = new DaMovimientoDetalle();

            foreach(EMovimientoDetalle item in detalle)
            {
                daDetalle.MovimientoDetalle_Insert(item, ref result);
                if(result.result != 0)
                {
                    return false;
                }
            }
            return res;
        }
        private void rollbackVenta(List<Eproductos> productos, int idTicket, int idMovimiento)
        {
            ETransactionResult result = new ETransactionResult();
            Daticket daTicket = new Daticket();
            Daproductos daProductos = new Daproductos();
            daTicket.ticket_RollBack(idTicket, idMovimiento, ref result);

            foreach(Eproductos item in productos)
            {
                daProductos.productos_Update(item, ref result);
            }
        }
        private int? getIdMovimiento()
        {

            DaMovimiento _movimiento = new DaMovimiento();            
            ETransactionResult result = new ETransactionResult();
            int maxid = 0;

            var lista = _movimiento.Movimiento_GetAll(ref result).Cast<EMovimiento>().ToList();

            if(lista.Count != 0)
            {
                maxid = lista.Select(x => x.idMovimiento).Max();
            }

            maxid = maxid + 1;

            return maxid;
        }
        private int? getIdMovimientoDetalle()
        {
            DaMovimientoDetalle _movimientoDetalle = new DaMovimientoDetalle();
            ETransactionResult result = new ETransactionResult();


            int maxid = 0;

            var lista = _movimientoDetalle.MovimientoDetalle_GetAll(ref result).Cast<EMovimientoDetalle>().ToList();

            if (lista.Count != 0)
            {
                maxid = lista.Select(x => x.idDetalle).Max();
            }

            maxid = maxid + 1;
            
            return maxid;
        }
        private int? getIdTicket()
        {
            Daticket daLista = new Daticket();
            ETransactionResult result = new ETransactionResult();
            int maxid = 0;

            var lista = daLista.ticket_GetAll(ref result).Cast<Eticket>().ToList();

            if(lista.Count != 0)
            {
                maxid = lista.Select(x => x.idTicket).Max();
            }

            maxid = maxid + 1;
            
            return maxid;
        }
        private int? getIdTicketDet()
        {
            DadetalleTicket daLista = new DadetalleTicket();
            ETransactionResult result = new ETransactionResult();
            int maxid = 0;

            var lista = daLista.detalleTicket_GetAll(ref result).Cast<EdetalleTicket>().ToList();

            if (lista.Count != 0)
            {
                maxid = lista.Select(x => x.idDetalle).Max();
            }

            maxid = maxid + 1;

            return maxid;
        }

        public EImpresion GetTicketVenta(int ticket, ref ETransactionResult result)
        {
            Daticket db = new Daticket();
            return db.ticket_GetVenta(ticket, ref result);
        }

        public void updateTicket(Eticket ticket, ref ETransactionResult result)
        {
            Daticket db = new Daticket();
            db.ticket_Update(ticket, ref result);
        }

        public Eticket getEncTicket(Eticket item, ref ETransactionResult result)
        {
            Daticket db = new Daticket();
            return db.ticket_Get(item, ref result);
        }

        public void CancelaVenta(Eticket ticket, ref ETransactionResult result)
        {
            List<EdetalleTicket> det = new List<EdetalleTicket>();
            DadetalleTicket db = new DadetalleTicket();
            Daticket dbTicket = new Daticket();
            Daproductos _prod = new Daproductos();

            det = db.detalleTicket_GetByIdTicket(ticket, ref result);


            EMovimiento mov = new EMovimiento();            
            List<EMovimientoDetalle> movdet = new List<EMovimientoDetalle>();
            int idDetalle = 0;
            mov.fecha = DateTime.Now;
            mov.idMovimiento = (int)getIdMovimiento();
            mov.idTipoMovimiento = "DEV";
            mov.observacion = "";
            mov.usuario = ticket.usuario;

            idDetalle = (int)getIdMovimientoDetalle();
            foreach (EdetalleTicket item in det)
            {

                EMovimientoDetalle detalle = new EMovimientoDetalle();

                detalle.idDetalle = idDetalle;
                detalle.idMovimiento = mov.idMovimiento;
                detalle.tipoAfectacion = "E";
                detalle.idProducto = item.idProducto;
                detalle.cantidad = item.cantidad;

                idDetalle += 1;
                movdet.Add(detalle);
            }

            
            saveMovimiento(mov, ref result);
            saveDetalleMov(movdet, ref result);
            dbTicket.ticket_Update(ticket, ref result);

        }
    }
}
