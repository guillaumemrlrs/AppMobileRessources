using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppMobileRessources.Views
{
    public class PagePrincipale : ContentPage
    {
        public PagePrincipale()
        {
            this.Title = "Sélectionner une option";
            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Ajouter une ressource";
            button.Clicked += Button_Clicked; ;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Voir les ressources";
            button.Clicked += Button_Get_Clicked; ;
            stackLayout.Children.Add(button);

            Content = stackLayout;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AjouterRessources());
        }

        private async void Button_Get_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VoirToutesRessources());
        }


    }
}