using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TrabajoClaseXamarin.Models;
using TrabajoClaseXamarin.Views;
using Xamarin.Forms;

namespace TrabajoClaseXamarin.ModelViews
{
    public class HomeViewModel : INotifyPropertyChanged
    {

        #region Singleton

        public static HomeViewModel instance = null;

        public HomeViewModel()
        {
            InitClass();
            InitCommands();
        }

        public static HomeViewModel getInstance()
        {
            if (instance == null)
            {
                instance = new HomeViewModel();
            }

            return instance;
        }

        public static void deteleInstance()
        {
            if (instance != null)
            {
                instance = null;
            }
        }

        #endregion

        #region Variables

        #region Doctor List
        private ObservableCollection<DoctorModel> lstDoctors = new ObservableCollection<DoctorModel>();
        public ObservableCollection<DoctorModel> LstDoctors
        {
            get
            {
                return lstDoctors;
            }
            set
            {
                lstDoctors = value;
                OnPropertyChanged("LstDoctors");
            }
        }

        #endregion

        #region Selected Doctor
        public DoctorModel currentDoctor = new DoctorModel();
        public DoctorModel CurrentDoctor
        {
            get
            {
                return this.currentDoctor;
            }
            set
            {
                currentDoctor = value;
                OnPropertyChanged("CurrentDoctor");
            }

        }
        #endregion

        #endregion

        #region Commands

        public void InitClass()
        {
            FillList();
        }
        public void InitCommands()
        {
            EnterDoctorDetailCommand = new Command<string>(this.EnterDoctorDetail);
        }

        public ICommand EnterDoctorDetailCommand { get; set; }

        public async void EnterDoctorDetail(string Id)
        {
            CurrentDoctor = LstDoctors.Where(x => x.Id == Id).FirstOrDefault();
            await Application.Current.MainPage.Navigation.PushModalAsync(new DoctorDetailView());

        }

        public void FillList()
        {
            lstDoctors.Add(new DoctorModel { Id = "1", FirstName = "Joe", LastName = "Doe", Email = "test@test.com", Picture = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg" });
            lstDoctors.Add(new DoctorModel { Id = "2", FirstName = "John", LastName = "Merkel", Email = "test@test.com", Picture = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg" });
            lstDoctors.Add(new DoctorModel { Id = "3", FirstName = "Carl", LastName = "Heinz", Email = "test@test.com", Picture = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg" });
            lstDoctors.Add(new DoctorModel { Id = "4", FirstName = "Megan", LastName = "Scott", Email = "test@test.com", Picture = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg" });
            lstDoctors.Add(new DoctorModel { Id = "5", FirstName = "Silvia", LastName = "Mars", Email = "test@test.com", Picture = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg" });
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
