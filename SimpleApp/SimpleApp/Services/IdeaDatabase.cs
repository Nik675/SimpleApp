using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using SimpleApp.Models;
using SimpleApp.Interfaces;

namespace SimpleApp.Services
{
    public class IdeaDatabase : IIdeaDatabase
    {
        private SQLiteConnection _connection;

        public IdeaDatabase(IFileDatabase iFileDatabase)
        {
            _connection = iFileDatabase.GetConnection();
            _connection.CreateTable<Idea>();
        }

        public List<Idea> GetAll()
        {
            return (from t in _connection.Table<Idea>()
                    select t).OrderByDescending(x => x.CreatedOn).ToList();
        }

        public Idea Get(int id)
        {
            return _connection.Table<Idea>().FirstOrDefault(t => t.ID == id);
        }

        public void Delete(int id)
        {
            _connection.Delete<Idea>(id);
        }

        public void Add(String title, String description)
        {
            Idea idea = new Idea
            {
                Title = title,
                Description = description,
                CreatedOn = DateTime.Now
            };

            _connection.Insert(idea);
        }
    }
}
