using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HasB4bBase.Models.Helper
{
    public class Enums
    {
        public enum OrderStatus
        {
            OnHold = 0,
            Confirmed = 1,
            OnWay = 2,
            OnCargo = 3,
            WasDelivered = 4
        }

        public enum BasketStatus
        {
            OnHold = 0,
            Confirmed = 1,
            Deleted = 2
        }

        public enum CustomerLogin
        {
            UserNotFound = 0,
            Success = 1,
            UsernameError = 2,
            PasswordError = 3,
            LoginServiceError = 4,
            AuthenticationError = 5,
            RequiredData = 6
        }

        public enum CustomerSignUp
        {
            UserWithThisMailExits = 0,
            Success = 1,
            Error = 2
        }

        public enum MessageType
        {
            Error = 0,
            Success = 1
        }

        public enum CampaignType
        {
            None = 0,
            NetPrice = 1,
            EndOfTheSeason = 2
        }

        public enum MailType
        {
            OrderConfirmed = 0,
            OrderDeleted = 1,
            OrderOnTheCargo = 2,
            ForgotPassword = 3,
            LoginProcess = 4,
            Undefined = 99
        }
    }
}