﻿using System;
using TrabajoClaseXamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrabajoClaseXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
