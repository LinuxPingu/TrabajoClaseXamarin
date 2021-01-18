using System;
using System.Collections.Generic;
using System.Text;
using TrabajoClaseXamarin.Models;
using TrabajoClaseXamarin.Views.Cells;
using Xamarin.Forms;

namespace TrabajoClaseXamarin.Helpers
{
    public class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;
        DataTemplate incomingImgTemplate;
        DataTemplate outgoingImgTemplate;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
            this.incomingImgTemplate = new DataTemplate(typeof(IncomingPictureViewCell));
            this.outgoingImgTemplate = new DataTemplate(typeof(OutgoingPictureViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = item as MessageModel;
            DataTemplate final = null;

            if (message!=null)
            {
                if (message.isText)
                {
                    if (message.User == "LinuxPingu")
                    {
                        final = outgoingDataTemplate;
                    }
                    else
                    {
                        final = incomingDataTemplate;
                    }

                }
                else
                {
                    if (message.User == "LinuxPingu")
                    {
                        final = outgoingImgTemplate;
                    }
                    else
                    {
                        final = incomingImgTemplate;
                    }
                }


            }
            else
            {
                Console.WriteLine("El mensaje llego nulo!!!!!!!!");
            }

            return final;
        }
    }
}
