using Inventory_Manager.Domain;
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

        public Prefix NewPrefix { get; set; }

        public AddPrefixForm()
        {
            InitializeComponent();
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
    }
}
