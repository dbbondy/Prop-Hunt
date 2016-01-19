using System;
using System.Windows.Forms;

namespace Inventory_Manager.Forms
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfigurePrefixForm prefixForm = new ConfigurePrefixForm();
            prefixForm.Show();
        }

        private void OnExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
