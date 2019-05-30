using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace App2
{
    public class Repo
    {
        SQLiteConnection database;
        public Repo(string filename)
        {
            //string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            //database = new SQLiteConnection(databasePath);
            //database.CreateTable<Friend>();

            database = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),filename));
            database.CreateTable<Traveler>();
            database.CreateTable<Travel>();
            //InitD();
        }
        public IEnumerable<Travel> GetTravel()
        {
            return (from i in database.Table<Travel>() select i).ToList();

        }
        public Travel GetTravel(int id)
        {
            return database.Get<Travel>(id);
        }
        public IEnumerable<Traveler> GetTraveler()
        {
            return (from i in database.Table<Traveler>() select i).ToList();

        }
        public Traveler GetTraveler(int id)
        {
            return database.Get<Traveler>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Travel>(id);
        }
        public int SaveTravel(Travel item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public int SaveTraveler(Traveler item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public void InitD()
        {
            Traveler t1 = new Traveler();
            Traveler t2 = new Traveler();
            t1.Age = "21";
            t1.City = "Lviv";
            t1.FName = "Pet";
            t1.SName = "Kor";
            t1.Login = "f12u";
            t1.Password = "123";
            t1.Phone = "21333";
            t2.Age = "56";
            t2.City = "Kar";
            t2.FName = "Din";
            t2.SName = "Kor";
            t2.Login = "der";
            t2.Password = "321";
            t2.Phone = "4574";
            SaveTraveler(t1);
            SaveTraveler(t2);
        }
        public void InitTR()
        {
            Travel t1 = new Travel();
            Travel t2 = new Travel();
            t1.Date = DateTime.Now.Date.AddDays(3);
            t1.Name = "Pet Kor";
            t1.From = "Lviv";
            t1.Where = "Kara";
            t1.Phone = "21333";

            t2.Date = DateTime.Now.Date.AddDays(2);
            t2.Name = "Din Kor";
            t2.Phone = "4574";
            t2.From = "Lviv";
            t2.Where = "Kara";
            SaveTravel(t1);
            SaveTravel(t2);
        }
    }
}
