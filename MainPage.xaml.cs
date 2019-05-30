using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        Entry log;
        Entry pas;

        public MainPage()
        {
            Title = "Yellow Car";         
            StackLayout st = new StackLayout();
            Label sub = new Label
            {
                Text = "Шукай попутчиків разом з нами))",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 12
            };
            log = new Entry
            {
                Placeholder = "Логін",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                
            };
            pas = new Entry
            {
                Placeholder = "Пароль",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsPassword = true
            };
            Button ent_but = new Button
            {
                Text = "Увійти",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Button reg_but = new Button
            {
                Text = "Зареєструватися",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            ent_but.Clicked += enterOnClick;
            reg_but.Clicked += registrOnClick;
            st.Children.Add(sub);           
            st.Children.Add(log);
            st.Children.Add(pas);
            st.Children.Add(ent_but);
            st.Children.Add(reg_but);         
            Content = st;
        }
        private async void enterOnClick(object sender, EventArgs e)
        {            
           
            try
            {
                App.login_trav = App.Database.GetTraveler();
                foreach (var t in App.login_trav)
                {
                    if (t.Login == log.Text && t.Password == pas.Text)
                    {
                        App.tra_add = t;
                    }
                }
                if (App.tra_add.FName != null)
                {
                    await Navigation.PushModalAsync(new NavigationPage(new Search_trav()), true);
                }
                else
                {
                    await DisplayAlert("Error","Не правильний пароль або логін", "Ok");
                }
            }
            catch (Exception ex)
            {
               await DisplayAlert("Помилака","Не правильний пароль або логін", "Ok");
            }
        }
        private async void registrOnClick(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushModalAsync(new Registration());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }     

    }
}
