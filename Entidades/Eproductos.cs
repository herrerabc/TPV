using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Dulceria.Entidades
{
    public class Eproductos
    {
        [DisplayName("ID")]
        public int idProducto { get; set; } //(int 4)  not null
        [DisplayName("Unidad de Medida")]
        public int? idUnidad { get; set; } //(int 4)  null
        [DisplayName("Producto")]
        public string descripcion { get; set; } //(varchar 50)  not null
        [DisplayName("Codigo de barras")]
        public string codigoBarras { get; set; } //(varchar 40)  not null
        [DisplayName("Precio de venta")]
        public decimal precio { get; set; } //(money 8)  not null
        [DisplayName("Precio de compra")]
        public decimal precioReal { get; set; } //(money 8)  not null
        [DisplayName("Existencia")]
        public decimal cantidad { get; set; } //(numeric 9)  not null
        [DisplayName("Estatus")]
        public bool estado { get; set; } //(bit)  not null
    }

    public class Eproductoss
    {
        [DisplayName("ID")]
        public int idProducto { get; set; } //(int 4)  not null
        [DisplayName("Unidad de Medida")]
        public List<EunidadMedida> unidad { get; set; } //(int 4)  null
        [DisplayName("Producto")]
        public string descripcion { get; set; } //(varchar 50)  not null
        [DisplayName("Codigo de barras")]
        public string codigoBarras { get; set; } //(varchar 40)  not null
        [DisplayName("Precio de venta")]
        public decimal precio { get; set; } //(money 8)  not null
        [DisplayName("Precio de compra")]
        public decimal precioReal { get; set; } //(money 8)  not null
        [DisplayName("Existencia")]
        public decimal cantidad { get; set; } //(numeric 9)  not null
        [DisplayName("Estatus")]
        public bool estado { get; set; } //(bit)  not null
    }
}