using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DA_WINFORM;
using System.Windows.Forms;

namespace DA_WINFORM
{
    internal class LH_BLL
    {
        private LH_DAL dal = new LH_DAL();

        public bool AddContact(tbl_LienHe contact)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(contact.Name) ||
                string.IsNullOrWhiteSpace(contact.Email) ||
                string.IsNullOrWhiteSpace(contact.Phone) ||
                string.IsNullOrWhiteSpace(contact.Subject) ||
                string.IsNullOrWhiteSpace(contact.Content))
            {
                MessageBox.Show("Lỗi: Một số trường bắt buộc bị bỏ trống.\n" +
                                $"Name: {contact.Name}\nEmail: {contact.Email}\nPhone: {contact.Phone}\n" +
                                $"Subject: {contact.Subject}\nContent: {contact.Content}",
                                "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                // Chèn dữ liệu vào database
                bool isInserted = dal.Insert(contact);

                if (isInserted)
                {
                   
                    return true;
                }
                else
                {
                    MessageBox.Show("Lỗi: Không thể chèn dữ liệu vào database.", "Lỗi hệ thống",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong AddContact:\n{ex.Message}", "Lỗi hệ thống",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        public List<tbl_LienHe> GetAllContacts()
        {
            return dal.GetAll();
        }

       
        }
    }

