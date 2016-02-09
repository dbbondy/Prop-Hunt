using System;
using System.Collections.Generic;
using Inventory_Manager.Domain;
using System.Data.SQLite;
using System.Data.Common;

namespace Inventory_Manager.Repositories
{
    public class PrefixRepository : IRepository<Domain.Prefix>
    {

        IEnumerable<Prefix> IRepository<Prefix>.getList
        {
            get
            {
                // get the connection
                using (var dbConnection = new SQLiteConnection("Data Source=InventoryDB.sqlite;Version=3;"))
                {
                    dbConnection.Open();

                    using (var transaction = dbConnection.BeginTransaction())
                    {
                        using (var command = new SQLiteCommand(dbConnection))
                        {
                            command.CommandText = "SELECT * from prefix;";
                            using (DbDataReader reader = command.ExecuteReader())
                            {
                                // get all current prefixes in DB and return them.
                                List<Prefix> prefixes = new List<Prefix>();
                                while (reader.Read())
                                {
                                    Prefix prefix = mapData(reader);
                                    prefixes.Add(prefix);
                                }
                                return prefixes;
                            }
                        }
                    }
                }
            }
        }

        private Prefix mapData(DbDataReader reader)
        {
            // map the raw data from DB columns to a meaningful object and return it.
            int id = Convert.ToInt32(reader["prefix_id"]);
            string prefix_name = (string)reader["prefix_name"];
            string prefix_desc = (string)reader["prefix_desc"];

            Prefix prefix = new Prefix { Id = id, Name = prefix_name, Description = prefix_desc };

            return prefix;
        }

        void IRepository<Prefix>.add(Prefix item)
        {
            throw new NotImplementedException();
        }

        void IRepository<Prefix>.delete(Prefix item)
        {
            throw new NotImplementedException();
        }

        Prefix IRepository<Prefix>.update(Prefix item)
        {
            throw new NotImplementedException();
        }
    }
}
