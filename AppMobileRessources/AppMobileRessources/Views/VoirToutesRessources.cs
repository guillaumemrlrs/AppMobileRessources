using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLite;
using Xamarin.Forms;
using AppMobileRessources.Models;

namespace AppMobileRessources.Views
{
    public class VoirToutesRessources : ContentPage
    {
        private ListView _listview;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public VoirToutesRessources()
        {
            this.Title = "Liste des ressources";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();
            _listview = new ListView();
            _listview.ItemsSource = db.Table<Ressources>().OrderBy(x => x.titre).ToList();
            stackLayout.Children.Add(_listview);

            Content = stackLayout;
        }
    }
}