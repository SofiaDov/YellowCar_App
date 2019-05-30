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
	public partial class Search_trav : ContentPage
	{
        Entry from_trav, where_trav;
        DatePicker dp;

        public Search_trav ()
		{
            Title = "Yellow car";
            StackLayout stack = new StackLayout();
            dp = new DatePicker
            {
                Format = "D",
                MaximumDate = DateTime.Now.AddDays(7),
                MinimumDate = DateTime.Now.AddDays(-7)
            };
            Label sub = new Label
            {
                Text = "Знайти попутку",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            from_trav = new Entry { Placeholder = "Звідки" };
            where_trav = new Entry { Placeholder = "Куди" };
            Button search = new Button
            {
                Text = "Знайти",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Button add = new Button
            {
                Text = "Додати поїздку",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            add.Clicked += Add_Clicked;
            search.Clicked += Search_Clicked;
            stack.Children.Add(sub);
            stack.Children.Add(from_trav);
            stack.Children.Add(where_trav);
            stack.Children.Add(dp);
            stack.Children.Add(search);
            stack.Children.Add(add);
            Content = stack;
			//InitializeComponent ();
		}

        private async void Search_Clicked(object sender, EventArgs e)
        {
            try
            {
                var tr = App.Database.GetTravel();
                List<Travel> sort = new List<Travel>();
                foreach(var t in tr)
                {
                    if(t.From==from_trav.Text && t.Where==where_trav.Text /*&& t.Date == dp.Date*/)
                    {
                        sort.Add(t);
                    }
                }
                Show_trav st = new Show_trav(sort);
                //st.BindingContext = sort;
                await Navigation.PushModalAsync(new NavigationPage(st));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushModalAsync(new NavigationPage(new Add_trav()));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}