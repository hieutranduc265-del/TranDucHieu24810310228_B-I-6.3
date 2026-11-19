namespace HRMSystem
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnQuanLyNV = new System.Windows.Forms.Button();
            this.btnChamCong = new System.Windows.Forms.Button();
            this.btnTinhLuong = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnQuanLyNV
            // 
            this.btnQuanLyNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyNV.Location = new System.Drawing.Point(50, 100);
            this.btnQuanLyNV.Name = "btnQuanLyNV";
            this.btnQuanLyNV.Size = new System.Drawing.Size(300, 45);
            this.btnQuanLyNV.TabIndex = 0;
            this.btnQuanLyNV.Text = "Quản Lý Nhân Sự";
            this.btnQuanLyNV.UseVisualStyleBackColor = true;
            this.btnQuanLyNV.Click += new System.EventHandler(this.btnQuanLyNV_Click);
            // 
            // btnChamCong
            // 
            this.btnChamCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChamCong.Location = new System.Drawing.Point(50, 165);
            this.btnChamCong.Name = "btnChamCong";
            this.btnChamCong.Size = new System.Drawing.Size(300, 45);
            this.btnChamCong.TabIndex = 1;
            this.btnChamCong.Text = "Chấm Công Hàng Tháng";
            this.btnChamCong.UseVisualStyleBackColor = true;
            this.btnChamCong.Click += new System.EventHandler(this.btnChamCong_Click);
            // 
            // btnTinhLuong
            // 
            this.btnTinhLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhLuong.Location = new System.Drawing.Point(50, 230);
            this.btnTinhLuong.Name = "btnTinhLuong";
            this.btnTinhLuong.Size = new System.Drawing.Size(300, 45);
            this.btnTinhLuong.TabIndex = 2;
            this.btnTinhLuong.Text = "Tính & Chốt Lương";
            this.btnTinhLuong.UseVisualStyleBackColor = true;
            this.btnTinhLuong.Click += new System.EventHandler(this.btnTinhLuong_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(50, 35);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(305, 29);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "HỆ THỐNG QUẢN LÝ HRM";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 320);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnTinhLuong);
            this.Controls.Add(this.btnChamCong);
            this.Controls.Add(this.btnQuanLyNV);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Chính - HRM System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnQuanLyNV;
        private System.Windows.Forms.Button btnChamCong;
        private System.Windows.Forms.Button btnTinhLuong;
        private System.Windows.Forms.Label labelTitle;
    }
}