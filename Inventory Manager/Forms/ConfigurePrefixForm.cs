using System.Windows.Forms;
using Inventory_Manager.Repositories;
using Inventory_Manager.Domain;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Inventory_Manager.Forms
{
    public partial class ConfigurePrefixForm : Form
    {
        private IRepository<Prefix> repo;
        private IEnumerable<Prefix> prefixList;

        public ConfigurePrefixForm()
        {
            InitializeComponent();

            repo = new PrefixRepository();

            loadPrefixes();
        }

        private void loadPrefixes()
        {
            IEnumerable<Prefix> prefixes = repo.getList;
            prefixList = prefixes;

            prefixListbox.DataSource = prefixes;
            prefixListbox.DisplayMember = "Name";
            prefixListbox.ValueMember = "Id";
        }

        private void prefixListbox_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox lbox = (ListBox) sender;

            Prefix selectedPrefix = (Prefix)lbox.SelectedItem;

            deleteBtn.Enabled = selectedPrefix.ProtectedPrefix == 0; 

            DescriptionLabel.Text = selectedPrefix.Description;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddPrefixForm form = new AddPrefixForm();

            Prefix newPrefix = new Prefix();
            form.NewPrefix = newPrefix;

            form.Show();

            

            //TODO: figure out binding newly added item back to list. 
            //TODO: maybe using this? https://msdn.microsoft.com/en-us/library/ms366768.aspx
            //TODO: or this https://msdn.microsoft.com/en-us/library/ms173171.aspx
        }

        private void deleteBtn_Click(object sender, EventArgs e) {
            Prefix selectedPrefix = (Prefix)prefixListbox.SelectedItem;

            repo.delete(selectedPrefix);

            loadPrefixes(); // inefficient but works for current version. TODO change this to remove just the single element and re-use the same data.
        }

        private void SearchTxtBox_TextChanged(object sender, EventArgs e) {
            TextBox txtBox = (TextBox) sender;
            string searchText = txtBox.Text;

            List<Prefix> matchedPrefixes = prefixList.Where(prefix => prefix.Name.StartsWith(searchText)).ToList();

            prefixListbox.DataSource = matchedPrefixes;
            prefixListbox.DisplayMember = "Name";
            prefixListbox.ValueMember = "Id";

            deleteBtn.Enabled = matchedPrefixes.Any();
        }
    }
}

//TODO: add 2 more columns to prefix table. "reserved system prefix" and "date/time added"