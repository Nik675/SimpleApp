using SimpleApp.Interfaces;
using System.IO;
using Xamarin.Forms;
using SimpleApp.Droid.Services;
using SQLite;

[assembly: Dependency(typeof(FileDatabase))]
namespace SimpleApp.Droid.Services
{
    public class FileDatabase : IFileDatabase
    {
        public SQLiteConnection GetConnection()
        {
            var fileName = "Ideas.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);
            var connection = new SQLiteConnection(path);

            return connection;
        }
    }
}