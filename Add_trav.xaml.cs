using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Add_trav : ContentPage
	{
        DatePicker dp;
        Label sub;
        Entry from_trav;
        Entry where_trav;
        Button add;
        Travel tr = new Travel();
		public Add_trav ()
		{
            Title = "Yellow car";
            StackLayout stack = new StackLayout();
            dp = new DatePicker
            {
                Format = "D",
                MaximumDate = DateTime.Now.AddDays(7),
                MinimumDate = DateTime.Now.AddDays(-7)
            };
            sub = new Label
            {
                Text = "Додати поїздку",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            from_trav = new Entry { Placeholder = "Звідки" };
            where_trav = new Entry { Placeholder = "Куди" };          
            add = new Button
            {
                Text = "Додати",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            add.Clicked += Add_Clicked;
            stack.Children.Add(sub);
            stack.Children.Add(from_trav);
            stack.Children.Add(where_trav);
            stack.Children.Add(dp);
            stack.Children.Add(add);
            Content = stack;
            
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            //try
            //{

            //}
            //catch
            //{
            //}
            if (NoE(from_trav.Text))
            {
                DisplayAlert("Порожня строка", "Введіть усі дані", "Ok");
            }
            else
                tr.From = from_trav.Text;
            if (NoE(where_trav.Text))
            {
                DisplayAlert("Порожня строка", "Введіть усі дані", "Ok");
            }
            else
                tr.Where = where_trav.Text;                       
            tr.Date = dp.Date;
            tr.Name = App.tra_add.FName + "  " + App.tra_add.SName;
            tr.Phone = App.tra_add.Phone;
            App.Database.SaveTravel(tr);
            DisplayAlert("Вітаємо", "Ваша поїздка додана", "Ok");
        }

        private bool NoE(string tr)
        {
            if (String.IsNullOrEmpty(tr))
                return true;
            else
                return false;
        }
    }
}