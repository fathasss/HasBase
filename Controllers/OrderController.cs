using HasB4bBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HasB4bBase.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
    }
}