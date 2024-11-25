namespace WinFormsApp12
{
    partial class addToppingsForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addToppingsForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnDone = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            txtInputGrams = new Guna.UI2.WinForms.Guna2TextBox();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.FromArgb(205, 232, 229);
            guna2Panel1.Controls.Add(btnDone);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.Controls.Add(txtInputGrams);
            guna2Panel1.Controls.Add(guna2PictureBox1);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.Location = new Point(15, 15);
            guna2Panel1.Margin = new Padding(4);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(885, 411);
            guna2Panel1.TabIndex = 0;
            // 
            // btnDone
            // 
            btnDone.CustomizableEdges = customizableEdges1;
            btnDone.DisabledState.BorderColor = Color.DarkGray;
            btnDone.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDone.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDone.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDone.FillColor = Color.FromArgb(122, 178, 178);
            btnDone.Font = new Font("Segoe UI", 9F);
            btnDone.ForeColor = Color.White;
            btnDone.Location = new Point(298, 271);
            btnDone.Margin = new Padding(4);
            btnDone.Name = "btnDone";
            btnDone.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnDone.Size = new Size(316, 70);
            btnDone.TabIndex = 2;
            btnDone.Text = "Done";
            btnDone.Click += btnDone_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label1.Location = new Point(258, 102);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(388, 45);
            label1.TabIndex = 1;
            label1.Text = "Input Amount of Grams";
            label1.Click += label1_Click;
            // 
            // txtInputGrams
            // 
            txtInputGrams.CustomizableEdges = customizableEdges3;
            txtInputGrams.DefaultText = "";
            txtInputGrams.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtInputGrams.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtInputGrams.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtInputGrams.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtInputGrams.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtInputGrams.Font = new Font("Segoe UI", 9F);
            txtInputGrams.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtInputGrams.Location = new Point(272, 154);
            txtInputGrams.Margin = new Padding(5, 6, 5, 6);
            txtInputGrams.Name = "txtInputGrams";
            txtInputGrams.PasswordChar = '\0';
            txtInputGrams.PlaceholderText = "";
            txtInputGrams.SelectedText = "";
            txtInputGrams.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtInputGrams.Size = new Size(375, 62);
            txtInputGrams.TabIndex = 0;
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackColor = Color.Transparent;
            guna2PictureBox1.BackgroundImage = (Image)resources.GetObject("guna2PictureBox1.BackgroundImage");
            guna2PictureBox1.CustomizableEdges = customizableEdges5;
            guna2PictureBox1.FillColor = Color.Transparent;
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(-330, 25);
            guna2PictureBox1.Margin = new Padding(4);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2PictureBox1.Size = new Size(1314, 609);
            guna2PictureBox1.TabIndex = 3;
            guna2PictureBox1.TabStop = false;
            guna2PictureBox1.UseTransparentBackground = true;
            guna2PictureBox1.Click += guna2PictureBox1_Click;
            // 
            // addToppingsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(77, 134, 156);
            ClientSize = new Size(915, 441);
            Controls.Add(guna2Panel1);
            Margin = new Padding(4);
            Name = "addToppingsForm";
            Text = "addToppingsForm";
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnDone;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtInputGrams;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}