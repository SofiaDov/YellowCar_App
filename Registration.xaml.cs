using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
	
	public partial class Registration : ContentPage
	{
        Entry log ;
        Entry pas;
        Entry fn;
        Entry sn;
        Entry age;
        Entry city;
        Entry phone;
        Traveler tr;
		public Registration ()
		{
            Title = "Yellow car";
            StackLayout stack = new StackLayout();
            
            Label sub = new Label
            {
                Text = "Реєстрація",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
             log = new Entry { Placeholder = "Логін" };
             pas = new Entry { Placeholder = "Пароль", IsPassword = true};
             fn = new Entry { Placeholder = "Ім'я" };
             sn = new Entry { Placeholder = "Прізвище" };
             age = new Entry { Placeholder = "Вік" };
             city = new Entry { Placeholder = "Місто" };
             phone = new Entry { Placeholder = "Телефон" };
            
            Button reg = new Button
            {
                Text = "Зареєструватися",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            reg.Clicked += Reg_Clicked;
            stack.Children.Add(sub);
            stack.Children.Add(log);
            stack.Children.Add(pas);
            stack.Children.Add(fn);
            stack.Children.Add(sn);
            stack.Children.Add(phone);
            stack.Children.Add(city);
            stack.Children.Add(age);          
            stack.Children.Add(reg);
            ScrollView scrollView = new ScrollView();
            scrollView.Content = stack;
            Content = scrollView;            
		}

        private void Reg_Clicked(object sender, EventArgs e)
        {
            if (NoE(age.Text) || NoE(city.Text) || NoE(fn.Text) || NoE(sn.Text) || NoE(log.Text) || NoE(pas.Text) || NoE(phone.Text))
            {
                DisplayAlert("Порожня строка", "Введіть усі дані", "Ok");
            }
            else
            {
                tr = new Traveler();
                tr.Age = age.Text;
                tr.Age = city.Text;
                tr.FName = fn.Text;
                tr.SName = sn.Text;
                tr.Login = log.Text;
                tr.Password = pas.Text;
                tr.Phone = phone.Text;
                App.Database.SaveTraveler(tr);
                //this.Navigation.PopAsync();
                DisplayAlert("Вітаємо", "Ви зареєстровані", "Ok");
                //Navigation.PopAsync();
                //NavigationPage navPage = (NavigationPage)App.Current.MainPage;
                //((MainPage)navPage.CurrentPage).DisplayStack();
            }
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