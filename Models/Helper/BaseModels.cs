using HasB4bBase.Attribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

namespace HasB4bBase.Models.Helper
{
    public class BaseModels : Enums
    {
        public static List<string> GetColumnsName(DataTable dt)
        {
            List<string> columnName = new List<string>();
            foreach (DataColumn column in dt.Columns)
                columnName.Add(column.ColumnName);

            return columnName;
        }
     
        public static List<MessageBox> CustomerLoginInformation(CustomerLogin customerLogin)
        {
            List<MessageBox> list = new List<MessageBox>();

            switch (Convert.ToInt32(customerLogin))
            {
                case 0:
                    list.Add(new MessageBox() { Type = MessageType.Error, Content = "Kullanıcı Bulunamadı." });
                    break;
                case 1:
                    list.Add(new MessageBox() { Type = MessageType.Success, Content = "Giriş Başarılı." });
                    break;
                case 2:
                    list.Add(new MessageBox() { Type = MessageType.Error, Content = "Kullanıcı Adı Hatalı." });
                    break;
                case 3:
                    list.Add(new MessageBox() { Type = MessageType.Error, Content = "Parola Hatalı." });
                    break;
                case 4:
                    list.Add(new MessageBox() { Type = MessageType.Error, Content = "Giriş Hatası. İletişime Geçin." });
                    break;
                case 5:
                    list.Add(new MessageBox() { Type = MessageType.Error, Content = "Giriş yetkiniz bulunmamaktadır." });
                    break;
                case 6:
                    list.Add(new MessageBox() { Type = MessageType.Error, Content = "Kullanıcı adı veya şifre boş bırakılamaz." });
                    break;
                default:
                    list.Add(new MessageBox() { Type = MessageType.Error, Content = "Giriş Başarısız." });
                    break;
            }

            return list;
        }

        public static List<MessageBox> CustomerSignUpInformation(CustomerSignUp customerSign)
        {
            List<MessageBox> list = new List<MessageBox>();

            switch (Convert.ToInt32(customerSign))
            {
                case 0:
                    list.Add(new MessageBox() { Type = MessageType.Error, Content = "Bu maile sahip kullanıcı bulunmaktadır." });
                    break;
                case 1:
                    list.Add(new MessageBox() { Type = MessageType.Success, Content = "Başarı ile kayıt oldunuz." });
                    break;
                case 2:
                    list.Add(new MessageBox() { Type = MessageType.Error, Content = "Servis ve veri hatası. İletişime geçiniz." });
                    break;
                default:
                    list.Add(new MessageBox() { Type = MessageType.Error, Content = "Servis ve veri hatası. İletişime geçiniz." });
                    break;
            }

            return list;
        }
         
        [ExceptionLogger]
        public static DataTable XmlToDataTable(string xmlPath)
        {
            DataTable dt = new DataTable();
            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlPath);

                XmlNode parent = xmlDoc.DocumentElement.ChildNodes.Cast<XmlNode>().ToList()[0];

                foreach (XmlNode column in parent)
                {
                    dt.Columns.Add(column.Name, typeof(string));
                }
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList childNodes = root?.ChildNodes;
                for (int i = 0; i <= childNodes.Count - 1; i++)
                {
                    XmlNode child = xmlDoc.DocumentElement.Cast<XmlNode>().ToList()[i];
                    List<string> rContent = new List<string>();
                    //rows
                    foreach (XmlNode item in child)
                    {
                        rContent.Add(item.InnerText);
                    }

                    dt.Rows.Add(rContent.ToArray());
                    rContent.Clear();
                }
            }
            catch(Exception exp) { return new DataTable(); }

            return dt;
        }
    }
}