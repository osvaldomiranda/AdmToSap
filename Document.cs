using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AdmToSap
{
    [DataContract]
    class Document
    {
        [DataMember]
        public String BoObjectType { get; set; }
        [DataMember]
        public String DocumentSubType { get; set; }
        [DataMember]
        public String CardCode { get; set; }
        [DataMember]
        public String DocDate { get; set; }
        [DataMember]
        public String DocDueDate { get; set; }
        [DataMember]
        public String TaxDate { get; set; }
        [DataMember]
        public String FolioNumber { get; set; }
        [DataMember]
        public String FolioPrefixString { get; set; }
        [DataMember]
        public String DiscountPercent { get; set; }
        [DataMember]
        public String Indicator { get; set; }

        [DataMember]
        public List<Item> items = new List<Item>();
        [DataMember]
        public List<UdfDocument> udfs = new List<UdfDocument>();
    }

    class Item
    {
        public String ItemCode { get; set; }
        public String Quantity { get; set; }
        public String UnitPrice { get; set; }
        public String WarehouseCode { get; set; }
        public String TaxCode { get; set; }
        public String DiscountPercent { get; set; }
    
}

    class UdfDocument
    {
        public String U_SEI_FEBOSID { get; set; }
        public String U_SEI_INREF { get; set; }
        public String U_SEI_FOREF { get; set; }
        public String U_SEI_FEREF { get; set; }
        public String U_SEI_CREF { get; set; }

    }
}
