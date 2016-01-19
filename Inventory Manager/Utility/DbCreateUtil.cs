using System;
using System.Data.SQLite;
using System.IO;

namespace Inventory_Manager.Utility
{
    static class DbCreateUtil
    {
        private static readonly string FILE_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "InventoryDBExists.file");

        private static bool dbExists()
        {
            bool dbExists = File.Exists(FILE_PATH);
            return dbExists;
        }

        public static void CreateTables()
        {
            // TODO: need to obtain correct table names and schema... test it on H2 before putting it in here.

            if (!dbExists())
            {
                File.Create(FILE_PATH);

                SQLiteConnection.CreateFile("InventoryDB.sqlite");

                SQLiteConnection dbConnection = new SQLiteConnection("Data Source=InventoryDB.sqlite;Version=3;");
                dbConnection.Open();

                using (var command = new SQLiteCommand(dbConnection))
                {
                    using (var transaction = dbConnection.BeginTransaction())
                    {
                        command.CommandText = "CREATE TABLE test2 (test_col1 VARCHAR(25), test_col2 INT)";
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }
            }
           
        }
    }
}
