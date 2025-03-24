namespace DA_WINFORM
{
    partial class frmSignIn
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
            this.cbRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtConfirmMK = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSingIn = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbShowMK = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtMK = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTenDN = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbRole
            // 
            this.cbRole.BackColor = System.Drawing.Color.Transparent;
            this.cbRole.BorderRadius = 25;
            this.cbRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbRole.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbRole.FocusedState.Parent = this.cbRole;
            this.cbRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbRole.HoverState.Parent = this.cbRole;
            this.cbRole.ItemHeight = 30;
            this.cbRole.ItemsAppearance.Parent = this.cbRole;
            this.cbRole.Location = new System.Drawing.Point(203, 392);
            this.cbRole.Name = "cbRole";
            this.cbRole.ShadowDecoration.Parent = this.cbRole;
            this.cbRole.Size = new System.Drawing.Size(358, 36);
            this.cbRole.TabIndex = 8;
            // 
            // txtConfirmMK
            // 
            this.txtConfirmMK.BorderRadius = 25;
            this.txtConfirmMK.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmMK.DefaultText = "";
            this.txtConfirmMK.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConfirmMK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConfirmMK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmMK.DisabledState.Parent = this.txtConfirmMK;
            this.txtConfirmMK.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmMK.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmMK.FocusedState.Parent = this.txtConfirmMK;
            this.txtConfirmMK.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtConfirmMK.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmMK.HoverState.Parent = this.txtConfirmMK;
            this.txtConfirmMK.Location = new System.Drawing.Point(73, 298);
            this.txtConfirmMK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConfirmMK.Name = "txtConfirmMK";
            this.txtConfirmMK.PasswordChar = '\0';
            this.txtConfirmMK.PlaceholderText = "Xác nhận mật khẩu";
            this.txtConfirmMK.SelectedText = "";
            this.txtConfirmMK.ShadowDecoration.Parent = this.txtConfirmMK;
            this.txtConfirmMK.Size = new System.Drawing.Size(503, 57);
            this.txtConfirmMK.TabIndex = 7;
            this.txtConfirmMK.TextOffset = new System.Drawing.Point(15, 0);
            // 
            // btnSingIn
            // 
            this.btnSingIn.BorderRadius = 23;
            this.btnSingIn.CheckedState.Parent = this.btnSingIn;
            this.btnSingIn.CustomImages.Parent = this.btnSingIn;
            this.btnSingIn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSingIn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSingIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSingIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSingIn.DisabledState.Parent = this.btnSingIn;
            this.btnSingIn.FillColor = System.Drawing.Color.Teal;
            this.btnSingIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSingIn.ForeColor = System.Drawing.Color.White;
            this.btnSingIn.HoverState.Parent = this.btnSingIn;
            this.btnSingIn.Location = new System.Drawing.Point(381, 527);
            this.btnSingIn.Name = "btnSingIn";
            this.btnSingIn.ShadowDecoration.Parent = this.btnSingIn;
            this.btnSingIn.Size = new System.Drawing.Size(180, 45);
            this.btnSingIn.TabIndex = 6;
            this.btnSingIn.Text = "Đăng kí";
            this.btnSingIn.Click += new System.EventHandler(this.btnSingIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(241, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 54);
            this.label1.TabIndex = 5;
            this.label1.Text = "Đăng kí";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbShowMK
            // 
            this.cbShowMK.AutoSize = true;
            this.cbShowMK.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbShowMK.CheckedState.BorderRadius = 0;
            this.cbShowMK.CheckedState.BorderThickness = 0;
            this.cbShowMK.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbShowMK.CheckMarkColor = System.Drawing.Color.Teal;
            this.cbShowMK.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowMK.ForeColor = System.Drawing.Color.White;
            this.cbShowMK.Location = new System.Drawing.Point(82, 483);
            this.cbShowMK.Name = "cbShowMK";
            this.cbShowMK.Size = new System.Drawing.Size(142, 21);
            this.cbShowMK.TabIndex = 4;
            this.cbShowMK.Text = "Hiển thị mật khẩu";
            this.cbShowMK.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbShowMK.UncheckedState.BorderRadius = 0;
            this.cbShowMK.UncheckedState.BorderThickness = 0;
            this.cbShowMK.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbShowMK.CheckedChanged += new System.EventHandler(this.cbShowMK_CheckedChanged);
            // 
            // txtMK
            // 
            this.txtMK.BorderRadius = 25;
            this.txtMK.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMK.DefaultText = "";
            this.txtMK.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMK.DisabledState.Parent = this.txtMK;
            this.txtMK.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMK.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMK.FocusedState.Parent = this.txtMK;
            this.txtMK.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMK.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMK.HoverState.Parent = this.txtMK;
            this.txtMK.Location = new System.Drawing.Point(73, 206);
            this.txtMK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMK.Name = "txtMK";
            this.txtMK.PasswordChar = '\0';
            this.txtMK.PlaceholderText = "Mật khẩu";
            this.txtMK.SelectedText = "";
            this.txtMK.ShadowDecoration.Parent = this.txtMK;
            this.txtMK.Size = new System.Drawing.Size(503, 57);
            this.txtMK.TabIndex = 2;
            this.txtMK.TextOffset = new System.Drawing.Point(15, 0);
            // 
            // txtTenDN
            // 
            this.txtTenDN.BorderRadius = 25;
            this.txtTenDN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenDN.DefaultText = "";
            this.txtTenDN.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenDN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenDN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenDN.DisabledState.Parent = this.txtTenDN;
            this.txtTenDN.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenDN.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenDN.FocusedState.Parent = this.txtTenDN;
            this.txtTenDN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenDN.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenDN.HoverState.Parent = this.txtTenDN;
            this.txtTenDN.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenDN.Location = new System.Drawing.Point(73, 114);
            this.txtTenDN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.PasswordChar = '\0';
            this.txtTenDN.PlaceholderText = "Tên đăng nhập";
            this.txtTenDN.SelectedText = "";
            this.txtTenDN.ShadowDecoration.Parent = this.txtTenDN;
            this.txtTenDN.Size = new System.Drawing.Size(503, 57);
            this.txtTenDN.TabIndex = 1;
            this.txtTenDN.TextOffset = new System.Drawing.Point(15, 0);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.BorderColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.BorderRadius = 10;
            this.guna2GradientPanel1.BorderThickness = 5;
            this.guna2GradientPanel1.Controls.Add(this.label2);
            this.guna2GradientPanel1.Controls.Add(this.cbRole);
            this.guna2GradientPanel1.Controls.Add(this.txtConfirmMK);
            this.guna2GradientPanel1.Controls.Add(this.btnSingIn);
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Controls.Add(this.cbShowMK);
            this.guna2GradientPanel1.Controls.Add(this.txtMK);
            this.guna2GradientPanel1.Controls.Add(this.txtTenDN);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.Teal;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.Turquoise;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(287, 199);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(630, 613);
            this.guna2GradientPanel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(108, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Vai trò";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.CadetBlue;
            this.btnExit.FillColor = System.Drawing.Color.CadetBlue;
            this.btnExit.HoverState.Parent = this.btnExit;
            this.btnExit.IconColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(1747, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.ShadowDecoration.Parent = this.btnExit;
            this.btnExit.Size = new System.Drawing.Size(64, 63);
            this.btnExit.TabIndex = 15;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.BackColor = System.Drawing.Color.CadetBlue;
            this.guna2GradientButton1.BorderColor = System.Drawing.Color.White;
            this.guna2GradientButton1.BorderRadius = 5;
            this.guna2GradientButton1.CheckedState.Parent = this.guna2GradientButton1;
            this.guna2GradientButton1.CustomImages.Parent = this.guna2GradientButton1;
            this.guna2GradientButton1.DisabledState.Parent = this.guna2GradientButton1;
            this.guna2GradientButton1.FillColor = System.Drawing.Color.CadetBlue;
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.CadetBlue;
            this.guna2GradientButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.HoverState.Parent = this.guna2GradientButton1;
            this.guna2GradientButton1.Image = global::DA_WINFORM.Properties.Resources.icons8_exit_60;
            this.guna2GradientButton1.Location = new System.Drawing.Point(1839, 12);
            this.guna2GradientButton1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.PressedColor = System.Drawing.Color.White;
            this.guna2GradientButton1.ShadowDecoration.Parent = this.guna2GradientButton1;
            this.guna2GradientButton1.Size = new System.Drawing.Size(64, 63);
            this.guna2GradientButton1.TabIndex = 16;
            this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // frmSignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DA_WINFORM.Properties.Resources.welcome;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1844, 833);
            this.Controls.Add(this.guna2GradientButton1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.guna2GradientPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSignIn";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSignIn_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cbRole;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmMK;
        private Guna.UI2.WinForms.Guna2Button btnSingIn;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CheckBox cbShowMK;
        private Guna.UI2.WinForms.Guna2TextBox txtMK;
        private Guna.UI2.WinForms.Guna2TextBox txtTenDN;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2ControlBox btnExit;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private System.Windows.Forms.Label label2;
    }
}