using BookList.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BookList.Views
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