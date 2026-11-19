using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HRMSystem
{
    public partial class FormTinhLuong : Form
    {
        string connStr = "Data Source=.;Initial Catalog=HRMDB;Integrated Security=True";

        public FormTinhLuong()
        {
            InitializeComponent();
        }

        private void btnChotLuong_Click(object sender, EventArgs e)
        {
            string thangNam = txtThangNamLuong.Text.Trim();
            if (string.IsNullOrEmpty(thangNam))
            {
                MessageBox.Show("Vui lòng nhập tháng năm cần chốt lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); // Bật SqlTransaction đảm bảo tính ACID

                try
                {
                    string queryGet = "SELECT MaNV, SoNgayCong, SoGioOT FROM BangChamCong WHERE ThangNam = @ThangNam";
                    SqlCommand cmdGet = new SqlCommand(queryGet, conn, transaction);
                    cmdGet.Parameters.AddWithValue("@ThangNam", thangNam);

                    SqlDataAdapter da = new SqlDataAdapter(cmdGet);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu chấm công cho tháng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        transaction.Rollback();
                        return;
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        int maNV = Convert.ToInt32(row["MaNV"]);
                        float ngayCong = Convert.ToSingle(row["SoNgayCong"]);
                        float gioOT = Convert.ToSingle(row["SoGioOT"]);

                        SqlCommand cmdInfo = new SqlCommand("SELECT LuongCoBan, HeSoLuong FROM NhanVien WHERE MaNV = @MaNV", conn, transaction);
                        cmdInfo.Parameters.AddWithValue("@MaNV", maNV);

                        using (SqlDataReader reader = cmdInfo.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal luongCB = reader.GetDecimal(0);
                                double heSo = reader.GetDouble(1);
                                reader.Close();

                                // Áp dụng đúng công thức trong đề bài:
                                // ThucLinh = (LuongCoBan * HeSoLuong / 22) * SoNgayCong + (SoGioOT * 50,000)
                                decimal thucLinh = (decimal)(((double)(luongCB * (decimal)heSo) / 22.0) * (double)ngayCong) + (decimal)(gioOT * 50000f);

                                string querySave = @"
                                    IF EXISTS (SELECT 1 FROM BangLuong WHERE MaNV = @MaNV AND ThangNam = @ThangNam)
                                        UPDATE BangLuong SET ThucLinh = @ThucLinh WHERE MaNV = @MaNV AND ThangNam = @ThangNam;
                                    ELSE
                                        INSERT INTO BangLuong (MaNV, ThangNam, ThucLinh) VALUES (@MaNV, @ThangNam, @ThucLinh);";

                                using (SqlCommand cmdSave = new SqlCommand(querySave, conn, transaction))
                                {
                                    cmdSave.Parameters.AddWithValue("@MaNV", maNV);
                                    cmdSave.Parameters.AddWithValue("@ThangNam", thangNam);
                                    cmdSave.Parameters.AddWithValue("@ThucLinh", thucLinh);
                                    cmdSave.ExecuteNonQuery();
                                }
                                break;
                            }
                        }
                    }

                    transaction.Commit(); // Hoàn tất giao dịch thành công
                    MessageBox.Show("Chốt lương tháng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBangLuong(thangNam);
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Hoàn tác nếu có lỗi
                    MessageBox.Show("Lỗi khi chốt lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadBangLuong(string thangNam)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT bl.MaLuong, nv.HoTen, bl.ThangNam, bl.ThucLinh FROM BangLuong bl JOIN NhanVien nv ON bl.MaNV = nv.MaNV WHERE bl.ThangNam = @ThangNam";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ThangNam", thangNam);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewLuong.DataSource = dt;
            }
        }
    }
}