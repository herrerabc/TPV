using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TPVService.Entities
{
    [DataContract]
    public class Usuario
    {
            [DataMember]          
            public string usuario { get; set; } //(varchar 15)  not null
            [DataMember]            
            public string passwd { get; set; } //(varchar 20)  not null
            [DataMember]            
            public string nombre { get; set; } //(varchar 25)  not null
            [DataMember]            
            public string apellidoP { get; set; } //(varchar 25)  not null
            [DataMember]            
            public string apellidoM { get; set; } //(varchar 25)  not null
            [DataMember]            
            public string roll { get; set; } //(varchar 10)  not null
            [DataMember]            
            public bool? estatus { get; set; } //(bit 1)  null        
    }
}