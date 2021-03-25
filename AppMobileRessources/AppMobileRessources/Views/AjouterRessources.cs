using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AppMobileRessources.Models;
using SQLite;

using Xamarin.Forms;

namespace AppMobileRessources.Views
{
    public class AjouterRessources : ContentPage
    {
        private Entry _titreEntry;
        private Entry _contenuEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"myDB.db3");
        public AjouterRessources()
        {
            this.Title = "Ajouter une ressource";

            StackLayout stackLayout = new StackLayout();

            _titreEntry = new Entry();
            _titreEntry.Keyboard = Keyboard.Text;
            _titreEntry.Placeholder = "Titre de la ressource";
            stackLayout.Children.Add(_titreEntry);

            _contenuEntry = new Entry();
            _contenuEntry.Keyboard = Keyboard.Text;
            _contenuEntry.Placeholder = "Titre de la ressource";
            stackLayout.Children.Add(_contenuEntry);

            _saveButton = new Button();
            _saveButton.Text = "Add";
            _saveButton.Clicked += _saveButton_Clicked;

            Content = stackLayout;
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Ressources>();

            var maxPk = db.Table<Ressources>().OrderByDescending(r => r.id).FirstOrDefault();

            Ressources ressources = new Ressources()
            {
                id=(maxPk == null ? 1 : maxPk.id+1),
                titre = _titreEntry.Text,
                contenu = _contenuEntry.Text
            };
            db.Insert(ressources);
            await DisplayAlert(null,ressources.titre + "Saved", "Ok");
            await Navigation.PopAsync();
        }
    }
}