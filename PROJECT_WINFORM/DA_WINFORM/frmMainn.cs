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
    public partial class frmMainn : Form
    {
        public frmMainn()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1218, 933);
            panelChildForm.Size = new Size(1440, 680);

            btnTrangChu.FillColor = Color.White;
            btnTrangChu.FillColor2 = Color.White;
            btnTrangChu.ForeColor = Color.Black;

            btnTour.FillColor = Color.FromArgb(11, 7, 66);
            btnTour.FillColor2 = Color.FromArgb(18, 12, 110);
            btnTour.ForeColor = Color.White;

            btnQLTT.FillColor = Color.FromArgb(11, 7, 66);
            btnQLTT.FillColor2 = Color.FromArgb(18, 12, 110);
            btnQLTT.ForeColor = Color.White;

            btnHoaDon.FillColor = Color.FromArgb(11, 7, 66);
            btnHoaDon.FillColor2 = Color.FromArgb(18, 12, 110);
            btnHoaDon.ForeColor = Color.White;
            openChildForm(new frmHome());
        }

        private void btnTour_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1218, 933);
            panelChildForm.Size = new Size(1440, 680);
            openChildForm(new frmDatTour());

            btnTour.FillColor = Color.White;
            btnTour.FillColor2 = Color.White;
            btnTour.ForeColor = Color.Black;

            btnTrangChu.FillColor = Color.FromArgb(11, 7, 66);
            btnTrangChu.FillColor2 = Color.FromArgb(18, 12, 110);
            btnTrangChu.ForeColor = Color.White;

            btnQLTT.FillColor = Color.FromArgb(11, 7, 66);
            btnQLTT.FillColor2 = Color.FromArgb(18, 12, 110);
            btnQLTT.ForeColor = Color.White;

            btnHoaDon.FillColor = Color.FromArgb(11, 7, 66);
            btnHoaDon.FillColor2 = Color.FromArgb(18, 12, 110);
            btnHoaDon.ForeColor = Color.White;
        }

        private void btnQLTT_Click(object sender, EventArgs e)
        {
            panelChildForm.Size = new Size(1192, 785);
            this.Size = new Size(1218, 933);

            this.Hide();
            frmQLThongTin QLTT = new frmQLThongTin();

            QLTT.ShowDialog();
        }

        private void frmMainn_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1218, 933);
            panelChildForm.Size = new Size(1440, 680);

            btnTrangChu.FillColor = Color.White;
            btnTrangChu.FillColor2 = Color.White;
            btnTrangChu.ForeColor = Color.Black;

            btnTour.FillColor = Color.FromArgb(11, 7, 66);
            btnTour.FillColor2 = Color.FromArgb(18, 12, 110);
            btnTour.ForeColor = Color.White;

            btnQLTT.FillColor = Color.FromArgb(11, 7, 66);
            btnQLTT.FillColor2 = Color.FromArgb(18, 12, 110);
            btnQLTT.ForeColor = Color.White;

            btnHoaDon.FillColor = Color.FromArgb(11, 7, 66);
            btnHoaDon.FillColor2 = Color.FromArgb(18, 12, 110);
            btnHoaDon.ForeColor = Color.White;
            openChildForm(new frmHome());
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin LoginFrm = new frmLogin();
            LoginFrm.Show();
        }

        private void btnTrangChu_Click_1(object sender, EventArgs e)
        {
            this.Size = new Size(1218, 933);
            panelChildForm.Size = new Size(1440, 680);

            btnTrangChu.FillColor = Color.White;
            btnTrangChu.FillColor2 = Color.White;
            btnTrangChu.ForeColor = Color.Black;

            btnTour.FillColor = Color.FromArgb(11, 7, 66);
            btnTour.FillColor2 = Color.FromArgb(18, 12, 110);
            btnTour.ForeColor = Color.White;

            btnQLTT.FillColor = Color.FromArgb(11, 7, 66);
            btnQLTT.FillColor2 = Color.FromArgb(18, 12, 110);
            btnQLTT.ForeColor = Color.White;

            btnHoaDon.FillColor = Color.FromArgb(11, 7, 66);
            btnHoaDon.FillColor2 = Color.FromArgb(18, 12, 110);
            btnHoaDon.ForeColor = Color.White;
            openChildForm(new frmHome());
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1218, 933);
            panelChildForm.Size = new Size(1440, 680);
            this.StartPosition = FormStartPosition.CenterScreen;
            btnHoaDon.FillColor = Color.White;
            btnHoaDon.FillColor2 = Color.White;
            btnHoaDon.ForeColor = Color.Black;

            btnTour.FillColor = Color.FromArgb(11, 7, 66);
            btnTour.FillColor2 = Color.FromArgb(18, 12, 110);
            btnTour.ForeColor = Color.White;

            btnQLTT.FillColor = Color.FromArgb(11, 7, 66);
            btnQLTT.FillColor2 = Color.FromArgb(18, 12, 110);
            btnQLTT.ForeColor = Color.White;

            btnTrangChu.FillColor = Color.FromArgb(11, 7, 66);
            btnTrangChu.FillColor2 = Color.FromArgb(18, 12, 110);
            btnTrangChu.ForeColor = Color.White;
            openChildForm(new frmHoaDon());
        }

        private void ControlMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        //private void btnKhachHang_Click(object sender, EventArgs e)
        //{
        //    openChildForm(new frmKhachHang());
        //    //frmKhachHang KhachHang = new frmKhachHang();
        //    //KhachHang.ShowDialog();
        //}

        //private void btnThongTin_Click(object sender, EventArgs e)
        //{
        //    //if(pnlSubMenuThongTin.Visible == true)
        //    //    pnlSubMenuThongTin.Visible = false;
        //    //else
        //    //    pnlSubMenuThongTin.Visible = true;
        //}

        //private void btnQLTT_Click(object sender, EventArgs e)
        //{


        //}
    }
}
