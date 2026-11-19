using System;
using System.Windows.Forms;

namespace HRMSystem
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnQuanLyNV_Click(object sender, EventArgs e)
        {
            FormNhanVien frm = new FormNhanVien();
            frm.ShowDialog(); // Mở form nhân sự
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            FormChamCong frm = new FormChamCong();
            frm.ShowDialog(); // Mở form chấm công (Disconnected Model)
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            FormTinhLuong frm = new FormTinhLuong();
            frm.ShowDialog(); // Mở form tính lương (SqlTransaction)
        }
    }
}