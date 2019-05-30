using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App2
{
    [Table("Travel")]
    public class Travel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; }
        public string From { get; set; }
        public string Where { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
    