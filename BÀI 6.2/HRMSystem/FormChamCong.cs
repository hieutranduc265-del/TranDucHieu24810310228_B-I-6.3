using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HRMSystem
{
    public partial class FormChamCong : Form
    {
        string connStr = "Data Source=.;Initial Catalog=HRMDB;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;

        public FormChamCong()
        {
            InitializeComponent();
        }

        private void btnTaiDuLieu_Click(object sender, EventArgs e)
        {
            string thangNam = txtThangNam.Text.Trim(); // Ví dụ: 11/2026
            if (string.IsNullOrEmpty(thangNam))
            {
                MessageBox.Show("Vui lòng nhập tháng năm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // 1. Kiểm tra xem tháng này đã có dữ liệu trong BangChamCong chưa
                string checkQuery = "SELECT COUNT(*) FROM BangChamCong WHERE ThangNam = @ThangNam";
                using (SqlCommand cmdCheck = new SqlCommand(checkQuery, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@ThangNam", thangNam);
                    int count = (int)cmdCheck.ExecuteScalar();

                    // Nếu chưa có, tự động sinh sẵn dữ liệu chấm công mặc định (0 ngày công, 0 giờ OT) cho tất cả nhân viên
                    if (count == 0)
                    {
                        string insertDefaultQuery = @"
                            INSERT INTO BangChamCong (MaNV, ThangNam, SoNgayCong, SoGioOT)
                            SELECT MaNV, @ThangNam, 0, 0 FROM NhanVien";
                        using (SqlCommand cmdInsert = new SqlCommand(insertDefaultQuery, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@ThangNam", thangNam);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }

                // 2. Load dữ liệu lên DataSet thông qua DataAdapter
                string query = "SELECT MaCong, MaNV, ThangNam, SoNgayCong, SoGioOT FROM BangChamCong WHERE ThangNam = @ThangNam";
                adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@ThangNam", thangNam);

                ds = new DataSet();
                adapter.Fill(ds, "BangChamCong");

                dataGridViewCC.DataSource = ds.Tables["BangChamCong"];
                if (dataGridViewCC.Columns["MaCong"] != null) dataGridViewCC.Columns["MaCong"].Visible = false;
                if (dataGridViewCC.Columns["MaNV"] != null) dataGridViewCC.Columns["MaNV"].ReadOnly = true;
                if (dataGridViewCC.Columns["ThangNam"] != null) dataGridViewCC.Columns["ThangNam"].ReadOnly = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (ds == null || ds.Tables["BangChamCong"] == null)
                {
                    MessageBox.Show("Chưa có dữ liệu để lưu! Vui lòng tải dữ liệu trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.Validate();
                dataGridViewCC.EndEdit();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    adapter.SelectCommand.Connection = conn;

                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                    adapter.UpdateCommand = cmdBuilder.GetUpdateCommand();
                    adapter.InsertCommand = cmdBuilder.GetInsertCommand();
                    adapter.DeleteCommand = cmdBuilder.GetDeleteCommand();

                    adapter.Update(ds, "BangChamCong");
                }

                MessageBox.Show("Lưu bảng chấm công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}