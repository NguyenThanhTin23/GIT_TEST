using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_WINFORM
{
    public partial class frmSignIn : Form
    {
        User_BLL bllUser;
        public frmSignIn()
        {
            InitializeComponent();
            cbRole.Items.AddRange(new string[] { "Quản Trị Viên ", "Nhân Viên ", "Khách Hàng " });
            cbRole.SelectedIndex = 0;
            cbRole.Text = "Chọn quyền"; // Đặt text mặc định cho ComboBox
            bllUser = new User_BLL();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSingIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDN.Text) ||
               string.IsNullOrWhiteSpace(txtMK.Text) ||
               string.IsNullOrWhiteSpace(txtConfirmMK.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtMK.Text != txtConfirmMK.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tbl_User newUser = new tbl_User
            {
                UserName = txtTenDN.Text,
                Password = txtMK.Text,
                Quyen = cbRole.SelectedItem.ToString()
            };

            if (bllUser.RegisterUser(newUser))
            {
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                frmLogin LoginFrm = new frmLogin();
                LoginFrm.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbShowMK_CheckedChanged(object sender, EventArgs e)
        {

            if (cbShowMK.Checked)
            {
                txtMK.PasswordChar = '\0';
                txtConfirmMK.PasswordChar = '\0';
            }
            else
            {
                txtMK.PasswordChar = '\u25CF';
                txtConfirmMK.PasswordChar = '\u25CF';
            }
        }

        private void frmSignIn_Load(object sender, EventArgs e)
        {
            txtMK.PasswordChar = '\u25CF';
            txtConfirmMK.PasswordChar = '\u25CF';
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin LoginFrm = new frmLogin();
            LoginFrm.Show();
        }
    }
}
