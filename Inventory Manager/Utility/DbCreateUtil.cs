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

            using (var dbConnection = new SQLiteConnection(DbUtil.ConnectionString))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    #region create prefix table
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "CREATE TABLE IF NOT EXISTS prefix" +
                                                "(prefix_id INTEGER PRIMARY KEY ASC, prefix_name TEXT, prefix_desc TEXT, protected_prefix INTEGER DEFAULT 0)";
                        command.ExecuteNonQuery();
                    }
                    #endregion

                    #region insert core prefix data
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT OR IGNORE INTO prefix (prefix_id, prefix_name, prefix_desc, protected_prefix) VALUES(1, 'COS-', 'Costumes', 1)";
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT OR IGNORE INTO prefix (prefix_id, prefix_name, prefix_desc, protected_prefix) VALUES(2, 'PROP-', 'Props', 1)";
                        command.ExecuteNonQuery();
                    }
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT OR IGNORE INTO prefix (prefix_id, prefix_name, prefix_desc, protected_prefix) VALUES(3, 'SETP-', 'Set-Pieces', 1)";
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
                                int rows = reader.GetInt32(0);
                                Debug.Assert(rows >= 3, "Missing Inventory Prefixes!"); // if there are not three rows after attempting to create the core data, throw an error to let us know.
                            }
                        }
                    }

                    #endregion

                    transaction.Commit();
                }
                dbConnection.Close();
            }
        }
        #endregion
    }
}
