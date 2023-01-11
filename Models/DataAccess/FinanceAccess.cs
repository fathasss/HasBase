using HasB4bBase.Models.EntityAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

namespace HasB4bBase.Models.DataAccess
{
    public class FinanceAccess : Finance
    {
        public static List<Finance> GetList()
        {
            List<Finance> list = new List<Finance>();
            DataTable dt = XmlToDataTable("http://www.tcmb.gov.tr/kurlar/today.xml");
            foreach (DataRow row in dt.Rows)
            {
                if (row["CurrencyName"].ToString() == "BULGARIAN LEV")
                    break;

                Finance item = new Finance();
                item.CurrencyName = row.Field<string>("CurrencyName");
                item.Unit = Convert.ToInt32(row["Unit"]);
                item.ForexBuying = row["ForexBuying"] != DBNull.Value ? Convert.ToDouble(row["ForexBuying"]) : 0;
                item.ForexSelling = row["ForexSelling"] != DBNull.Value ? Convert.ToDouble(row["ForexSelling"]) : 0;
                item.BanknoteBuying = row["BanknoteBuying"] != DBNull.Value ? Convert.ToDouble(row["BanknoteBuying"]) : 0;
                item.BanknoteSelling = row["BanknoteSelling"] != DBNull.Value ? Convert.ToDouble(row["BanknoteSelling"]) : 0;

                list.Add(item);
            }
            return list;
        }
    }
}