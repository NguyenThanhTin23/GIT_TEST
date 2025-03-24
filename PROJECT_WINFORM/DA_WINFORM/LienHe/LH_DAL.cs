using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DA_WINFORM;

namespace DA_WINFORM
{
    class LH_DAL
    {
        DataConnection dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public LH_DAL()
        {
            dataCon = new DataConnection();
        }

        public bool Insert(tbl_LienHe contact)
        {
            string sql = "INSERT INTO Contacts (Name, Email, Phone, Address, Company, GuestCount, Subject, Content) " +
             "VALUES (@Name, @Email, @Phone, @Address, @Company, @GuestCount, @Subject, @Content)";

            SqlConnection con = dataCon.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();

                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = contact.Name;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = contact.Email;
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = contact.Phone;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = contact.Address;
                cmd.Parameters.Add("@Company", SqlDbType.NVarChar).Value = contact.Company;
                cmd.Parameters.Add("@GuestCount", SqlDbType.Int).Value = contact.GuestCount;
                cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = contact.Subject;
                cmd.Parameters.Add("@Content", SqlDbType.NVarChar).Value = contact.Content;

                cmd.ExecuteNonQuery();
                con.Close();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm liên hệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        public List<tbl_LienHe> GetAll()
        {
            List<tbl_LienHe> list = new List<tbl_LienHe>();
            string sql = "SELECT * FROM Contacts";

            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            con.Open();
            sqlDA.Fill(dt);
            con.Close();

            foreach (DataRow row in dt.Rows)
            {
                tbl_LienHe contact = new tbl_LienHe()
                {
                    Name = row["Name"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Address = row["Address"].ToString(),
                    Company = row["Company"].ToString(),
                    GuestCount = Convert.ToInt32(row["GuestCount"]),
                    Subject = row["Subject"].ToString(),
                    Content = row["Content"].ToString()
                };
                list.Add(contact);
            }
            return list;
        }
    }
}
