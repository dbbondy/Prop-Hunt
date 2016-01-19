using System;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

namespace Inventory_Manager.Utility
{
    static class DbCreateUtil
    {
        #region
        public static void CreateTables()
        {
            // TODO: need to obtain correct table names and schema... test it on H2 before putting it in here.

            SQLiteConnection.CreateFile("InventoryDB.sqlite");

            using (var dbConnection = new SQLiteConnection("Data Source=InventoryDB.sqlite;Version=3;"))
            {
                using (var transaction = dbConnection.BeginTransaction())
                {
                    #region create prefix table
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "CREATE TABLE IF NOT EXISTS prefix" +
                                                "(prefix_id INTEGER PRIMARY KEY ASC, prefix_name TEXT, prefix_desc TEXT)";
                        command.ExecuteNonQuery();
                    }
                    #endregion

                    #region insert core prefix data
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT OR IGNORE INTO prefix (prefix_name, prefix_desc) VALUES('COS-', 'Costumes')";
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT OR IGNORE INTO prefix (prefix_name, prefix_desc) VALUES('PR-', 'Props')";
                        command.ExecuteNonQuery();
                    }
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT OR IGNORE INTO prefix (prefix_name, prefix_desc) VALUES('SP-', 'Set-Pieces')";
                        command.ExecuteNonQuery();
                    }

                    #endregion

                    #region verify there are at least 3 rows in the prefix table
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "SELECT COUNT(*) from prefix";
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Debug.Assert(reader.GetInt32(0) < 3, "Missing Inventory Prefixes!"); // if there are not three rows after attempting to create the core data, throw an error to let us know.
                            }
                        }
                    }

                    #endregion

                    transaction.Commit();
                }
            }
        }
        #endregion
    }
}
