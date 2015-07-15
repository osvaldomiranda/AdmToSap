using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AdmToSap
{
     [DataContract]
    class ListaPrecio
    {
        [DataMember]
        public String PriceList { get; set; }
        [DataMember]
        public String ListName { get; set; }
        [DataMember]
        public String UpdateDate { get; set; }
        [DataMember]
        public List<ItemsPrecio> Items = new List<ItemsPrecio>();         
    }
     [DataContract]
     class ItemsPrecio
     {

         [DataMember]
         public String CodInt { get; set; }
         [DataMember]
         public String Price { get; set; }

     }
    
}
