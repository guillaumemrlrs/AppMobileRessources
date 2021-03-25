using System;
using AppMobileRessources.Services;
using AppMobileRessources.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileRessources
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new PagePrincipale());
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
