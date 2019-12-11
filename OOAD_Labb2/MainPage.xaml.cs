using System;
using System.Collections.Generic;
using System.ComponentModel;
using OOAD_Labb2.ViewModel;
using Xamarin.Forms;

namespace OOAD_Labb2
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(new AstronautServices()); 
        }
    }
}
