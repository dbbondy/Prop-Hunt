using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Inventory_Manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            String filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "InventoryDBExists.file");
            bool dbExists = File.Exists(filePath);
            if (!dbExists)
            {
                File.Create(filePath);
                createTables();
            }
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.MainMenu());
        }

        static void createTables()
        {
            //TODO: need to obtain correct table names and schema... test it on H2 before putting it in here.
            //SQLiteConnection.CreateFile("InventoryDB.sqlite");

            //SQLiteConnection dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            //dbConnection.Open();

            //using (var command = new SQLiteCommand(dbConnection))
            //{
            //    using (var transaction = dbConnection.BeginTransaction())
            //    {
            //        command.CommandText = "CREATE TABLE test2 (test_col1 VARCHAR(25), test_col2 INT)";
            //        command.ExecuteNonQuery();
            //        transaction.Commit();
            //    }
            //}

            
        }
    }
}
