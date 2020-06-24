using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Friends.Models
{
    public static class Constants
    {
        public const string BaseURL = "http://192.168.68.112:8091";
        public const int MaxMembers = 7;
        public const int MinMembers = 1;
        public const string DatabaseFilename = "FriendsSQLite.db3";
        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
