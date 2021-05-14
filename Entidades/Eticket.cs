using System;


namespace Dulceria.Entidades
{
    public class Eticket
    {
        public int idTicket { get; set; } //(int 4)  not null
        public DateTime fecha { get; set; } //(datetime 8)  not null
        public string usuario { get; set; } //(varchar 15)  not null
        public decimal total { get; set; } //(money 8)  not null
        public bool cancelado { get; set; }
        public string observacion { get; set; }
    }
}