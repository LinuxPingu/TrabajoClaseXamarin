using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TrabajoClaseXamarin.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.Media;
using Plugin.Media.Abstractions;

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
            this.User.Id = 1;
            this.User.Username = "LinuxPingu";
            LstMsgs = await MessageModel.getAllMsg();
        }

        public async void InitCommands()
        {
            SendTextCommand = new Command(this.SendText);
            ScrollListCommand = new Command(this.ScrollList);
            SendImgCommand = new Command(this.SendImg);
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

        #region User

        private UserModel user = new UserModel();

        public UserModel User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        #endregion

        #endregion

        #region Commands


        public ICommand SendTextCommand { get; set; }

        public ICommand ScrollListCommand { get; set; }
        public ICommand SendImgCommand { get; set; }

        public async void SendText()
        {
            if (!string.IsNullOrEmpty(this.TextToSend))
            {
                bool chk = await MessageModel.SendMsg(this.TextToSend);
                LstMsgs.Add(new MessageModel { User = "LinuxPingu", Message = this.TextToSend, isText = true }) ;
                TextToSend = string.Empty;
            }
        }

        public async void SendImg()
        {
            try
            {
                await CrossMedia.Current.Initialize();
                MediaFileModel file = new MediaFileModel();
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se soporta la funcionalidad", "OK");
                }
                else
                {
                    var mediaOptions = new PickMediaOptions() { PhotoSize=PhotoSize.Medium };
                    var selectedImage = await CrossMedia.Current.PickPhotoAsync(mediaOptions);
                    file.Path = ImageSource.FromStream(() => selectedImage.GetStream());
                
                    LstMsgs.Add(new MessageModel { User = "LinuxPingu", isText = false, Media= file}) ;

                }

               
              

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: "+e);
            }
      
        }

        public void ScrollList()
        {

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
