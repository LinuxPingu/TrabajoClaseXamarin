using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TrabajoClaseXamarin.Models;
using Xamarin.Forms;

namespace TrabajoClaseXamarin.ModelViews
{
    public class RegisterViewModel: INotifyPropertyChanged
    {
        #region Singleton

        public static RegisterViewModel instance = null;


        public RegisterViewModel()
        {
            InitClass();
            InitCommands();
        }

        public static RegisterViewModel getInstance()
        {
            if (instance == null)
            {
                instance = new RegisterViewModel();
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

        #region Variables

        #region User

        private UserModel user = new UserModel();

        public UserModel User
        {
            get { return user; }
            set { user = value; 
                OnPropertyChanged("User"); }
        }


        #endregion

        #endregion

        #region Inits

        public void InitClass()
        {

        }

        public void InitCommands()
        {
            AddUserCommand = new Command(this.AddUser);
        }

        #endregion

        #region Commands 

        ICommand AddUserCommand { get; set; }

        public async void AddUser()
        {
            try
            {
                var realm = Realm.GetInstance();
                var lst = realm.All<UserModel>();
                User.Id = (lst.AsRealmCollection<UserModel>().Count)+1;
                Console.WriteLine("Count: "+User.Id);

                realm.Write(()=> { realm.Add(User); });

                User = new UserModel();
                await Application.Current.MainPage.DisplayAlert("Success","User Created","OK");
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error", "OK");
                Console.WriteLine("Error: "+e);
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
