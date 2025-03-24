using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DA_WINFORM
{
    public partial class frmKhachHang : Form
    {
        KhachHang_BLL bllKH;
        public frmKhachHang()
        {
            InitializeComponent();
            bllKH = new KhachHang_BLL();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        public void ShowAllKH()
        {
            DataTable dataTable = bllKH.GetAllKH();
            dgvKH.DataSource = dataTable;
        }

        string notice = "";
        private bool checkData()
        {
            string notice = "";

            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                notice += "Chưa nhập số điện thoại\n";
                txtSDT.Focus();
            }

            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                notice += "Chưa nhập địa chỉ\n";
                txtDiaChi.Focus();
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                notice += "Chưa nhập Email\n";
                txtEmail.Focus();
            }

            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txtEmail.Text, pattern) == false)
            {
                notice += "Nhập sai định dạng Email\n";
                txtEmail.Focus();
            }

            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                notice += "Chưa nhập tên\n";
                txtTenKH.Focus();
            }

            if ((string.IsNullOrEmpty(txtSDT.Text)) || (string.IsNullOrEmpty(txtDiaChi.Text)) || (string.IsNullOrEmpty(txtEmail.Text)) || (Regex.IsMatch(txtEmail.Text, pattern) == false) || (string.IsNullOrEmpty(txtTenKH.Text)))
            {
                MessageBox.Show(notice, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                tbl_KhachHang KhachHang = new tbl_KhachHang();
                KhachHang.MaKH = txtMaKH.Text;
                KhachHang.TenKH = txtTenKH.Text;
                KhachHang.SDT = txtSDT.Text;
                KhachHang.DiaChi = txtDiaChi.Text;
                KhachHang.Email = txtEmail.Text;

                if (bllKH.UpdateKhachHang(KhachHang))
                {
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAllKH();
                }

                else
                {
                    MessageBox.Show("Lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMaKH.Focus();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            if (dgvKH.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận xóa
            if (MessageBox.Show("Bạn có muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Lấy mã khách hàng từ dòng được chọn
                    string maKH = dgvKH.SelectedRows[0].Cells[0].Value?.ToString();

                    if (string.IsNullOrEmpty(maKH))
                    {
                        MessageBox.Show("Không thể lấy mã khách hàng để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Tạo đối tượng khách hàng để xóa
                    tbl_KhachHang khachHang = new tbl_KhachHang { MaKH = maKH };

                    // Thực hiện xóa
                    bool result = bllKH.DeleteKhachHang(khachHang);
                    if (result)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowAllKH(); // Cập nhật lại danh sách
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa! Có thể khách hàng này có dữ liệu liên quan trong hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            ShowAllKH();
            btnXoa.Visible = false;
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Enabled = true;
            btnXoa.Visible = true;
            int index = e.RowIndex;
            if (index >= 0)
            {
             
                txtMaKH.Text = dgvKH.Rows[index].Cells[0].Value.ToString();
                txtTenKH.Text = dgvKH.Rows[index].Cells[1].Value.ToString();
                txtSDT.Text = dgvKH.Rows[index].Cells[2].Value.ToString();
                txtEmail.Text = dgvKH.Rows[index].Cells[3].Value.ToString();
                txtDiaChi.Text = dgvKH.Rows[index].Cells[4].Value.ToString();
            }
            txtMaKH.Enabled = false;
        }
    }
}
