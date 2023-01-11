using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HasB4bBase.Attribute;
using HasB4bBase.Models;
using HasB4bBase.Models.DataAccess;
using HasB4bBase.Models.EntityAccess;
using HasB4bBase.Models.Helper;
using Newtonsoft.Json;

namespace HasB4bBase.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index() => View();
        public ActionResult SignUp() => View();
        public ActionResult ResetMyPassword() => View();


        [HttpPost]
        public string Index(Customer model)
        {
            var result = CustomerAccess.Login(model);
            if (ModelState.IsValid && Convert.ToBoolean(result[0].Type))
            {
                Session["CurrentCustomer"] = model;
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                Session["CurrentCustomer"] = null;
                return JsonConvert.SerializeObject(result);
            }
        }

        [HttpPost]
        public string SignUp(Customer customer)
        {
            var result = CustomerAccess.SignUp(customer);
            return JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string ForgotPassword(Customer customer)
        {
            string content = string.Empty;
            if (ModelState.IsValid)
            {
                var result = CustomerAccess.GetResetMyPassMail(customer);
                if (result)
                    content = "Mail başarı ile gönderildi.";
                else
                    content = "Böyle bir hesap bulunamadı.";
            }
            return content;
        }

        [HttpPost]
        public string GetLocation(string latitude,string longitude)
        {
            var result = LanguageAccess.GetLocationInformation(latitude, longitude);
            Session["CurrentLanguage"] = LanguageAccess.GetList().Where(x => x.Location == result).FirstOrDefault();
            return result;
        }

        [HttpPost]
        public MessageBox Logout()
        {
            MessageBox result = new MessageBox();
            try
            {
                Session.Abandon();
                result.Type = Enums.MessageType.Success;
                result.Content = "Başarı ile çıkış yaptınız.";
                return result;
            }
            catch(Exception exp)
            {
                result.Type = Enums.MessageType.Error;
                result.Content = "Bir sorun oluştu. " + exp.Message;
                return result;
            }
        }
    }
}