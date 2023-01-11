using HasB4bBase.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HasB4bBase.Models.EntityAccess
{
    public class Order : BaseModels
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public OrderStatus Statu { get; set; }
        public double Quantity { get; set; }
        public string StatuStr 
        {
            get
            {
                switch (Statu)
                {
                    case OrderStatus.OnHold:
                        return "Beklemede";
                    case OrderStatus.Confirmed:
                        return "Onaylandı";
                    case OrderStatus.OnWay:
                        return "Yolda";
                    case OrderStatus.WasDelivered:
                        return "Teslim Edildi.";
                    case OrderStatus.OnCargo:
                        return "Kargoda";
                    default:
                        return "Bilinmiyor";
                }
            }
        }
        public double Total { get; set; }
        public double Vat { get; set; }
        public double TotalWithVat { get { return Total + (Total * (Vat / 100)); } }
        
        public Order()
        {
            this.Id = 0;
            this.Customer = new Customer();
            this.Product = new Product();
            this.Total = 0.00;
            this.Vat = 0.00;
        }
    }
}