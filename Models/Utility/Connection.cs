using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HasB4bBase.Models.Utility
{
    public class Connection
    {
        public static string _Connect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public static string DAL
        {
            get => _Connect;
        }
    }
}