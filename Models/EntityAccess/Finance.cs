using HasB4bBase.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HasB4bBase.Models.EntityAccess
{
    public class Finance : BaseModels
    {
        public string CurrencyName { get; set; }
        public int Unit { get; set; }
        public string Type { get; set; }
        public double ForexSelling { get; set; }
        public double ForexBuying { get; set; }
        public double BanknoteBuying { get; set; }
        public double BanknoteSelling { get; set; }

        public Finance()
        {
            this.CurrencyName = "TRY";
            this.Unit = 1;
            this.Type = "TURK LIRASI";
            this.ForexSelling = 1;
            this.ForexBuying = 1;
            this.BanknoteSelling = 1;
            this.BanknoteBuying = 1;
        }
    }
}