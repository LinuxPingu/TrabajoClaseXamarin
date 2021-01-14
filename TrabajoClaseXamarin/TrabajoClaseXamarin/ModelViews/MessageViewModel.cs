using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TrabajoClaseXamarin.Models;
using Xamarin.Forms;

namespace TrabajoClaseXamarin.ModelViews
{
    public class MessageViewModel: INotifyPropertyChanged
    {

        #region Singleton

        public static MessageViewModel instance = null;

        public MessageViewModel()
        {
            InitClass();
            InitCommands();
        }

        public static MessageViewModel getInstance()
        {
            if (instance == null)
            {
                instance = new MessageViewModel();
            }

            return instance;
        }

        public static void deleteInstance()
        {
            if (instance != null)
            {
                instance = null;
            }
        }

        #endregion

        #region Inits

        public async void InitClass()
        {
            LstMsgs.Clear();
            LstMsgs.Add(new MessageModel { User="User2",Text="Hola Comoestas"});
        }

        public async void InitCommands()
        {
            SendTextCommand = new Command(this.SendText);
        }

        #endregion

        #region Variables

        #region Lista de Mensajes
        private ObservableCollection<MessageModel> lstMsgs = new ObservableCollection<MessageModel>();
        public ObservableCollection<MessageModel> LstMsgs
        {
            get
            {
                return lstMsgs;
            }
            set
            {
                lstMsgs = value;
                OnPropertyChanged("LstMsgs");
            }
        }

        #endregion

        #region To send

        private string textToSend = "";
        public string TextToSend
        {
            get
            {
                return this.textToSend;
            }
            set
            {
                textToSend = value;
                OnPropertyChanged("TextToSend");
            }
        }

        #endregion

        #endregion

        #region Commands


        public ICommand SendTextCommand { get; set; }

        public void SendText()
        {
            if (!string.IsNullOrEmpty(this.TextToSend))
            {
                LstMsgs.Add(new MessageModel { User = "User1", Text = this.TextToSend });
                TextToSend = string.Empty;
            }
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
