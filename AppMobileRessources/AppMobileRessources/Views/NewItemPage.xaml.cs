using System;
using System.Collections.Generic;
using System.ComponentModel;
using AppMobileRessources.Models;
using AppMobileRessources.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileRessources.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}