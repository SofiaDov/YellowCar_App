using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App2
{
    [Table("Traveler")]
    public class Traveler
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; }
        public string FName { get; set; }
        public string SName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Age { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
    }
}
