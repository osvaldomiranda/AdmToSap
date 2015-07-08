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
        String rowCount { get; set; }
        [DataMember]
        public List<Items> Items = new List<Items>();



    }
    [DataContract]
    class Items
    {
        [DataMember]
        String Grupo { get; set; }
        [DataMember]
        String CodInt { get; set; }
        [DataMember]
        String Codigo { get; set; }
        [DataMember]
        String CodProv { get; set; }
        [DataMember]
        String CodBarra { get; set; }
        [DataMember]
        String CodCatalog { get; set; }
        [DataMember]
        String Nombre { get; set; }
        [DataMember]
        String UniCompra { get; set; }
        [DataMember]
        String UniVenta { get; set; }
        [DataMember]
        String CostoUC { get; set; }
        [DataMember]
        String DescripcionCorta { get; set; }
        [DataMember]
        String SUcompra { get; set; }
        [DataMember]
        String SUventa { get; set; }
        [DataMember]
        String RutProv { get; set; }
        [DataMember]
        String PorcIVA { get; set; }
        [DataMember]
        String Precio1 { get; set; }
        [DataMember]
        String Precio2 { get; set; }
        [DataMember]
        String Precio3 { get; set; }
    }
}
