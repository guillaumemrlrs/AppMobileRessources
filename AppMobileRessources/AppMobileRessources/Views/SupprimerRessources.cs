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
    public class SupprimerRessources : ContentPage
    {
        private ListView _listView;
        private Button _button;
        Ressources _ressources = new Ressources();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");


        public SupprimerRessources()
        {
            this.Title = "Supprimer Ressource";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Ressources>().OrderBy(x => x.titre).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _button = new Button();
            _button.Text = "Supprimer";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _ressources = (Ressources)e.SelectedItem;

        }
        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<Ressources>().Delete(x => x.id == _ressources.id);
            await Navigation.PopAsync();
        }
    }
}