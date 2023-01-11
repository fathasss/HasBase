using HasB4bBase.Models;
using HasB4bBase.Models.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HasB4bBase.Controllers
{
    public class FinanceController : BaseController
    {
        // GET: Finance
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string GetFinanceList()
        {
            return JsonConvert.SerializeObject(FinanceAccess.GetList());
        }
    }
}