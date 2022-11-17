﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BookList.Views
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            this.Title = "List of Books";

            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Add book";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Check List";
            button.Clicked += Button_Get_Clicked;
            stackLayout.Children.Add(button);


            Content = stackLayout;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBook());
        }

        private async void Button_Get_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllBooksPage());
        }
    }
}