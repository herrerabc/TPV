using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TPVService.Entities
{
    [DataContract]
    public class ETransactionResult
    {
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public string rollbackMessage { get; set; }
        [DataMember]
        public int result { get; set; }
    }
}