namespace Inventory_Manager.Forms
{
    partial class ConfigurePrefixForm
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
            this.prefixListbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // prefixListbox
            // 
            this.prefixListbox.ColumnWidth = 50;
            this.prefixListbox.FormattingEnabled = true;
            this.prefixListbox.Location = new System.Drawing.Point(55, 42);
            this.prefixListbox.Name = "prefixListbox";
            this.prefixListbox.Size = new System.Drawing.Size(148, 147);
            this.prefixListbox.TabIndex = 0;
            // 
            // ConfigurePrefixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.prefixListbox);
            this.Name = "ConfigurePrefixForm";
            this.Text = "ConfigurePrefixForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox prefixListbox;
    }
}