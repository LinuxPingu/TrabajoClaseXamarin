﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoClaseXamarin.ModelViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrabajoClaseXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : ContentPage
    {
        public MenuView()
        {
            InitializeComponent();
            BindingContext = MenuViewModel.getInstance();
        }
    }
}