using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.IO;
using HasB4bBase.Models.EntityAccess;
using HasMailHelper.Models;

namespace HasB4bBase.Models.Helper
{
    public class MailEdited : BaseModels
    {
        //Example
        public bool SendMail(MailInformation mailInformation)
        {
            string loadHtml = string.Empty;

            switch (mailInformation.Type)
            {
                case MailType.OrderConfirmed:
                    loadHtml = File.ReadAllText("~/Files/MailTemplate/orderConfirm.html");
                    break;
                case MailType.OrderDeleted:
                    loadHtml = File.ReadAllText("~/Files/MailTemplate/orderDelete.html");
                    break;
                case MailType.OrderOnTheCargo:
                    loadHtml = File.ReadAllText("~/Files/MailTemplate/orderCargo.html");
                    break;
                case MailType.ForgotPassword:
                    loadHtml = File.ReadAllText("~/Files/MailTemplate/forgotPassword.html");
                    break;
                case MailType.LoginProcess:
                    loadHtml = File.ReadAllText("~/Files/MailTemplate/loginProcess.html");
                    break;
                default:
                    break;
            }

            loadHtml.Replace("{Subject}", mailInformation.Subject)
                .Replace("{CustomerName}", mailInformation.Customer.Username)
                .Replace("{CustomerPhone}", mailInformation.Customer.Phone)
                .Replace("{CustomerEmail}", mailInformation.Customer.Email)
                .Replace("{CustomerAddress}", mailInformation.Customer.FullAddress)
                .Replace("|", "");

            int number = 1;
            foreach (var item in mailInformation.OrderInfo)
            {
                loadHtml.Replace("{Number}", number.ToString())
                    .Replace("{ProductCode}", item.Product.Code)
                    .Replace("{ProductName}", item.Product.Name)
                    .Replace("{Quantity}", item.Quantity.ToString())
                    .Replace("{Price}", item.Product.Price.ToString());
                number++;
            }
            return true;
        }
    }
}