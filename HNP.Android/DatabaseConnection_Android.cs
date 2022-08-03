﻿using HNP.Droid;
using SQLite;
using System.IO;
[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]

namespace HNP.Droid
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "HNP_db.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}