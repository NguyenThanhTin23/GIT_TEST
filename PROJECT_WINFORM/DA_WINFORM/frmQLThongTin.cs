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
    public partial class frmQLThongTin : Form
    {
        public frmQLThongTin()
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

        private void frmQLThongTin_Load(object sender, EventArgs e)
        {

        }

        private void ControlClose_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMainn Main = new frmMainn();
            Main.Show();
            
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1218, 933);
            panelChildForm.Size = new Size(1440, 700);


            btnNhanVien.FillColor = Color.White;

            btnNhanVien.FillColor2 = Color.White;

            btnNhanVien.ForeColor = Color.Black;

            btnQLDV.FillColor = Color.FromArgb(11, 7, 66);
            btnQLDV.FillColor2 = Color.FromArgb(18, 12, 110);
            btnQLDV.ForeColor = Color.White;

            btnKH.FillColor = Color.FromArgb(11, 7, 66);
            btnKH.FillColor2 = Color.FromArgb(18, 12, 110);
            btnKH.ForeColor = Color.White;

            frmTour.FillColor = Color.FromArgb(11, 7, 66);
            frmTour.FillColor2 = Color.FromArgb(18, 12, 110);
            frmTour.ForeColor = Color.White;
            openChildForm(new frmNhanVien());
        }

        private void btnQLDV_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1218, 933);
            panelChildForm.Size = new Size(1440, 700);

            btnQLDV.FillColor = Color.White;
            btnQLDV.FillColor2 = Color.White;
            btnQLDV.ForeColor = Color.Black;

            btnNhanVien.FillColor = Color.FromArgb(11, 7, 66);
            btnNhanVien.FillColor2 = Color.FromArgb(18, 12, 110);
            btnNhanVien.ForeColor = Color.White;

            btnKH.FillColor = Color.FromArgb(11, 7, 66);
            btnKH.FillColor2 = Color.FromArgb(18, 12, 110);
            btnKH.ForeColor = Color.White;

            frmTour.FillColor = Color.FromArgb(11, 7, 66);
            frmTour.FillColor2 = Color.FromArgb(18, 12, 110);
            frmTour.ForeColor = Color.White;
            openChildForm(new frmThongTin());
        }

        private void btnKH_Click(object sender, EventArgs e)

        {
            this.Size = new Size(1218, 933);
            panelChildForm.Size = new Size(1440, 700);

            btnKH.FillColor = Color.White;
            btnKH.FillColor2 = Color.White;
            btnKH.ForeColor = Color.Black;

            btnNhanVien.FillColor = Color.FromArgb(11, 7, 66);
            btnNhanVien.FillColor2 = Color.FromArgb(18, 12, 110);
            btnNhanVien.ForeColor = Color.White;

            btnQLDV.FillColor = Color.FromArgb(11, 7, 66);
            btnQLDV.FillColor2 = Color.FromArgb(18, 12, 110);
            btnQLDV.ForeColor = Color.White;

            frmTour.FillColor = Color.FromArgb(11, 7, 66);
            frmTour.FillColor2 = Color.FromArgb(18, 12, 110);
            frmTour.ForeColor = Color.White;
            openChildForm(new frmKhachHang());
        }

        private void frmTour_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1218, 933);
            panelChildForm.Size = new Size(1440, 700);

            frmTour.FillColor = Color.White;
            frmTour.FillColor2 = Color.White;
            frmTour.ForeColor = Color.Black;

            btnNhanVien.FillColor = Color.FromArgb(11, 7, 66);
            btnNhanVien.FillColor2 = Color.FromArgb(18, 12, 110);
            btnNhanVien.ForeColor = Color.White;

            btnQLDV.FillColor = Color.FromArgb(11, 7, 66);
            btnQLDV.FillColor2 = Color.FromArgb(18, 12, 110);
            btnQLDV.ForeColor = Color.White;

            btnKH.FillColor = Color.FromArgb(11, 7, 66);
            btnKH.FillColor2 = Color.FromArgb(18, 12, 110);
            btnKH.ForeColor = Color.White;
            openChildForm(new frmTour());
        }

        private void ControlMin_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
