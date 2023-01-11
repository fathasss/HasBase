using HasB4bBase.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HasB4bBase.Models.EntityAccess
{
    public class AuthorityCustomer : BaseModels
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public bool LockCustomer { get; set; }
        public bool IsShowCard { get; set; }
        public bool IsShowFinance { get; set; }
        public bool LoginAuth { get; set; }

        public AuthorityCustomer()
        {
            this.Id = 0;
            this.CustomerId = 0;
            this.LockCustomer = false;
            this.IsShowCard = false;
            this.IsShowFinance = false;
            this.LoginAuth = false;
        }
    }
}