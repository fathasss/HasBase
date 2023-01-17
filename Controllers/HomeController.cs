using Has.BadWordsFilter;
using HasB4bBase.Attribute;
using HasB4bBase.Models;
using HasB4bBase.Models.EntityAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HasB4bBase.Controllers
{
    public class HomeController : BaseController
    {
        [HttpPost]
        public string CurrentCustomerData() => JsonConvert.SerializeObject(CurrentCustomer);

        //[GeneralLogger]
        public ActionResult Index()
        {
            return View();
        }

        //[GeneralLogger]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //[GeneralLogger]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public Tuple<string, string> GeneralSearch(string search)
        {
            return Tuple.Create(string.Empty, string.Empty);
        }
    }
}