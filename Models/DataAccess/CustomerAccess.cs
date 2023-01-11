using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HasB4bBase.Models.EntityAccess;
using HasB4bBase.Models.Helper;

namespace HasB4bBase.Models.DataAccess
{
    public class CustomerAccess : Customer, ICustomer
    {
        public int Insert()
        {
            throw new NotImplementedException();
        }
        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }
        public static List<MessageBox> Login(Customer customer)
        {
            var result = 0;
            object[] param = { "@pName", customer.Username,
                               "@pPassword", customer.Password,};

            if (customer.Username == "fatih.has" && customer.Password == "123")
                result = 1;
            else if (string.IsNullOrEmpty(customer.Username) || string.IsNullOrEmpty(customer.Password))
                result = 6;
            //else
            //var result = (CustomerLogin)DbHelper.ExecuteNonQuery("GetItem_Customer_Login",param);  //--> Example
            //var endResult = CustomerLoginInformation((CustomerLogin)result);

            switch ((CustomerLogin)result)
            {
                case CustomerLogin.AuthenticationError:
                    return CustomerLoginInformation(CustomerLogin.AuthenticationError);
                case CustomerLogin.LoginServiceError:
                    return CustomerLoginInformation(CustomerLogin.LoginServiceError);
                case CustomerLogin.PasswordError:
                    return CustomerLoginInformation(CustomerLogin.PasswordError);
                case CustomerLogin.UsernameError:
                    return CustomerLoginInformation(CustomerLogin.UsernameError);
                case CustomerLogin.UserNotFound:
                    return CustomerLoginInformation(CustomerLogin.UserNotFound);
                case CustomerLogin.Success:
                    return CustomerLoginInformation(CustomerLogin.Success);
                case CustomerLogin.RequiredData:
                    return CustomerLoginInformation(CustomerLogin.RequiredData);
                default:
                    return CustomerLoginInformation(CustomerLogin.LoginServiceError);
            }
        }

        public static List<MessageBox> SignUp(Customer customer)
        {
            return CustomerSignUpInformation(CustomerSignUp.Success);
        }

        public Customer GetById(int pCustomerId)
        {
            return new Customer();
        }

        public static bool GetResetMyPassMail(Customer customer)
        {
            return true;
        }
    }
}