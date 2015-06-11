using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace AdmToSap
{
    [DataContract]
    class Partner
    {
        [DataMember]
        public String BusinessPartner { get; set; }
        [DataMember]
        public String CardCode { get; set; }
        [DataMember]
        public String CardName { get; set; }
        [DataMember]
        public String LicTradNum { get; set; }
        [DataMember]
        public String Notes { get; set; }
        [DataMember]
        public String GroupNum { get; set; }
        [DataMember]
        public String SlpCode { get; set; }
        [DataMember]
        public String Street { get; set; }
        [DataMember]
        public String Block { get; set; }
        [DataMember]
        public String City { get; set; }
        [DataMember]
        public String County { get; set; }
        [DataMember]
        public String Country { get; set; }
        [DataMember]
        public String udf { get; set; }

    }
}
