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
        public DateTime DocDate { get; set; }
        [DataMember]
        public DateTime DocDueDate { get; set; }
        [DataMember]
        public DateTime TaxDate { get; set; }
        [DataMember]
        public String FolioNumber { get; set; }
        [DataMember]
        public String FolioPrefixString { get; set; }
        [DataMember]
        public String DiscountPercent { get; set; }
        [DataMember]
        public String Indicator { get; set; }
        [DataMember]
        public int COGSCostingCode { get; set; } // centro de costos (Sucursal)
        [DataMember]
        public Decimal CostingCode { get; set; } // centro de costos opcional
        [DataMember]
        public Decimal SalesPersonCode { get; set; } // Vendedor
        [DataMember]
        public String FromWarehouse { get; set; } // (Almacén Origen)
        [DataMember]
        public String ToWarehouse { get; set; } // (Almacén Destino)
        [DataMember]
        public Double DocTotal { get; set; } // Total Doc
        





        // campos para crear el sql
        [DataMember]
        public Byte Cod_Empresa { get; set; }
        [DataMember]
        public int Cod_Sucursal { get; set; }
        [DataMember]
        public Byte Tipo_Cargo { get; set; }
        [DataMember]
        public decimal Nro_Cargo { get; set; }
        [DataMember]
        public decimal Nro_Fiscal { get; set; }
        [DataMember]
        public Byte Caja { get; set; }
        [DataMember]
        public Int32 codSucursalAbono { get; set; }
        [DataMember]
        public Int32 tipoAbono { get; set; }
        [DataMember]
        public Int32 numAbono { get; set; }


        [DataMember]
        public UdfDocument udf = new UdfDocument();

        [DataMember]
        public List<Item> items = new List<Item>();

    }

    class Item
    {
        public String ItemCode { get; set; }
        public String Quantity { get; set; }
        public String UnitPrice { get; set; }
        public String WarehouseCode { get; set; }
        public String TaxCode { get; set; }
        public String DiscountPercent { get; set; }
        public String ItemDescription { get; set; }
        public String FromWarehouse { get; set; } // (Almacén Origen)
        public String ToWarehouse { get; set; } // (Almacén Destino)
    
}

    class UdfDocument
    {
        public String U_SEI_FEBOSID { get; set; }   //
        public String U_SEI_INREF { get; set; } // Indicador de Referencia
        public String U_SEI_FOREF { get; set; } // Folio Referencia
        public String U_SEI_FEREF { get; set; } // Fecha Referencia
        public String U_SEI_CREF { get; set; } // Condición de Referencia [1,2,3]
        public String U_SEI_CAJA { get; set; } // numero caja
        public String U_SEI_CAJERO { get; set; } // numero cajero


    }
    
}
