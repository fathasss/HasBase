using HasB4bBase.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HasB4bBase.Controllers
{
    public class ReportController : BaseController
    {
        // GET: Report
        public ActionResult Index() => View();

        public static string GetReport()
        {
            DataTable dt = new DataTable();          
            return string.Empty;
        }
    }
}