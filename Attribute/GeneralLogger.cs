using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;
using HasB4bBase.Models.Utility;

namespace HasB4bBase.Attribute
{
    public class GeneralLogger : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext) => LogMain(filterContext);

        [ExceptionLogger]
        private void LogMain(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var actionController = String.Empty;
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            var idName = filterContext.RouteData.Values["id"];

            if (idName == null)
                actionController = controllerName + "/" + actionName;
            else
                actionController = controllerName + "/" + actionName + "/id?=" + idName;

            var date = DateTime.Now;
            var user = filterContext.HttpContext.Session["Login"];

            if (user == null)
                user = "Anonymous";

            var browser = request.Browser.Browser;
            var IPAddress = String.Empty;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    IPAddress = ip.ToString();
            }

            object[] param = { "@pName", user.ToString(),
                               "@pActionName", actionController.ToString(),
                               "@pLoginDate", date.ToString(),
                               "@pIpAddress", IPAddress.ToString(),
                               "@pBrowser", browser.ToString() };

            DbHelper.ExecuteNonQuery("_Insert_Logger_Login_Information", param);
        }
    }
}