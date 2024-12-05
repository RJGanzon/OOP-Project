namespace WinFormsApp12
{
    partial class DeleteAcc
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteAcc));
            listBox1 = new ListBox();
            btnDeleteAcc = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(10, 70);
            listBox1.Margin = new Padding(3, 2, 3, 2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(307, 364);
            listBox1.TabIndex = 0;
            // 
            // btnDeleteAcc
            // 
            btnDeleteAcc.BackColor = Color.Transparent;
            btnDeleteAcc.CustomizableEdges = customizableEdges1;
            btnDeleteAcc.DisabledState.BorderColor = Color.DarkGray;
            btnDeleteAcc.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDeleteAcc.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDeleteAcc.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDeleteAcc.FillColor = Color.Red;
            btnDeleteAcc.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteAcc.ForeColor = Color.White;
            btnDeleteAcc.Location = new Point(10, 464);
            btnDeleteAcc.Margin = new Padding(3, 2, 3, 2);
            btnDeleteAcc.Name = "btnDeleteAcc";
            btnDeleteAcc.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnDeleteAcc.Size = new Size(311, 42);
            btnDeleteAcc.TabIndex = 1;
            btnDeleteAcc.Text = "Delete Account";
            btnDeleteAcc.Click += btnDeleteAcc_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 31);
            label1.Name = "label1";
            label1.Size = new Size(189, 29);
            label1.TabIndex = 2;
            label1.Text = "Delete Account";
            // 
            // DeleteAcc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(327, 562);
            Controls.Add(label1);
            Controls.Add(btnDeleteAcc);
            Controls.Add(listBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DeleteAcc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Deletion of Accounts";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Guna.UI2.WinForms.Guna2Button btnDeleteAcc;
        private Label label1;
    }
}