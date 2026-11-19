using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HRMSystem
{
    public partial class FormNhanVien : Form
    {
        string connStr = "Data Source=.;Initial Catalog=HRMDB;Integrated Security=True";
        int selectedMaNV = -1; // Biến lưu mã nhân viên khi click chọn trên lưới

        public FormNhanVien()
        {
            InitializeComponent();
            LoadNhanVien();
        }

        private void LoadNhanVien()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM NhanVien";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewNV.DataSource = dt;
            }
        }

        // Nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = "INSERT INTO NhanVien (HoTen, NgaySinh, CCCD, MaPB, LuongCoBan, HeSoLuong) VALUES (@HoTen, GETDATE(), @CCCD, @MaPB, @LuongCB, @HeSo)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                        cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text.Trim());
                        cmd.Parameters.AddWithValue("@MaPB", Convert.ToInt32(txtMaPB.Text.Trim()));
                        cmd.Parameters.AddWithValue("@LuongCB", Convert.ToDecimal(txtLuongCB.Text.Trim()));
                        cmd.Parameters.AddWithValue("@HeSo", Convert.ToSingle(txtHeSo.Text.Trim()));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNhanVien();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khi click vào một dòng trên bảng -> đổ dữ liệu lên các ô textbox để sửa/xóa
        private void dataGridViewNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewNV.Rows[e.RowIndex];
                if (row.Cells["MaNV"].Value != DBNull.Value)
                {
                    selectedMaNV = Convert.ToInt32(row.Cells["MaNV"].Value);
                    txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                    txtCCCD.Text = row.Cells["CCCD"].Value.ToString();
                    txtMaPB.Text = row.Cells["MaPB"].Value.ToString();
                    txtLuongCB.Text = row.Cells["LuongCoBan"].Value.ToString();
                    txtHeSo.Text = row.Cells["HeSoLuong"].Value.ToString();
                }
            }
        }

        // Nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedMaNV == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = "UPDATE NhanVien SET HoTen = @HoTen, CCCD = @CCCD, MaPB = @MaPB, LuongCoBan = @LuongCB, HeSoLuong = @HeSo WHERE MaNV = @MaNV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", selectedMaNV);
                        cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                        cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text.Trim());
                        cmd.Parameters.AddWithValue("@MaPB", Convert.ToInt32(txtMaPB.Text.Trim()));
                        cmd.Parameters.AddWithValue("@LuongCB", Convert.ToDecimal(txtLuongCB.Text.Trim()));
                        cmd.Parameters.AddWithValue("@HeSo", Convert.ToSingle(txtHeSo.Text.Trim()));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNhanVien();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedMaNV == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaNV", selectedMaNV);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadNhanVien();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa (có thể nhân viên này đang có dữ liệu chấm công/lương): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}