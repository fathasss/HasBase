using HasB4bBase.Models.EntityAccess;
using HasB4bBase.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HasB4bBase.Models.DataAccess
{
    public class ProductAccess : Product, IProduct
    {
        public int Insert()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public List<Product> Search()
        {
            return new List<Product>();
        }

        public void Calculate()
        {
            return;
        }
    }
}