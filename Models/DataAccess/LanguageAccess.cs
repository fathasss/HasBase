using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HasB4bBase.Models.DataAccess
{
    public class LanguageAccess : Language
    {
        public static List<Language> GetList()
        {
            List<Language> list = new List<Language>();
            DataTable dt = new DataTable();  // SqlDataBase -> Conncetion
            if(dt.Rows.Count > 0)
            {
                list.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    Language item = new Language()
                    {
                        Id = row.Field<int>("Id"),
                        Name = row.Field<string>("Name"),
                        Status = row.Field<bool>("Status"),
                        IsActive = row.Field<bool>("IsActive"),
                        Location = row.Field<string>("Location")
                    };
                    list.Add(item);
                }
            }
            if (list.Count == 0)
                list.Add(new Language());

            return list;
        }

        public static string GetLocationInformation(string pLatitude,string pLongitude)
        {
            if ((Convert.ToDouble(pLongitude) > 25 && Convert.ToDouble(pLongitude) < 45) && (Convert.ToDouble(pLatitude) > 36 && Convert.ToDouble(pLatitude) < 42))
                return "Turkey";
            else
                return string.Empty;
        }
    }
}