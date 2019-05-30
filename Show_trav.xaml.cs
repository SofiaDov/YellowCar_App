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
	public partial class Show_trav : ContentPage
	{
        public Show_trav(List<Travel> sort)
        {
            Title = "Yellow car";
            StackLayout st = new StackLayout();
            Grid tre = new Grid();

            tre.ColumnDefinitions = new ColumnDefinitionCollection()
            {
                new ColumnDefinition(){Width=GridLength.Auto},
                //new ColumnDefinition(){Width=GridLength.Auto}
            };
            tre.RowDefinitions = new RowDefinitionCollection();
            int i = 0;
            foreach(var t in sort)
            {
                tre.Children.Add(new Label() { Text = t.From + ' ' + t.Where + ' ' + t.Date }, 0, i);
                tre.Children.Add(new Label() { Text = t.Name + ' ' + t.Phone}, 0, i+1);               
                i += 2;
            }

            //ListView lv = new ListView();
            //string[] stre = new string[sort.Count];
            //int i = 0;          
            //foreach (var t in sort)
            //{
            //    stre[i] = t.From + " - " + t.Where + ' ' + t.Date.ToString() + '\n' + t.Name + ' ' + t.Phone;
            //    i++;
            //}
            
            //lv.ItemsSource = stre;         
            //st.Children.Add(lv);
            ScrollView scrollView = new ScrollView();
            scrollView.Content = tre;
            //scrollView.Content = st;
            st.Children.Add(scrollView);
            Content = st;
        }
    }
}