using HasB4bBase.Models.EntityAccess;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HasB4bBase.Models;

namespace HasB4bBase.Attribute
{
    public class ExceptionLogger : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            Customer customer = HttpContext.Current.Session["CurrentCustomer"] as Customer;
            if (object.Equals(customer, null))
                customer = new Customer();

            if(!string.IsNullOrEmpty(args.Exception.Message))
                DataAccess.InsertLog(customer.Id,customer.Username,customer.Email,args.Exception.Message);
        }
    }

    public partial class DataAccess
    {
        public static int InsertLog(int pCustomerId, string pCustomerName, string pCustomerEmail, string pExceptionMessage)
        {
            object[] param = { "@pCustomerId", pCustomerId, "@pCustomerName", pCustomerName, "@pCustomerEmail", pCustomerEmail, "@pExceptionMes", pExceptionMessage, "@ExcepDate", DateTime.Now.ToString() };
            return HasDbHelper.HasDbHelper.ExecuteNonQuery("_Insert_LogError_Message",param);
        }
    }
}
