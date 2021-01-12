using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrabajoClaseXamarin.Models;
using TrabajoClaseXamarin.Views;
using Xamarin.Forms;

namespace TrabajoClaseXamarin.ModelViews
{
    public class LoginViewModel:INotifyPropertyChanged
    {
        #region Singleton

        public static LoginViewModel instance = null;

        private LoginViewModel()
        {
            InitClass();
            InitCommands();
        }

        public static LoginViewModel getInstance()
        {
            if (instance == null)
            {
                instance = new LoginViewModel();
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

        public void InitClass()
        {

        }

        public void InitCommands()
        {
            LoginCommand = new Command(this.Login);
            EnterRegisterCommand = new Command(this.EnterRegister);
        }

        #endregion

        #region Variables

        #region User Model

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

        public ICommand LoginCommand { get; set; }
        public ICommand EnterRegisterCommand { get; set; }


        public void Login()
        {
            NavigationPage navigation = new NavigationPage(new HomeView());
           App.Current.MainPage = new MasterDetailPage
            {
                Master = new MenuView(),
                Detail = navigation
            };
        }

        public async void EnterRegister()
        {
          await  Application.Current.MainPage.Navigation.PushModalAsync(new RegisterView());
            
        }

        #endregion



        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
