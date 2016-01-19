using System;
using System.Windows.Forms;

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
           //TODO: call dbCreate
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.MainMenu());
        }

        static void createTables()
        {
            

            
        }
    }
}
