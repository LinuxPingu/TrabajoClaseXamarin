using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TrabajoClaseXamarin.Models;
using TrabajoClaseXamarin.Views;
using Xamarin.Forms;

namespace TrabajoClaseXamarin.ModelViews
{
    public class MenuViewModel: INotifyPropertyChanged
    {

        #region Singleton

        public static MenuViewModel instance = null;


        public MenuViewModel()
        {
            InitClass();
            InitCommands();
        }

        public static MenuViewModel getInstance()
        {
            if (instance == null)
            {
                instance = new MenuViewModel();
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

        #region Menu Item List

        private ObservableCollection<MenuModel> lstMenu = new ObservableCollection<MenuModel>();
        public ObservableCollection<MenuModel> LstMenu
        {
            get
            {
                return lstMenu;
            }
            set
            {
                lstMenu = value;
                OnPropertyChanged("LstMenu");
            }
        }

        #endregion

        #endregion


        #region Commands

        public void InitClass()
        {
            FillMenu();
        }

        public void InitCommands()
        {
            EnterMenuOptionCommand = new Command<int>(EnterMenuOption);
        }

        public ICommand EnterMenuOptionCommand { get; set; } 

        public async void EnterMenuOption(int opc)
        {
            switch (opc)
            {
                case 3:
                    await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new ChatView());
                    break;

                default:
                break;
            }
        }


        public void FillMenu()
        {
            LstMenu.Clear();
            LstMenu.Add(new MenuModel { Id=1, Name="Especialidades",Icon=""});
            LstMenu.Add(new MenuModel { Id = 2, Name = "Contacto", Icon = "" });
            LstMenu.Add(new MenuModel { Id=3,Name="Chat",Icon="" });
            
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
