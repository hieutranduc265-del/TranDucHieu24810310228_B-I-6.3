namespace HRMSystem
{
    partial class FormTinhLuong
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
            this.txtThangNamLuong = new System.Windows.Forms.TextBox();
            this.btnChotLuong = new System.Windows.Forms.Button();
            this.dataGridViewLuong = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // txtThangNamLuong
            // 
            this.txtThangNamLuong.Location = new System.Drawing.Point(30, 25);
            this.txtThangNamLuong.Name = "txtThangNamLuong";
            this.txtThangNamLuong.Size = new System.Drawing.Size(150, 22);
            this.txtThangNamLuong.TabIndex = 0;
            this.txtThangNamLuong.Text = "11/2026";
            // 
            // btnChotLuong
            // 
            this.btnChotLuong.Location = new System.Drawing.Point(200, 22);
            this.btnChotLuong.Name = "btnChotLuong";
            this.btnChotLuong.Size = new System.Drawing.Size(150, 28);
            this.btnChotLuong.TabIndex = 1;
            this.btnChotLuong.Text = "Chốt Lương Tháng";
            this.btnChotLuong.UseVisualStyleBackColor = true;
            this.btnChotLuong.Click += new System.EventHandler(this.btnChotLuong_Click);
            // 
            // dataGridViewLuong
            // 
            this.dataGridViewLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLuong.Location = new System.Drawing.Point(30, 70);
            this.dataGridViewLuong.Name = "dataGridViewLuong";
            this.dataGridViewLuong.RowHeadersWidth = 51;
            this.dataGridViewLuong.RowTemplate.Height = 24;
            this.dataGridViewLuong.Size = new System.Drawing.Size(730, 370);
            this.dataGridViewLuong.TabIndex = 2;
            // 
            // FormTinhLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 470);
            this.Controls.Add(this.dataGridViewLuong);
            this.Controls.Add(this.btnChotLuong);
            this.Controls.Add(this.txtThangNamLuong);
            this.Name = "FormTinhLuong";
            this.Text = "Tính Lương & Chốt Lương (SqlTransaction)";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtThangNamLuong;
        private System.Windows.Forms.Button btnChotLuong;
        private System.Windows.Forms.DataGridView dataGridViewLuong;
    }
}