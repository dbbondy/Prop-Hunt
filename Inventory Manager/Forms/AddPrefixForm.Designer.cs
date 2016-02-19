namespace Inventory_Manager.Forms
{
    partial class AddPrefixForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PrefixLbl = new System.Windows.Forms.Label();
            this.PrefixTxtBox = new System.Windows.Forms.TextBox();
            this.DescriptionLbl = new System.Windows.Forms.Label();
            this.DescriptionTxtBox = new System.Windows.Forms.TextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.InfoLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PrefixLbl
            // 
            this.PrefixLbl.AutoSize = true;
            this.PrefixLbl.Location = new System.Drawing.Point(38, 24);
            this.PrefixLbl.Name = "PrefixLbl";
            this.PrefixLbl.Size = new System.Drawing.Size(36, 13);
            this.PrefixLbl.TabIndex = 0;
            this.PrefixLbl.Text = "Prefix:";
            // 
            // PrefixTxtBox
            // 
            this.PrefixTxtBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PrefixTxtBox.Location = new System.Drawing.Point(107, 21);
            this.PrefixTxtBox.MaxLength = 4;
            this.PrefixTxtBox.Name = "PrefixTxtBox";
            this.PrefixTxtBox.Size = new System.Drawing.Size(64, 20);
            this.PrefixTxtBox.TabIndex = 1;
            this.PrefixTxtBox.TextChanged += new System.EventHandler(this.PrefixTxtBox_TextChanged);
            // 
            // DescriptionLbl
            // 
            this.DescriptionLbl.AutoSize = true;
            this.DescriptionLbl.Location = new System.Drawing.Point(38, 57);
            this.DescriptionLbl.Name = "DescriptionLbl";
            this.DescriptionLbl.Size = new System.Drawing.Size(63, 13);
            this.DescriptionLbl.TabIndex = 2;
            this.DescriptionLbl.Text = "Description:";
            // 
            // DescriptionTxtBox
            // 
            this.DescriptionTxtBox.Location = new System.Drawing.Point(107, 54);
            this.DescriptionTxtBox.MaxLength = 200;
            this.DescriptionTxtBox.Name = "DescriptionTxtBox";
            this.DescriptionTxtBox.Size = new System.Drawing.Size(344, 20);
            this.DescriptionTxtBox.TabIndex = 3;
            this.DescriptionTxtBox.TextChanged += new System.EventHandler(this.DescriptionTxtBox_TextChanged);
            // 
            // AddBtn
            // 
            this.AddBtn.Enabled = false;
            this.AddBtn.Location = new System.Drawing.Point(217, 90);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 4;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // InfoLbl
            // 
            this.InfoLbl.AutoSize = true;
            this.InfoLbl.Location = new System.Drawing.Point(179, 24);
            this.InfoLbl.Name = "InfoLbl";
            this.InfoLbl.Size = new System.Drawing.Size(286, 13);
            this.InfoLbl.TabIndex = 5;
            this.InfoLbl.Text = "No need to add \"-\" to prefix. The system will do this for you.";
            // 
            // AddPrefixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 144);
            this.Controls.Add(this.InfoLbl);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.DescriptionTxtBox);
            this.Controls.Add(this.DescriptionLbl);
            this.Controls.Add(this.PrefixTxtBox);
            this.Controls.Add(this.PrefixLbl);
            this.Name = "AddPrefixForm";
            this.Text = "Add Prefix";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PrefixLbl;
        private System.Windows.Forms.TextBox PrefixTxtBox;
        private System.Windows.Forms.Label DescriptionLbl;
        private System.Windows.Forms.TextBox DescriptionTxtBox;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Label InfoLbl;
    }
}