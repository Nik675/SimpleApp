using System;
using SQLite;

namespace SimpleApp.Models
{
    public class Idea
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
