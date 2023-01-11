using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HasB4bBase.Models.Helper
{
    public class MessageBox : BaseModels
    {
        public MessageType Type { get; set; }
        public string Content { get; set; }

        public MessageBox()
        {
            Type = MessageType.Error;
            Content = string.Empty;
        }
    }
}