using System.Windows.Forms;
using Inventory_Manager.Repositories;
using Inventory_Manager.Domain;
using System.Collections.Generic;
using System;

namespace Inventory_Manager.Forms
{
    public partial class ConfigurePrefixForm : Form
    {
        private IRepository<Prefix> repo;

        public ConfigurePrefixForm()
        {
            InitializeComponent();

            repo = new PrefixRepository();

            loadPrefixes();
        }

        #region
        private void loadPrefixes()
        {
            IEnumerable<Prefix> prefixes = repo.getList;

            prefixListbox.DataSource = prefixes;
            prefixListbox.DisplayMember = "Name";
            prefixListbox.ValueMember = "Id";
        }
        #endregion

        private void prefixListbox_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox lbox = (ListBox) sender;

            Prefix selectedPrefix = (Prefix) lbox.SelectedItem;

            DescriptionLabel.Text = selectedPrefix.Description;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddPrefixForm form = new AddPrefixForm();

            form.Show();

            //TODO: figure out binding newly added item back to list. 
            //TODO: maybe using this? https://msdn.microsoft.com/en-us/library/ms366768.aspx
            //TODO: or this https://msdn.microsoft.com/en-us/library/ms173171.aspx
        }
    }
}
