using System;
using System.ComponentModel;

namespace Dulceria.Entidades
{
    public class Eusuarios
    {
        [DisplayName("Usuario")]
        public string usuario { get; set; } //(varchar 15)  not null
        [DisplayName("Contraseña")]
        public string passwd { get; set; } //(varchar 20)  not null
        [DisplayName("Nombre")]
        public string nombre { get; set; } //(varchar 25)  not null
        [DisplayName("Apellido Paterno")]
        public string apellidoP { get; set; } //(varchar 25)  not null
        [DisplayName("Apellido Materno")]
        public string apellidoM { get; set; } //(varchar 25)  not null
        [DisplayName("Rol")]
        public string roll { get; set; } //(varchar 10)  not null
        [DisplayName("Estado")]
        public bool? estatus { get; set; } //(bit 1)  null
    }
}