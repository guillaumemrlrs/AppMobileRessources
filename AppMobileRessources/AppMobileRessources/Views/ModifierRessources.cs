using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMobileRessources.Models;
using SQLite;
using System.IO;

using Xamarin.Forms;

namespace AppMobileRessources.Views
{
    public class ModifierRessources : ContentPage
    {
        private ListView _listView;
        private Entry _idRessources;
        private Entry _titreEntry;
        private Entry _contenuEntry;
        private Button _button;

        Ressources _ressources = new Ressources();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public ModifierRessources()
        {
            this.Title = "Modifier Ressource";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Ressources>().OrderBy(x => x.titre).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idRessources = new Entry();
            _idRessources.Placeholder = "ID";
            _idRessources.IsVisible = false;
            stackLayout.Children.Add(_idRessources);

            _titreEntry = new Entry();
            _titreEntry.Keyboard = Keyboard.Text;
            _titreEntry.Placeholder = "Titre";
            stackLayout.Children.Add(_titreEntry);

            _contenuEntry = new Entry();
            _contenuEntry.Keyboard = Keyboard.Text;
            _contenuEntry.Placeholder = "Contenu";
            stackLayout.Children.Add(_contenuEntry);

            _button = new Button();
            _button.Text = "Modifier";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);


            Content = stackLayout;
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Ressources ressources = new Ressources()
            {
                id = Convert.ToInt32(_idRessources.Text),
                titre = _titreEntry.Text,
                contenu=_contenuEntry.Text,
            };
            db.Update(ressources);
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _ressources = (Ressources)e.SelectedItem;
            _idRessources.Text = _ressources.id.ToString();
            _titreEntry.Text = _ressources.titre;
            _contenuEntry.Text = _ressources.contenu;

        }
    }
}