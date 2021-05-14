using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dulceria.Entidades;

namespace Dulceria.Logica
{
    public interface IVenta
    {
        EImpresion GetUltimoTicket(ref ETransactionResult result);
        EImpresion GetTicketVenta(int ticket,ref ETransactionResult result);
        bool SetVenta(List<ETicketVenta> venta, string usr, ref ETransactionResult result);
        void updateTicket(Eticket ticket, ref ETransactionResult result);
        Eticket getEncTicket(Eticket item, ref ETransactionResult result);
        void CancelaVenta(Eticket ticket, ref ETransactionResult result);
    }
}
