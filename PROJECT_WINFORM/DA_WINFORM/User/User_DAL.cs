using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_WINFORM
{
     class User_DAL
    {/*
        DataConnection dataCon;
        SqlCommand cmd;

        public User_DAL()
        {
            dataCon = new DataConnection();
        }

        public string PhQuyen(tbl_User user)
        {
            string sql = "SELECT QUYEN FROM dbo.[USER] WHERE UserName = @UserName AND [Password] = @Password";
            using (SqlConnection con = dataCon.getConnect())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@Password", user.Password);

                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString().Trim() : "Fail"; // Trả về trực tiếp quyền
                }
            }
        }
        public bool RegisterUser(tbl_User user)
        {
            // Chuyển đổi vai trò sang giá trị tương ứng
            string role;
            switch (user.Quyen.Trim())  // Trim để loại bỏ khoảng trắng thừa
            {
                case "Quản Trị Viên":
                    role = "Admin";
                    break;
                case "Nhân Viên":
                    role = "Employee";
                    break;
                case "Khách Hàng":
                    role = "Guest";
                    break;
                default:
                    role = "Fail";
                    break;
            }

            string checkUserSql = "SELECT COUNT(*) FROM dbo.[USER] WHERE UserName = @UserName";
            string insertUserSql = "INSERT INTO dbo.[USER] (UserName, Password, QUYEN) VALUES (@UserName, @Password, @Role)";

            using (SqlConnection con = dataCon.getConnect())
            {
                con.Open();
                using (SqlCommand checkCmd = new SqlCommand(checkUserSql, con))
                {
                    checkCmd.Parameters.AddWithValue("@UserName", user.UserName);
                    int userCount = (int)checkCmd.ExecuteScalar();
                    if (userCount > 0)
                    {
                        return false; // Tên đăng nhập đã tồn tại
                    }
                }

                using (SqlCommand insertCmd = new SqlCommand(insertUserSql, con))
                {
                    insertCmd.Parameters.AddWithValue("@UserName", user.UserName);
                    insertCmd.Parameters.AddWithValue("@Password", user.Password);
                    insertCmd.Parameters.AddWithValue("@Role", role);  // Sử dụng giá trị đã chuyển đổi

                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu đăng ký thành công
                }
            }
        }*/
        DataConnection dataCon;
        SqlCommand cmd;

        public User_DAL()
        {
            dataCon = new DataConnection();
        }

        public string PhQuyen(tbl_User user)
        {
            string sql = "SELECT QUYEN FROM dbo.[USER] WHERE UserName = @UserName AND [Password] = @Password";
            using (SqlConnection con = dataCon.getConnect())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@Password", user.Password);

                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString().Trim() : "Fail"; // Trả về trực tiếp quyền
                }
            }
        }
        public bool RegisterUser(tbl_User user)
        {
            // Chuyển đổi vai trò sang giá trị tương ứng
            string role;
            switch (user.Quyen.Trim())  // Trim để loại bỏ khoảng trắng thừa
            {
                case "Quản Trị Viên":
                    role = "Admin";
                    break;
                case "Nhân Viên":
                    role = "Employee";
                    break;
                case "Khách Hàng":
                    role = "Guest";
                    break;
                default:
                    role = "Fail";
                    break;
            }

            string checkUserSql = "SELECT COUNT(*) FROM dbo.[USER] WHERE UserName = @UserName";
            string insertUserSql = "INSERT INTO dbo.[USER] (UserName, Password, QUYEN) VALUES (@UserName, @Password, @Role)";

            using (SqlConnection con = dataCon.getConnect())
            {
                con.Open();
                using (SqlCommand checkCmd = new SqlCommand(checkUserSql, con))
                {
                    checkCmd.Parameters.AddWithValue("@UserName", user.UserName);
                    int userCount = (int)checkCmd.ExecuteScalar();
                    if (userCount > 0)
                    {
                        return false; // Tên đăng nhập đã tồn tại
                    }
                }

                using (SqlCommand insertCmd = new SqlCommand(insertUserSql, con))
                {
                    insertCmd.Parameters.AddWithValue("@UserName", user.UserName);
                    insertCmd.Parameters.AddWithValue("@Password", user.Password);
                    insertCmd.Parameters.AddWithValue("@Role", role);  // Sử dụng giá trị đã chuyển đổi

                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu đăng ký thành công
                }
            }
        }
    }
}
