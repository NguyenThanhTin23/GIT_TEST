using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.Reporting.WinForms;
using DA_WINFORM.Models;



namespace DA_WINFORM
{
    public partial class frmThongTinKhachHang : Form
    {
    
        KhachHang_BLL bllKhachHang;
        NhanVien_BLL bllNhanVien;
        Tour_BLL bllTour;
        HoaDon_BLL bllHoaDon;
        LLT_BLL bllLLT;
        TTTV_BLL bllTTTV;
        Report_BLL bllReport;

        public frmThongTinKhachHang()
        {
            InitializeComponent();
          
            bllKhachHang = new KhachHang_BLL();
            bllLLT = new LLT_BLL();
            bllTTTV = new TTTV_BLL();
            bllNhanVien = new NhanVien_BLL();
            bllHoaDon = new HoaDon_BLL();
            bllTour = new Tour_BLL();
            bllReport = new Report_BLL();
        }

        public bool CheckData()
        {
            string notice = "";

            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                notice += "Chưa nhập họ tên!\n";
                txtHoTen.Focus();
            }

            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                notice += "Chưa nhập SĐT!\n";
                txtSDT.Focus();
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                notice += "Chưa nhập Email!\n";
                txtEmail.Focus();
            }

            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                notice += "Chưa nhập địa chỉ\n";
                txtDiaChi.Focus();
            }

            if ((string.IsNullOrEmpty(txtHoTen.Text)) || (string.IsNullOrEmpty(txtSDT.Text)) || (string.IsNullOrEmpty(txtEmail.Text)) || (string.IsNullOrEmpty(txtDiaChi.Text)))
            {
                MessageBox.Show(notice, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnTaoKH_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                if (Regex.IsMatch(txtEmail.Text, pattern))
                {
                    txtTenTV.Focus();
                    txtHoTen.Enabled = false;
                    txtSDT.Enabled = false;
                    txtEmail.Enabled = false;
                    txtDiaChi.Enabled = false;

                    txtTenTV.Enabled = true;
                    cmbGT.Enabled = true;
                    dtpNgaySinh.Enabled = true;
                    //cmbLLT.Enabled = true;

                    tbl_KhachHang KhachHang = new tbl_KhachHang();
                    /* string MaKH;
                     if (bllKhachHang.GeTSoKHDangCo() < 10)
                         MaKH = "0" + bllKhachHang.GeTSoKHDangCo();
                     else
                         MaKH = bllKhachHang.GeTSoKHDangCo().ToString();
                     KhachHang.MaKH = "KH" + MaKH;*/
                    KhachHang.MaKH = bllKhachHang.GenerateNewMaKH();
                    KhachHang.TenKH = txtHoTen.Text;
                    KhachHang.SDT = txtSDT.Text;
                    KhachHang.Email = txtEmail.Text;
                    KhachHang.DiaChi = txtDiaChi.Text;
                    if (bllKhachHang.InsertKhachHang(KhachHang))
                    {
                        lblTenKH.Text = txtHoTen.Text;
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
               
            }
        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {/*
            int a = 0;
            string MaKH;
            if(a == CheckLLT1())
                MessageBox.Show("Phải có ít nhất 1 người lớn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                tbl_Tour Tour = new tbl_Tour();
                Tour.MaTour = lblMaTour.Text;

                tbl_HoaDon HoaDon = new tbl_HoaDon();
                HoaDon.SoHD = lblSoHD.Text;
                HoaDon.MaTour = lblMaTour.Text;
                HoaDon.MaNV = cmbTenNV.SelectedValue.ToString();
                if (Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1 < 10)
                    MaKH = "0" + (Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1);
                else
                    MaKH = (Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1).ToString();
                HoaDon.MaKH = "KH" + MaKH;
                HoaDon.NgayLapHoaDon = Convert.ToDateTime(lblNgayTaoHD.Text);
                HoaDon.ThanhTienHoaDon = Convert.ToDecimal((CheckLLT1() * Convert.ToInt32(bllLLT.GetAllLLT().Rows[0][2]) + CheckLLT2() * Convert.ToInt32(bllLLT.GetAllLLT().Rows[1][2])
                                            + CheckLLT3() * Convert.ToInt32(bllLLT.GetAllLLT().Rows[2][2]) + Convert.ToInt32(bllTour.GetTTTour(Tour).Rows[0]["GIATOUR"]) + CheckLLT4() * Convert.ToInt32(bllLLT.GetAllLLT().Rows[3][2])).ToString());
                if (bllHoaDon.InsertHoaDon(HoaDon))
                {
                    Tour.MaTour = lblMaTour.Text;
                    tbl_KhachHang kh = new tbl_KhachHang();
                    kh.MaKH = "KH" + MaKH; ;
                    bllTour.UpdatesltOUR(Tour, kh);
                    frmReportHD BillFrm = new frmReportHD();
                    BillFrm.Report = new tbl_Report();
                    BillFrm.Report.SoHD = lblSoHD.Text;
                    if (Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1 < 10)
                        MaKH = "0" + (Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1);
                    else
                        MaKH = (Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1).ToString();
                    BillFrm.Report.MaKH = "KH" + MaKH;
                    BillFrm.reportHD.LocalReport.DataSources.Clear();
                    ReportDataSource datasource = new ReportDataSource("DataSet1", bllReport.getReport(BillFrm.Report).Tables[0]);
                    //ReportDataSource datasource2 = new ReportDataSource("dtSetTTTV", bllReport.getReport2(BillFrm.Report).Tables[0]);
                    BillFrm.reportHD.LocalReport.DataSources.Clear();
                    BillFrm.reportHD.LocalReport.DataSources.Add(datasource);
                    //BillFrm.reportHD.LocalReport.DataSources.Add(datasource2);
                    BillFrm.reportHD.LocalReport.Refresh();
                    this.Close();

                    BillFrm.Show();
                    //MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }*/
            /*
             int a = 0;
             string MaKH;

             // Kiểm tra nếu không có ít nhất 1 người lớn
             if (a == CheckLLT1())
             {
                 MessageBox.Show("Phải có ít nhất 1 người lớn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                 return;
             }

             // Khởi tạo đối tượng Tour và Hóa Đơn
             tbl_Tour Tour = new tbl_Tour();
             Tour.MaTour = lblMaTour.Text;

             tbl_HoaDon HoaDon = new tbl_HoaDon();
             HoaDon.SoHD = lblSoHD.Text;
             HoaDon.MaTour = lblMaTour.Text;
             HoaDon.MaNV = cmbTenNV.SelectedValue.ToString();

             // Tạo mã khách hàng mới
             int soKH = Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1;
             MaKH = soKH < 10 ? "0" + soKH.ToString() : soKH.ToString();
             HoaDon.MaKH = "KH" + MaKH;

             // Thiết lập ngày lập hóa đơn và tổng tiền
             HoaDon.NgayLapHoaDon = Convert.ToDateTime(lblNgayTaoHD.Text);
             HoaDon.ThanhTienHoaDon = Convert.ToDecimal(
                 (CheckLLT1() * Convert.ToInt32(bllLLT.GetAllLLT().Rows[0][2]) +
                  CheckLLT2() * Convert.ToInt32(bllLLT.GetAllLLT().Rows[1][2]) +
                  CheckLLT3() * Convert.ToInt32(bllLLT.GetAllLLT().Rows[2][2]) +
                  Convert.ToInt32(bllTour.GetTTTour(Tour).Rows[0]["GIATOUR"]) +
                  CheckLLT4() * Convert.ToInt32(bllLLT.GetAllLLT().Rows[3][2])
                 ).ToString());

             // Chèn hóa đơn vào database
             if (bllHoaDon.InsertHoaDon(HoaDon))
             {
                 // Cập nhật số lượng tour
                 tbl_KhachHang kh = new tbl_KhachHang();
                 kh.MaKH = "KH" + MaKH;
                 bllTour.UpdatesltOUR(Tour, kh);

                 // Mở form hóa đơn
                 frmReportHD BillFrm = new frmReportHD();
                 BillFrm.Report = new tbl_Report();
                 BillFrm.Report.SoHD = lblSoHD.Text;

                 // Tạo lại mã khách hàng để đảm bảo đúng dữ liệu
                 soKH = Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1;
                 MaKH = soKH < 10 ? "0" + soKH.ToString() : soKH.ToString();
                 BillFrm.Report.MaKH = "KH" + MaKH;

                 // Cấu hình ReportViewer
                 BillFrm.reportHD.LocalReport.DataSources.Clear();

                 // Tạo dữ liệu nguồn cho báo cáo
                 DataTable dtReport = bllReport.getReport(BillFrm.Report).Tables[0];
                 if (dtReport.Rows.Count == 0)
                 {
                     MessageBox.Show("Không có dữ liệu cho báo cáo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }

                 ReportDataSource datasource = new ReportDataSource("DataSet1", dtReport);
                 BillFrm.reportHD.LocalReport.DataSources.Add(datasource);

                 // Gán đường dẫn file RDLC
                 BillFrm.reportHD.LocalReport.ReportPath =  @"D:\DA_WINFORM\DA_WINFORM\Report1.rdlc";

                 // Làm mới ReportViewer
                 BillFrm.reportHD.LocalReport.Refresh();
                 BillFrm.reportHD.RefreshReport();

                 // Đóng form hiện tại và mở form báo cáo
                 this.Close();
                 BillFrm.Show();
             }*//*
            tbl_Tour Tour = new tbl_Tour();
            var listCart = new BindingList<MyCart>();
            string nameTour = lblTenTour.Text;
            long Quantity = Convert.ToInt64(lblSLTong.Text);
            long GiaTour = Convert.ToInt64(lblGiaTour.Text);
            long TongCong = Convert.ToInt64(lblTongCong.Text);
            listCart.Add(new MyCart { name = nameTour, quantity = Quantity, unit_price = GiaTour, total_amount=TongCong });
            long soHoaDon = Convert.ToInt64(lblSoHD.Text.Substring(lblSoHD.Text.Length - 2));
            int soCuoi = (int)soHoaDon;
            var frm = new FrmPayment(listCart, soCuoi, "Thanh Toan Tour Du Lich Vietravel");
            frm.ShowDialog();*/
            // Lấy thông tin Tour từ CSDL
            tbl_Tour Tour = new tbl_Tour();
            Tour.MaTour = lblMaTour.Text;
            DataTable dtTour = bllTour.GetTTTour(Tour);
            decimal giaTour = dtTour.Rows.Count > 0 ? Convert.ToDecimal(dtTour.Rows[0]["GIATOUR"]) : 0;

            // Lấy thông tin Loại khách từ CSDL
            DataTable dtLLT = bllLLT.GetAllLLT();

            // Số lượng khách
            int slTong = dgvTTKH.Rows.Count - 1;

            // Tính phụ thu từng loại khách
            int slNL = CheckLLT1();
            int slTE = CheckLLT2();
            int slTN = CheckLLT3();
            int slEB = CheckLLT4();

            // Lấy giá từ CSDL
            decimal giaNL = dtLLT.Rows.Count > 0 ? Convert.ToDecimal(dtLLT.Rows[0][2]) : 0;
            decimal giaTE = dtLLT.Rows.Count > 1 ? Convert.ToDecimal(dtLLT.Rows[1][2]) : 0;
            decimal giaTN = dtLLT.Rows.Count > 2 ? Convert.ToDecimal(dtLLT.Rows[2][2]) : 0;
            decimal giaEB = dtLLT.Rows.Count > 3 ? Convert.ToDecimal(dtLLT.Rows[3][2]) : 0;

            // Tính tổng tiền
            decimal tongCong = (slNL * giaNL) + (slTE * giaTE) + (slTN * giaTN) + (slEB * giaEB) + (slTong * giaTour);

            // Thêm vào giỏ hàng
            var listCart = new BindingList<MyCart>();
            string nameTour = lblTenTour.Text;
            listCart.Add(new MyCart { name = nameTour, quantity = slTong, unit_price = (long)giaTour, total_amount = (long)tongCong });

            Random rnd = new Random();
            int soCuoi = rnd.Next(1000, 9999);

            // Mở form thanh toán
            var frm = new FrmPayment(listCart, soCuoi, "Thanh Toán Tour Vietravel");
            frm.ShowDialog();

        }


        private int CheckLLT1()
        {
            int a = 0;
            for (int i = 0; i < dgvTTKH.Rows.Count - 1; i ++ )
            {     
                if (dgvTTKH.Rows[i].Cells[4].Value.ToString() == "Người lớn")
                {
                    a++;
                }
            }
            return a;
        }

        private int CheckLLT2()
        {
            int b = 0;
            for (int i = 0; i < dgvTTKH.Rows.Count - 1; i++)
            {
                if (dgvTTKH.Rows[i].Cells[4].Value.ToString() == "Trẻ em")
                {
                    b++;
                }
            }
            return b;
        }

        private int CheckLLT3()
        {
            int c = 0;
            for (int i = 0; i < dgvTTKH.Rows.Count - 1; i++)
            {
                if (dgvTTKH.Rows[i].Cells[4].Value.ToString() == "Trẻ nhỏ")
                {
                    c++;
                }
            }
            return c;
        }

        private int CheckLLT4()
        {
            int d = 0;
            for (int i = 0; i < dgvTTKH.Rows.Count - 1; i++)
            {
                if (dgvTTKH.Rows[i].Cells[4].Value.ToString() == "Em bé")
                {
                    d++;
                }
            }
            return d;
        }

        private void LoadDaTa()
        {
            string SoHD;
            cmbTenNV.ValueMember = "MaNV";
            cmbTenNV.DisplayMember = "TenNV";
            cmbTenNV.DataSource = bllNhanVien.GetAllNhanVien();
            if (bllHoaDon.GetSoHD() < 10)
                SoHD = "0" + bllHoaDon.GetSoHD();
            else
                SoHD = bllHoaDon.GetSoHD().ToString();
            lblSoHD.Text = "HD" + SoHD;
            lblNgayTaoHD.Text = DateTime.Now.ToString();
            lblTenKH.Text = txtHoTen.Text;
            tbl_Tour Tour = new tbl_Tour();
            Tour.MaTour = lblMaTour.Text;
            lblGiaTour.Text = lblSLTong.Text + " x " + string.Format("{0:#,##0}", decimal.Parse(bllTour.GetTTTour(Tour).Rows[0]["GIATOUR"].ToString())) + " đ" ;
        }

        private void frmThongTinKhachHang_Load(object sender, EventArgs e)
        {
            LoadDaTa();
            cmbLLT.ValueMember = "MALLT";
            cmbLLT.DisplayMember = "TENLLT";
            cmbLLT.DataSource = bllLLT.GetAllLLT();
            cmbLLT.SelectedIndex = 3;
            cmbGT.SelectedIndex = 0;

            txtTenTV.Enabled = false;
            cmbGT.Enabled = false;
            dtpNgaySinh.Enabled = false;
            //cmbLLT.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTV.Text))
            {
                MessageBox.Show("Chưa nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if ((dgvTTKH.Rows.Count - 1) == Convert.ToInt32(lblSlot.Text))
                {
                    MessageBox.Show("Không đủ số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    int numRows = dgvTTKH.Rows.Count;

                    string MaKH;
                    tbl_TTTV TTTV = new tbl_TTTV();
                    //if (bllTTTV.GeTSoTVDangCo() < 10)
                    //    MaTV = "0" + bllTTTV.GeTSoTVDangCo();
                    //else
                    //    MaTV = bllTTTV.GeTSoTVDangCo().ToString();
                    //TTTV.MaTV = "TV" + MaTV;

                    if (Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1 < 10)
                        MaKH = "0" + (Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1);
                    else
                        MaKH = (Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1).ToString();
                    TTTV.MaKH = "KH" + MaKH;

                    TTTV.MaLLT = cmbLLT.SelectedValue.ToString();
                    TTTV.TenTV = txtTenTV.Text;
                    TTTV.GioiTinh = cmbGT.Text;
                    TTTV.NgaySinh = dtpNgaySinh.Value;
                    if (bllTTTV.InsertTTTV(TTTV))
                    {
                        //MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvTTKH.DataSource = bllTTTV.GetTTTV(TTTV);
                        txtTenTV.Clear();
                        cmbGT.SelectedIndex = 0;
                        dtpNgaySinh.Value = DateTime.Now;

                        SetGiaTien();                        
                    }
                    numRows++;
                }
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Now.Year - dtpNgaySinh.Value.Year <= 2)
            {
                cmbLLT.SelectedIndex = 3;
            }

            if (DateTime.Now.Year - dtpNgaySinh.Value.Year > 2 && DateTime.Now.Year - dtpNgaySinh.Value.Year <= 4)
            {
                cmbLLT.SelectedIndex = 2;
            }

            if (DateTime.Now.Year - dtpNgaySinh.Value.Year > 4 && DateTime.Now.Year - dtpNgaySinh.Value.Year <= 11)
            {
                cmbLLT.SelectedIndex = 1;
            }

            if (DateTime.Now.Year - dtpNgaySinh.Value.Year >= 12)
            {
                cmbLLT.SelectedIndex = 0;
            }

            if (DateTime.Now.Year - dtpNgaySinh.Value.Year < 0)
            {
                MessageBox.Show("Nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTV.Text))
            {
                MessageBox.Show("Chưa nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //if ((dgvTTKH.Rows.Count - 1) == Convert.ToInt32(lblSlot.Text))
                //{
                //    btnThem.Enabled = false;
                //    MessageBox.Show("Không đủ số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //}
                //else
                //{
                   int numRows = dgvTTKH.Rows.Count;

                    string MaKH;
                    tbl_TTTV TTTV = new tbl_TTTV();

                    TTTV.MaTV = dgvTTKH.SelectedRows[0].Cells[0].Value.ToString();

                    if (Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1 < 10)
                        MaKH = "0" + (Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1);
                    else
                        MaKH = (Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1).ToString();
                    TTTV.MaKH = "KH" + MaKH;

                    TTTV.MaLLT = cmbLLT.SelectedValue.ToString();
                    TTTV.TenTV = txtTenTV.Text;
                    TTTV.GioiTinh = cmbGT.Text;
                    TTTV.NgaySinh = dtpNgaySinh.Value;
                    if (bllTTTV.UpdateTTTV(TTTV))
                    {
                        //MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvTTKH.DataSource = bllTTTV.GetTTTV(TTTV);
                        txtTenTV.Clear();
                        cmbGT.SelectedIndex = 0;
                        dtpNgaySinh.Value = DateTime.Now;

                        SetGiaTien();
                    }
                    numRows++;
                //}
            }
        }

        private void dgvTTKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtTenTV.Text = dgvTTKH.Rows[index].Cells[1].Value.ToString();
                cmbGT.Text = dgvTTKH.Rows[index].Cells[2].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(dgvTTKH.Rows[index].Cells[3].Value.ToString());
                cmbLLT.Text = dgvTTKH.Rows[index].Cells[4].Value.ToString();
            }
        }

        private void SetGiaTien()
        {
            tbl_Tour Tour = new tbl_Tour();
            Tour.MaTour = lblMaTour.Text;
            lblSLTong.Text =  (dgvTTKH.Rows.Count - 1).ToString();
            if (CheckLLT1() == 0)
                lblGiaNL.Text = "0 đ";
            if (CheckLLT1() != 0)
                lblGiaNL.Text = CheckLLT1() + " x " + string.Format("{0:#,##0}", decimal.Parse(bllLLT.GetAllLLT().Rows[0][2].ToString())) + " đ (Phụ thu)";

            if (CheckLLT2() == 0)
                lblGiaTE.Text = "0 đ";
            if (CheckLLT2() != 0)
                lblGiaTE.Text = CheckLLT2() + " x " + string.Format("{0:#,##0}", decimal.Parse(bllLLT.GetAllLLT().Rows[1][2].ToString())) + " đ (Phụ thu)";

            if (CheckLLT3() == 0)
                lblGiaTN.Text = "0 đ";
            if (CheckLLT3() != 0)
                lblGiaTN.Text = CheckLLT3() + " x " + string.Format("{0:#,##0}", decimal.Parse(bllLLT.GetAllLLT().Rows[2][2].ToString())) + " đ (Phụ thu)";

            if (CheckLLT4() == 0)
                lblGiaEB.Text = "0 đ";
            if (CheckLLT4() != 0)
                lblGiaEB.Text = CheckLLT4() + " x " + string.Format("{0:#,##0}", decimal.Parse(bllLLT.GetAllLLT().Rows[3][2].ToString())) + " đ (Phụ thu)";
            lblGiaTour.Text = lblSLTong.Text + " x " + string.Format("{0:#,##0}", decimal.Parse(bllTour.GetTTTour(Tour).Rows[0]["GIATOUR"].ToString())) + " đ ";
            lblTongCong.Text = string.Format("{0:#,##0}", decimal.Parse((CheckLLT1() * Convert.ToInt32(bllLLT.GetAllLLT().Rows[0][2]) + CheckLLT2() * Convert.ToInt32(bllLLT.GetAllLLT().Rows[1][2])
                                            + CheckLLT3() * Convert.ToInt32(bllLLT.GetAllLLT().Rows[2][2]) + Convert.ToInt32(bllTour.GetTTTour(Tour).Rows[0]["GIATOUR"]) * Convert.ToInt32(lblSLTong.Text) + CheckLLT4() * Convert.ToInt32(bllLLT.GetAllLLT().Rows[3][2])).ToString())) + " đ";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaKH;
            if (txtTenTV.Text == "")
            {
                MessageBox.Show("Chưa chọn thành viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    tbl_TTTV TTTV = new tbl_TTTV();
                    TTTV.MaTV = dgvTTKH.SelectedRows[0].Cells[0].Value.ToString();

                    if (Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1 < 10)
                        MaKH = "0" + (Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1);
                    else
                        MaKH = (Convert.ToInt32(bllKhachHang.GeTSoKHDangCo()) - 1).ToString();
                    TTTV.MaKH = "KH" + MaKH;

                    if (bllTTTV.DeleteTTTV(TTTV))
                    {
                        //MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvTTKH.DataSource = bllTTTV.GetTTTV(TTTV);
                        txtTenTV.Clear();
                        cmbGT.SelectedIndex = 0;
                        dtpNgaySinh.Value = DateTime.Now;
                        SetGiaTien();
                    }

                    else
                        MessageBox.Show("Đã có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblNgayTaoHD_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblSoHD_Click(object sender, EventArgs e)
        {

        }

        private void lblGiaTour_Click(object sender, EventArgs e)
        {

        }
    }
}
