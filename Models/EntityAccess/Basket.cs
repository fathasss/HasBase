using HasB4bBase.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HasB4bBase.Models.EntityAccess
{
    public class Basket : BaseModels
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public BasketStatus Statu { get; set; }
        public string StatuStr
        {
            get
            {
                switch (Statu)
                {
                    case BasketStatus.OnHold:
                        return "Beklemede";
                    case BasketStatus.Confirmed:
                        return "Gönderildi.";
                    case BasketStatus.Deleted:
                        return "Silindi.";
                    default:
                        return "Bilinmiyor.";
                }
            }
        }
        public double Total { get; set; }
        public double Vat { get; set; }
        public double TotalWithVat { get { return Total + (Total * (Vat / 100)); } }

        public Basket()
        {
            this.Id = 0;
            this.Product = new Product();
            this.Customer = new Customer();
            this.Total = 0.00;
            this.Vat = 0.00;
        }
    }
}