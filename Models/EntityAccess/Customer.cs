using HasB4bBase.Models.DataAccess;
using HasB4bBase.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HasB4bBase.Models.EntityAccess
{
    public class Customer : BaseModels
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string FullAddress { get { return Address + "/" + Town + "/" + City; } }
        public AuthorityCustomer Authority { get; set; }

        public Customer()
        {
            this.Id = 0;
            this.Username = "Anonymous";
            this.City = "Anonymous";
            this.Town = "Anonymous";
            this.Email = "Anonymous";
            this.Phone = "0000 000 00 00";
            this.Password = "Anonymous";
            this.Authority = new AuthorityCustomer();
        }
    }
}