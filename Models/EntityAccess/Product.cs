using HasB4bBase.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HasB4bBase.Models.EntityAccess
{
    public class Product : BaseModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Vehicle { get; set; }
        public double TotalQuantity { get; set; }
        public double Price { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Image { get; set; }

        public Product()
        {
            this.Id = 0;
            this.Name = string.Empty;
            this.Model = string.Empty;
            this.Price = 0.00;
            this.Manufacturer = string.Empty;
            this.Vehicle = string.Empty;
            this.TotalQuantity = 0;
            this.Image = string.Empty;
        }
    }
}