using System.ComponentModel;
using AppMobileRessources.ViewModels;
using Xamarin.Forms;

namespace AppMobileRessources.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}