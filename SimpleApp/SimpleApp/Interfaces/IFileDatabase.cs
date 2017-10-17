using SQLite;
using System;

namespace SimpleApp.Interfaces
{
    public interface IFileDatabase
    {
        SQLiteConnection GetConnection();
    }
}
