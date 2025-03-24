using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DA_WINFORM
{
    public partial class frmLienHe : Form
    {
        private LH_BLL bll = new LH_BLL();
        public frmLienHe()
        {
            InitializeComponent();
        }

        private void lbl_Click(object sender, EventArgs e)
        {

        }

        private void frmLienHe_Load(object sender, EventArgs e)
        {
            lbl.AutoSize = false;
            lbl.Size = new Size(1000, 50);
            lbl.Text = "Để có thể đáp ứng được các yêu cầu và đóng góp ý kiến của quý khách, xin vui lòng gửi thông tin hoặc gọi đến hotline các chi nhánh bên dưới để liên hệ một cách nhanh chóng";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void mapTruSoChinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string address = "190 Pasteur, P. Võ Thị Sáu, Q.3, Tp. Hồ Chí Minh";
            string url = "https://www.google.com/maps/search/?api=1&query=" + Uri.EscapeDataString(address);
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });


        }

        private void SoDTTruSoChinh_MouseClick(object sender, MouseEventArgs e)
        {
            string hotline = "0238668999";
            try
            {
                Process.Start("tel:" + hotline);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện cuộc gọi.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void emailTruSoChinh_MouseClick(object sender, MouseEventArgs e)
        {
            string email = "info@vietravel.com"; // Email đích
            string gmailUrl = $"https://mail.google.com/mail/?view=cm&to={email}";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = gmailUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở Gmail.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string address = "492 Cộng Hòa, P.13, Q.Tân Bình, TP.HCM";
            string url = "https://www.google.com/maps/search/?api=1&query=" + Uri.EscapeDataString(address);
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void map3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string address = " 04 Trần Hưng Đạo, P.Hoàng Văn Thụ, Q.Hồng Bàng, TP. Hải Phòng";
            string url = "https://www.google.com/maps/search/?api=1&query=" + Uri.EscapeDataString(address);
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void SoDT2_Click(object sender, EventArgs e)
        {
            string hotline = "0903593674";
            try
            {
                Process.Start("tel:" + hotline);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện cuộc gọi.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SoDT3_Click(object sender, EventArgs e)
        {
            string hotline = "0936900085";
            try
            {
                Process.Start("tel:" + hotline);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện cuộc gọi.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SoDTTruSoChinh_Click(object sender, EventArgs e)
        {

        }

        private void mail2_Click(object sender, EventArgs e)
        {
            string email = "info@vietravel.edu.vn"; // Email đích
            string gmailUrl = $"https://mail.google.com/mail/?view=cm&to={email}";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = gmailUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở Gmail.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mail3_Click(object sender, EventArgs e)
        {
            string email = "info.hph@vietravel.com"; // Email đích
            string gmailUrl = $"https://mail.google.com/mail/?view=cm&to={email}";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = gmailUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở Gmail.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            tbl_LienHe contact = new tbl_LienHe
            {
                Name = txtName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Company = txtCompany.Text.Trim(),
                GuestCount = int.TryParse(txtGuestCount.Text, out int guestCount) && guestCount > 0 ? guestCount : -1,
                Subject = txtSubject.Text.Trim(),
                Content = txtContent.Text.Trim()
            };

            if (contact.GuestCount == -1)
            {
                MessageBox.Show("Số khách phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bll.AddContact(contact))
            {
                MessageBox.Show("Thông tin đã được lưu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gửi email xác nhận
           
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            tbl_LienHe contact = new tbl_LienHe
            {
                Name = txtName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Company = txtCompany.Text.Trim(),
                GuestCount = int.TryParse(txtGuestCount.Text, out int guestCount) && guestCount > 0 ? guestCount : -1,
                Subject = txtSubject.Text.Trim(),
                Content = txtContent.Text.Trim()
            };

            if (contact.GuestCount == -1)
            {
                MessageBox.Show("Số khách phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bll.AddContact(contact))
            {
                MessageBox.Show("Thông tin đã được lưu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SendConfirmationEmail(contact.Email, contact.Name);

            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void SendConfirmationEmail(string recipientEmail, string recipientName)
        {
            
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;
                string smtpUsername = "tinthanhn81@gmail.com";  
                string smtpPassword = "onrc rcge vjcl evax";   

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(smtpUsername, "Vietravel Support");
                mail.To.Add(recipientEmail);
                mail.Subject = "Xác nhận tiếp nhận thông tin từ Quý khách";
                mail.Body = $"Kính gửi {recipientName},\n\nCảm ơn Quý khách đã liên hệ với Vietravel. Chúng tôi đã nhận được thông tin của Quý khách và sẽ phản hồi trong thời gian sớm nhất.\nNếu trong lúc chờ đợi, Quý khách có thêm bất kỳ yêu cầu hay thắc mắc nào, vui lòng liên hệ với chúng tôi qua email này hoặc qua hotline 0903593673 để được hỗ trợ nhanh chóng.\n\nTrân trọng,\nBộ phận Chăm sóc Khách hàng\nVietravel";
                mail.IsBodyHtml = false;

                SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort)
                {
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                    EnableSsl = true
                };

                smtpClient.Send(mail);
              


        }

    }
}
