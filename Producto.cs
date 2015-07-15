using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AdmToSap
{
    [DataContract]
    class Producto
    {

        [DataMember]
        public String rowCount { get; set; }
        [DataMember]
        public List<Items> Items = new List<Items>();



    }
    [DataContract]
    class Items
    {
        [DataMember]
     public String Grupo { get; set; }
        [DataMember]
        public String CodInt { get; set; }
         [DataMember]
    public String Codigo { get; set; }
        [DataMember]
         public String CodProv { get; set; }
        [DataMember]
        public String CodBarra { get; set; }
        [DataMember]
        public String CodCatalog { get; set; }
        [DataMember]
        public String Nombre { get; set; }
        [DataMember]
        public String UniCompra { get; set; }
        [DataMember]
        public String UniVenta { get; set; }
        [DataMember]
        public String CostoUC { get; set; }
        [DataMember]
        public String DescripcionCorta { get; set; }
        [DataMember]
        public String SUcompra { get; set; }
        [DataMember]
        public String SUventa { get; set; }
        [DataMember]
        public String RutProv { get; set; }
        [DataMember]
        public String PorcIVA { get; set; }
        [DataMember]
        public String Precio1 { get; set; }
        [DataMember]
        public String Precio2 { get; set; }
        [DataMember]
        public String Precio3 { get; set; }
    }
}
