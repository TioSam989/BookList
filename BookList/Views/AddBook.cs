using BookList.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BookList.Views
{
    public class AddBook : ContentPage
    {
        private Entry _NameEntry;
        private Entry _WriterEntry;
        private Button _SaveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public AddBook()
        {
            this.Title = "Add Book";

            StackLayout stackLayout = new StackLayout();

            _NameEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Book Name"
            };

            _WriterEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Writer"
            };

            _SaveButton = new Button();
            _SaveButton.Text = "Add";
            _SaveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_SaveButton);

            Content = stackLayout;


        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Book>();
            var maxPK = db.Table<Book>().OrderByDescending(x => x.Id).FirstOrDefault();

            Book book = new Book()
            {
                Id = (maxPK == null ? 1 : maxPK.Id + 1),
                Name = _NameEntry.Text,
                Writer = _WriterEntry.Text


            };

            db.Insert(book);
            await DisplayAlert(null, book.Name + "Book inserted", "OK");
            await Navigation.PopAsync();


    }
    }
}