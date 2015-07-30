using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AdmToSap
{
    [DataContract]
    class Payment
    {
        [DataMember]
        public String CardCode { get; set; } // Codigo cliente SAP
        [DataMember]
        public DateTime DocDate { get; set; } // fecha del pago
        [DataMember]
        public String CashSum { get; set; } // Total de Pago
        [DataMember]
        public String CashAccount { get; set; } // Cuenta banco SAP
        [DataMember]
        public String TransferAccount { get; set; } // Cuenta de Transferencia
        [DataMember]
        public String TransferSum { get; set; } // Total de la Transferencia
        [DataMember]
        public String TransferDate { get; set; } // Fecha de la transferencia
        [DataMember]
        public String TransferReference { get; set; } // Datos adicional de la transferencia
        [DataMember]
        public int tipoCargoAdm { get; set; }
        [DataMember]
        public Decimal folioDte { get; set; }
        [DataMember]
        public Byte codEmpresa { get; set; }
        [DataMember]
        public Int32 codSucursalAbono { get; set; }
        [DataMember]
        public Byte caja { get; set; }
        [DataMember]
        public Int32 tipoAbono { get; set; }
        [DataMember]
        public Int32 nroAbono { get; set; }
        [DataMember]
        public string cajero { get; set; }
        [DataMember]
        public string vendedor { get; set; } 



        [DataMember]
        public UdfPayment udf = new UdfPayment(); // lista de Udfs

        [DataMember]
        public List<Documentsap> documentsap = new List<Documentsap>(); // lista de documentos

        [DataMember]
        public List<Checks> checks = new List<Checks>(); // lista de cheques

        [DataMember]
        public List<CreditCards> creditcard = new List<CreditCards>(); // lista de cheques

     }

    [DataContract]
    class UdfPayment
    {
        [DataMember]
        public String U_SEI_CAJA { get; set; }
        [DataMember]
        public String U_SEI_CAJERO { get; set; }
    }

    [DataContract]
    class Documentsap
    {
        [DataMember]
        public String InvoiceType { get; set; } // Codigo de tipo docuemnto SAP
        [DataMember]
        public String DocEntry { get; set; }  // codigo que retorna del servicio AddDocument
        [DataMember]
        public String SumApplied { get; set; } // Monto total o parcial del documento, si es nota de credito el valor es negativo

    }
    
    [DataContract]
    class Checks
    {
        [DataMember]
        public DateTime DueDate { get; set; }
        [DataMember]
        public Decimal CheckNumber { get; set; }
        [DataMember]
        public String BankCode { get; set; } // Codigo del banco SAP
        [DataMember]
        public String CheckSum { get; set; } // 
        [DataMember]
        public String CheckAccount { get; set; } // cuenta de SAP

    }

    [DataContract]
    class CreditCards
    {
        [DataMember]
        public String CreditCard { get; set; } // codigo SAP tipo de tarjeta
        [DataMember]
        public String CreditCardNumber { get; set; } // numero de tarjeta
        [DataMember]
        public DateTime CardValidUntil { get; set; } // Fecha de vencimiento
        [DataMember]
        public String CreditSum { get; set; } // Monto total de pago
        [DataMember]
        public Decimal VoucherNum { get; set; } // datos del voucher POS
        [DataMember]
        public String CreditAcct { get; set; } // cuenta de tarjeta



    }

}

