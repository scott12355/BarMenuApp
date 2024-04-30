using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarMenuApp
{
    public static class Constants
    {
        public const string DatabaseFilename = "MenuAppDb.db3";
        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite | // Open the database in read/write mode
            SQLite.SQLiteOpenFlags.Create | // Create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.SharedCache; // Enable multi-threaded database access
        public static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);

        public const string RestUrl = "https://retoolapi.dev/OLULz8/cocktails/1"; 

    }

}
