using HasB4bBase.Models.EntityAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HasB4bBase.Models
{
    public class BaseController : Controller
    {
        protected Customer CurrentCustomer
        {
            get { return (Customer)Session["CurrentCustomer"]; }
            set { Session["CurrentCustomer"] = value; }
        }

        protected Language CurrentLanguage
        {
            get { return (Language)Session["CurrentLanguage"]; }
            set { Session["CurrentLanguage"] = value; }
        }
    }

}