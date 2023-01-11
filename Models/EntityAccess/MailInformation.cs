using HasB4bBase.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HasB4bBase.Models.EntityAccess
{
    public class MailInformation :BaseModels
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Path { get; set; }
        public string Property { get; set; }
        public Customer Customer{ get; set; }
        public List<Order> OrderInfo { get; set; }
        public MailType Type { get; set; }

        public MailInformation()
        {
            this.Id = 0;
            this.Subject = string.Empty;
            this.Text = string.Empty;
            this.Path = string.Empty;
            this.Property = string.Empty;
            this.Customer = new Customer();
            this.Type = MailType.Undefined;
            this.OrderInfo = new List<Order>();
        }
    }
}