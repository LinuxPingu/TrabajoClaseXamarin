using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoClaseXamarin.Models
{
    public class MessageModel
    {

        public string Text { get; set; }
        public MediaFileModel Media { get; set; }
        public string User { get; set; }
        public bool isText { get; set; }


        public MessageModel()
        {
        }

        public MessageModel(string text, string user, bool isText)
        {
            Text = text;
            User = user;
            this.isText = isText;
        }
    }
}
