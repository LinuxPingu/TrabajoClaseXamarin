using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoClaseXamarin.Models
{
    public class MessageModel
    {

        public string Message { get; set; }
        public MediaFileModel Media { get; set; }
        public string User { get; set; }
        public bool isText { get; set; }


        public MessageModel()
        {
        }


        public async static Task<ObservableCollection<MessageModel>> getAllMsg()
        {

            ObservableCollection<MessageModel> lstMsgs = new ObservableCollection<MessageModel>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var uri = new Uri("http://b910e26d4bca.ngrok.io/Message/GetMessages");
                    HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);
                    string ans = await response.Content.ReadAsStringAsync();
                    lstMsgs = JsonConvert.DeserializeObject<ObservableCollection<MessageModel>>(ans);
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error Trayendo Mensajes: "+e);
                }
            

            }
            return lstMsgs;
        }


        public async static Task<bool> SendMsg(string text)
        {
            bool chk = false;
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    var uri = new Uri($"http://b910e26d4bca.ngrok.io/Message/SendMessage/LinuxPingu/{text}");
                    HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);
                    string ans = await response.Content.ReadAsStringAsync();
                    chk = true;
                } catch (Exception e)
                {
                    Console.WriteLine("Error enviando mensaje: "+e);
                    chk = false;
                }

            }

            return chk;
        }


        public MessageModel(string text, string user, bool isText)
        {
            Message = text;
            User = user;
            this.isText = isText;
        }
    }
}
