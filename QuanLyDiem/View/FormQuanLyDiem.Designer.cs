namespace QuanLyDiem.View
{
    partial class FormQuanLyDiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cboGiaoVien = new ComboBox();
            cboLopHoc = new ComboBox();
            lblMonHoc = new Label();
            dgvDanhSachHocSinh = new DataGridView();
            btnLuu = new Button();
            btnXuatFile = new Button();
            btnXoaDiem = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachHocSinh).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(399, 13);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(190, 24);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ ĐIỂM SỐ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 22);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(108, 19);
            label2.TabIndex = 1;
            label2.Text = "Chọn Giáo Viên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(521, 22);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 19);
            label3.TabIndex = 2;
            label3.Text = "Chọn Lớp Học:";
            // 
            // cboGiaoVien
            // 
            cboGiaoVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGiaoVien.FormattingEnabled = true;
            cboGiaoVien.Location = new Point(153, 18);
            cboGiaoVien.Margin = new Padding(4, 4, 4, 4);
            cboGiaoVien.Name = "cboGiaoVien";
            cboGiaoVien.Size = new Size(332, 27);
            cboGiaoVien.TabIndex = 3;
            // 
            // cboLopHoc
            // 
            cboLopHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLopHoc.FormattingEnabled = true;
            cboLopHoc.Location = new Point(644, 18);
            cboLopHoc.Margin = new Padding(4, 4, 4, 4);
            cboLopHoc.Name = "cboLopHoc";
            cboLopHoc.Size = new Size(224, 27);
            cboLopHoc.TabIndex = 4;
            // 
            // lblMonHoc
            // 
            lblMonHoc.AutoSize = true;
            lblMonHoc.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMonHoc.Location = new Point(19, 69);
            lblMonHoc.Margin = new Padding(4, 0, 4, 0);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Size = new Size(70, 15);
            lblMonHoc.TabIndex = 5;
            lblMonHoc.Text = "Môn học: ";
            // 
            // dgvDanhSachHocSinh
            // 
            dgvDanhSachHocSinh.AllowUserToAddRows = false;
            dgvDanhSachHocSinh.AllowUserToDeleteRows = false;
            dgvDanhSachHocSinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachHocSinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachHocSinh.Dock = DockStyle.Bottom;
            dgvDanhSachHocSinh.Location = new Point(0, 202);
            dgvDanhSachHocSinh.Margin = new Padding(4, 4, 4, 4);
            dgvDanhSachHocSinh.Name = "dgvDanhSachHocSinh";
            dgvDanhSachHocSinh.Size = new Size(1067, 456);
            dgvDanhSachHocSinh.TabIndex = 6;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(644, 69);
            btnLuu.Margin = new Padding(4, 4, 4, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(100, 34);
            btnLuu.TabIndex = 7;
            btnLuu.Text = "Lưu Điểm";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnXuatFile
            // 
            btnXuatFile.Location = new Point(889, 69);
            btnXuatFile.Margin = new Padding(4, 4, 4, 4);
            btnXuatFile.Name = "btnXuatFile";
            btnXuatFile.Size = new Size(161, 34);
            btnXuatFile.TabIndex = 8;
            btnXuatFile.Text = "Xuất File Điểm";
            btnXuatFile.UseVisualStyleBackColor = true;
            // 
            // btnXoaDiem
            // 
            btnXoaDiem.BackColor = Color.MistyRose;
            btnXoaDiem.ForeColor = Color.Crimson;
            btnXoaDiem.Location = new Point(769, 69);
            btnXoaDiem.Margin = new Padding(4, 4, 4, 4);
            btnXoaDiem.Name = "btnXoaDiem";
            btnXoaDiem.Size = new Size(100, 34);
            btnXoaDiem.TabIndex = 9;
            btnXoaDiem.Text = "Xóa Điểm";
            btnXoaDiem.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnXuatFile);
            panel1.Controls.Add(btnXoaDiem);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnLuu);
            panel1.Controls.Add(cboGiaoVien);
            panel1.Controls.Add(cboLopHoc);
            panel1.Controls.Add(lblMonHoc);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1067, 121);
            panel1.TabIndex = 9;
            // 
            // FormQuanLyDiem
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 658);
            Controls.Add(panel1);
            Controls.Add(dgvDanhSachHocSinh);
            Controls.Add(label1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FormQuanLyDiem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Điểm Số";
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachHocSinh).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboGiaoVien;
        private System.Windows.Forms.ComboBox cboLopHoc;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.DataGridView dgvDanhSachHocSinh;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.Button btnXoaDiem;
        private System.Windows.Forms.Panel panel1;
    }
}