using Inventory_Manager.Domain;
using Inventory_Manager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Manager.Forms
{
    public partial class AddPrefixForm : Form {

        private PrefixRepository repo;

        public Prefix NewPrefix { get; set; }

        public AddPrefixForm()
        {
            InitializeComponent();

            repo = new PrefixRepository();
        }

        private Boolean InputCompleted() {
            string prefixInput = PrefixTxtBox.Text;
            string descriptionInput = DescriptionTxtBox.Text;

            List<TextBox> textboxes = Controls.OfType<TextBox>().ToList();

            TextBox missingInputTxtBox = textboxes.Find(txtbox => String.IsNullOrEmpty(txtbox.Text));

            return missingInputTxtBox == null;
        }


        private void DescriptionTxtBox_TextChanged(object sender, EventArgs e) {
            AddBtn.Enabled = InputCompleted();
        }

        private void PrefixTxtBox_TextChanged(object sender, EventArgs e) {
            AddBtn.Enabled = InputCompleted();
        }

        private void AddBtn_Click(object sender, EventArgs e) {
            string prefixInput = PrefixTxtBox.Text;
            string descriptionInput = DescriptionTxtBox.Text;

            if (!repo.containsPrefixByName(prefixInput)) {
                #region insert new prefix

                Prefix prefix = new Prefix { Name = prefixInput, Description = descriptionInput };

                //because PrefixRepository can implement > 1 interface, need to specify which interface we want to call from to remove ambiguity.
                // not entirely sure why i need this as i'm only implementing one interface... but oh well.
                //http://stackoverflow.com/questions/2669031/compilation-error-the-modifier-public-is-not-valid-for-this-item-while-expl
                (repo as IRepository<Prefix>).add(prefix);

                //TODO: maybe send added prefix to previous window? or reload list?

                this.Close();

                #endregion
            } else {
                #region display "not unique name" message to user.
                MessageBox.Show("This prefix name is not unique!", "Not unique", MessageBoxButtons.OK, MessageBoxIcon.Error);

                PrefixTxtBox.Focus();
                #endregion
            }

        }
    }
}
