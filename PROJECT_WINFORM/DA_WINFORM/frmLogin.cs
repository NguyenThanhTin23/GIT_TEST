using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DA_WINFORM
{
    public partial class frmLogin : Form
    {
        User_BLL bllUser;
        public frmLogin()
        {
            InitializeComponent();
            bllUser = new User_BLL();
        }

        void CheckBox()
        {
            tbl_User User = new tbl_User();
            User.UserName = txtTenDN.Text;
            User.Password = txtMK.Text;
            //string quyen = "";
            if (bllUser.PhQuyen(User) == "Admin")
            {
                frmMainn MainFrm = new frmMainn();
                MainFrm.lblXinChao.Text = "Xin chào: " + txtTenDN.Text;
                MainFrm.Show();
                this.Hide();
            }

            if (bllUser.PhQuyen(User) == "Employee")
            {
                frmMainn Main = new frmMainn();
                Main.lblXinChao.Text = "Xin chào: " + txtTenDN.Text;
                Main.btnQLTT.Enabled = false;
                Main.Show();
                this.Hide();
            }
            if (bllUser.PhQuyen(User) == "Guest")
            {
                frmMainUser Main = new frmMainUser();
                Main.lblXinChao.Text = "Xin chào: " + txtTenDN.Text;
                Main.Show();
                this.Hide();
            }
            if (bllUser.PhQuyen(User) == "Fail")
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

     
       

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtMK.PasswordChar = '\u25CF';
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbShowMK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowMK.Checked)
            {
                txtMK.PasswordChar = '\0';
            }

            else
                txtMK.PasswordChar = '\u25CF';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckBox();
        }

        private void btnSingIn_Click(object sender, EventArgs e)
        {
            frmSignIn signInForm = new frmSignIn();
            signInForm.ShowDialog();
        }

        private void ControlMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
