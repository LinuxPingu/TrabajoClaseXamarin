using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoClaseXamarin.Models
{
    public class MessageModel
    {

        public string Text { get; set; }
        public string User { get; set; }

        public MessageModel()
        {
        }

        public MessageModel(string text, string user)
        {
            Text = text;
            User = user;
        }
    }
}
