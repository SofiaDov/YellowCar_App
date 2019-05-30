using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App2
{
    
    public partial class App : Application
    {
        public const string DATABASE_NAME = "YellowCar.db";
        static Repo db;
        public static IEnumerable<Traveler> login_trav;
        public static Traveler tra_add;
        public static Repo Database
        {
            get
            {
                if (db == null)
                {
                    db = new Repo(DATABASE_NAME);
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();
            //login_trav = db.GetTraveler();
            //Database.InitTR();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
