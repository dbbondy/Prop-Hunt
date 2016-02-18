using System;
using System.IO;

namespace Inventory_Manager.Utility {

    class DbUtil {

        public static readonly string DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "InventoryDB.db");
        public static readonly string ConnectionString = String.Format("Data Source={0};Version=3;", DbPath);

    }
}
