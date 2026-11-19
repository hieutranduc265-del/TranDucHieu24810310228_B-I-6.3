namespace HRMSystem
{
    partial class FormChamCong
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
            this.txtThangNam = new System.Windows.Forms.TextBox();
            this.btnTaiDuLieu = new System.Windows.Forms.Button();
            this.dataGridViewCC = new System.Windows.Forms.DataGridView();
            this.btnLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCC)).BeginInit();
            this.SuspendLayout();
            // 
            // txtThangNam
            // 
            this.txtThangNam.Location = new System.Drawing.Point(30, 25);
            this.txtThangNam.Name = "txtThangNam";
            this.txtThangNam.Size = new System.Drawing.Size(150, 22);
            this.txtThangNam.TabIndex = 0;
            this.txtThangNam.Text = "11/2026";
            // 
            // btnTaiDuLieu
            // 
            this.btnTaiDuLieu.Location = new System.Drawing.Point(200, 22);
            this.btnTaiDuLieu.Name = "btnTaiDuLieu";
            this.btnTaiDuLieu.Size = new System.Drawing.Size(120, 28);
            this.btnTaiDuLieu.TabIndex = 1;
            this.btnTaiDuLieu.Text = "Tải Dữ Liệu";
            this.btnTaiDuLieu.UseVisualStyleBackColor = true;
            this.btnTaiDuLieu.Click += new System.EventHandler(this.btnTaiDuLieu_Click);
            // 
            // dataGridViewCC
            // 
            this.dataGridViewCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCC.Location = new System.Drawing.Point(30, 70);
            this.dataGridViewCC.Name = "dataGridViewCC";
            this.dataGridViewCC.RowHeadersWidth = 51;
            this.dataGridViewCC.RowTemplate.Height = 24;
            this.dataGridViewCC.Size = new System.Drawing.Size(730, 320);
            this.dataGridViewCC.TabIndex = 2;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(30, 410);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 35);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu Chấm Công";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // FormChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 470);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dataGridViewCC);
            this.Controls.Add(this.btnTaiDuLieu);
            this.Controls.Add(this.txtThangNam);
            this.Name = "FormChamCong";
            this.Text = "Chấm Công Ngắt Kết Nối (Disconnected Model)";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtThangNam;
        private System.Windows.Forms.Button btnTaiDuLieu;
        private System.Windows.Forms.DataGridView dataGridViewCC;
        private System.Windows.Forms.Button btnLuu;
    }
}