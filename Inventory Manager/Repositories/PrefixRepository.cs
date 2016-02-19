using System;
using System.Collections.Generic;
using Inventory_Manager.Domain;
using System.Data.SQLite;
using System.Data.Common;
using Inventory_Manager.Utility;

namespace Inventory_Manager.Repositories
{
    public class PrefixRepository : IRepository<Domain.Prefix>
    {

        IEnumerable<Prefix> IRepository<Prefix>.getList
        {
            get
            {
                // get the connection
                using (var dbConnection = new SQLiteConnection(DbUtil.ConnectionString))
                {
                    dbConnection.Open();
                    
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "SELECT * from prefix ORDER BY prefix_id ASC;";
                        using (DbDataReader reader = command.ExecuteReader())
                        {
                            // get all current prefixes in DB and return them.
                            List<Prefix> prefixes = new List<Prefix>();
                            while (reader.Read())
                            {
                                Prefix prefix = mapData(reader);
                                prefixes.Add(prefix);
                            }
                            dbConnection.Close();
                            return prefixes;
                        }
                    }
                }
            }
        }

        void IRepository<Prefix>.add(Prefix item)
        {
            using (var dbConnection = new SQLiteConnection(DbUtil.ConnectionString)) {

                dbConnection.Open();

                using (var transaction = dbConnection.BeginTransaction()) {

                    using (var command = new SQLiteCommand(dbConnection)) {
                        string valuesClause = String.Format("'{0}', '{1}'", item.Name, item.Description);
                        string sql = String.Format("INSERT INTO prefix (prefix_name, prefix_desc) VALUES({0})", valuesClause);

                        command.CommandText = sql;

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }

                dbConnection.Close();
            }

        }

        void IRepository<Prefix>.delete(Prefix item) {
            using (var connection = new SQLiteConnection(DbUtil.ConnectionString)) {
                connection.Open();

                using (var transaction = connection.BeginTransaction()) {

                    using (var command = new SQLiteCommand(connection)) {
                        
                        string sql = String.Format("DELETE FROM prefix WHERE prefix_id = '{0}'", item.Id);
                        command.CommandText = sql;

                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                connection.Close();
            }
        }

        Prefix IRepository<Prefix>.update(Prefix item)
        {
            throw new NotImplementedException();
        }

        public bool containsPrefixByName(string name) {

            if (!String.IsNullOrEmpty(name)) {
                // get the connection
                using (var dbConnection = new SQLiteConnection(DbUtil.ConnectionString)) {
                    dbConnection.Open();

                    using (var command = new SQLiteCommand(dbConnection)) {

                        string sql = String.Format("SELECT * from prefix where prefix_name = '{0}'", name);
                        command.CommandText = sql;

                        using (DbDataReader reader = command.ExecuteReader()) {
                            // get all current prefixes in DB and return them.
                            List<Prefix> prefixes = new List<Prefix>();
                            while (reader.Read()) {
                                //TODO: maybe don't need to map. just check size of reader and return then. debug this and figure it out.
                                Prefix prefix = mapData(reader);
                                prefixes.Add(prefix);
                            }
                            dbConnection.Close();
                            return prefixes.Count != 0;
                        }
                    }
                    
                }
            } else { // if there is no name to look for, throw an error and fail fast.
                throw new ArgumentNullException("name", "name is blank. cannot be blank.");
            }

        }
        private Prefix mapData(DbDataReader reader) {
            // map the raw data from DB columns to a meaningful object and return it.
            int id = Convert.ToInt32(reader["prefix_id"]);
            string prefix_name = (string)reader["prefix_name"];
            string prefix_desc = (string)reader["prefix_desc"];

            Prefix prefix = new Prefix { Id = id, Name = prefix_name, Description = prefix_desc };

            return prefix;
        }
    }
}
