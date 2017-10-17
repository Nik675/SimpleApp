using System;
using SQLite;
using System.IO;
using Xamarin.Forms;
using SimpleApp.iOS.Services;
using SimpleApp.Interfaces;

[assembly: Dependency(typeof(FileDatabase))]
namespace SimpleApp.iOS.Services
{
    public class FileDatabase : IFileDatabase
    {
        public SQLiteConnection GetConnection()
        {
            var fileName = "Ideas.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var connection = new SQLiteConnection(path);

            return connection;
        }
    }
}