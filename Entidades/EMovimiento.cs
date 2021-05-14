using System;


namespace Dulceria.Entidades
{
    public class EMovimiento
    {
        public int idMovimiento { get; set; } //(int 4)  not null
        public DateTime fecha { get; set; } //(datetime 8)  not null
        public string usuario { get; set; } //(varchar 15)  not null
        public string idTipoMovimiento { get; set; } //(varchar 4)  not null
        public string observacion { get; set; }
    }
}