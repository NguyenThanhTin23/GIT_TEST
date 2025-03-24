using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DA_WINFORM
{
    class HoaDon_DAL
    {
        DataConnection dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public HoaDon_DAL()
        {
            dataCon = new DataConnection();
        }

        public int GetSoHD()
        {
            string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(SoHD, 3, LEN(SoHD) - 2) AS INT)), 0) + 1 FROM HOADON";
            SqlConnection con = dataCon.getConnect();

            cmd = new SqlCommand(sql, con);
            con.Open();
            int SOHD = (int)cmd.ExecuteScalar();
            con.Close();

            return SOHD;

        }

        public DataTable getAllHoaDon()
        {
            string sql = "SELECT SOHD, TENNV, TENKH, NGAYLAPHOADON, THANHTIENHOADON, TOUR.TENTOUR, GIATOUR FROM HOADON, NHANVIEN, KHACHHANG, TOUR WHERE HOADON.MAKH = KHACHHANG.MAKH AND HOADON.MANV = NHANVIEN.MANV AND TOUR.MATOUR = HOADON.MATOUR";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }
        private string GenerateNewSoHD()
        {
            string sql = "SELECT MAX(SOHD) FROM HOADON";
            using (SqlConnection con = dataCon.getConnect())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    string lastSoHD = result.ToString(); // Lấy mã hóa đơn lớn nhất
                    int number = int.Parse(lastSoHD.Substring(2)) + 1; // Cắt "HD" và tăng số lên 1
                    return "HD" + number.ToString("D2"); // Định dạng lại thành HDxx
                }
                return "HD01"; // Nếu chưa có hóa đơn nào, bắt đầu từ HD01
            }
        }

        private bool CheckExistSoHD(string soHD)
        {
            string sql = "SELECT COUNT(*) FROM HOADON WHERE SOHD = @SOHD";
            using (SqlConnection con = dataCon.getConnect())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@SOHD", soHD);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0; // Trả về true nếu mã đã tồn tại
            }
        }

        public bool InsertHoaDon(tbl_HoaDon hoadon)
        {
            // Nếu SOHD đã tồn tại, tự động tạo số mới
            if (CheckExistSoHD(hoadon.SoHD))
            {
                hoadon.SoHD = GenerateNewSoHD();
            }

            string sql = "INSERT INTO HOADON(SOHD, MATOUR, MANV, MAKH, NGAYLAPHOADON, THANHTIENHOADON) VALUES(@SOHD, @MATOUR, @MANV, @MAKH, @NGAYLAPHOADON, @THANHTIENHOADON)";

            using (SqlConnection con = dataCon.getConnect())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                try
                {
                    con.Open();
                    cmd.Parameters.Add("@SOHD", SqlDbType.VarChar).Value = hoadon.SoHD;
                    cmd.Parameters.Add("@MATOUR", SqlDbType.VarChar).Value = hoadon.MaTour;
                    cmd.Parameters.Add("@MANV", SqlDbType.VarChar).Value = hoadon.MaNV;
                    cmd.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = hoadon.MaKH;
                    cmd.Parameters.Add("@NGAYLAPHOADON", SqlDbType.DateTime).Value = hoadon.NgayLapHoaDon.ToString("yyyy-MM-dd HH:mm:ss");
                    cmd.Parameters.Add("@THANHTIENHOADON", SqlDbType.Decimal).Value = hoadon.ThanhTienHoaDon;

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message);
                    return false;
                }
            }
        }

        public DataTable ThongKe_DoanhThu_Nam(tbl_HoaDon hoadon)
        {
            string sql = "select month(ngaylaphoadon) as N'Tháng', sum(thanhtienhoadon) as N'Thành tiền' from hoadon where year(ngaylaphoadon) =  "+ hoadon.Nam +" group by ngaylaphoadon ";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public bool DeleteHoaDon(tbl_HoaDon hoadon)
        {
            string sql = "UPDATE TOUR SET SOLUONGCONLAI = TOUR.SOLUONGCONLAI + (SELECT COUNT(THONGTINTV.MATV) FROM THONGTINTV, LOAILUATUOI, HOADON, KHACHHANG WHERE LOAILUATUOI.MALLT = THONGTINTV.MALLT AND SOHD = @SOHD  AND HOADON.MAKH = KHACHHANG.MAKH AND THONGTINTV.MAKH = KHACHHANG.MAKH) WHERE TOUR.MATOUR = (SELECT MATOUR FROM HOADON WHERE SOHD = @SOHD )" +
                "DELETE FROM THONGTINTV WHERE MAKH = (SELECT MAKH FROM HOADON WHERE SOHD = @SOHD )" +
                "DELETE FROM HOADON WHERE SOHD = @SOHD";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@SOHD", SqlDbType.VarChar).Value = hoadon.SoHD;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
