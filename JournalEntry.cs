using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdmToSap
{
    class JournalEntry
    {
      public DateTime  TaxDate {get; set;}
      public string  Amount {get; set;}
      public string  AccountC {get; set;}
      public string  AccountD {get; set;}
      public string  Reference2 {get; set;}
      public string Memo { get; set; }
      public List<UdfJournalEntry> udf = new List<UdfJournalEntry>();                  
       
    }

    class UdfJournalEntry
    {
      public string  U_SEI_ {get; set;} 
    }
}
