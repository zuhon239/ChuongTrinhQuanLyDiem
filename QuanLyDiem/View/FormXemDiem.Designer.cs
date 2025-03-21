namespace QuanLyDiem.View
{
    partial class FormXemDiem
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
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblLopHoc = new Label();
            cboLopHoc = new ComboBox();
            lblMonHoc = new Label();
            cboMonHoc = new ComboBox();
            dgvDanhSachHocSinh = new DataGridView();
            btnXuatFile = new Button();
            lblThongKe = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachHocSinh).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(16, 13);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(338, 24);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BẢNG ĐIỂM HỌC SINH THEO LỚP";
            lblTitle.Click += lblTitle_Click;
            // 
            // lblLopHoc
            // 
            lblLopHoc.AutoSize = true;
            lblLopHoc.Location = new Point(17, 77);
            lblLopHoc.Margin = new Padding(4, 0, 4, 0);
            lblLopHoc.Name = "lblLopHoc";
            lblLopHoc.Size = new Size(61, 19);
            lblLopHoc.TabIndex = 1;
            lblLopHoc.Text = "Lớp học:";
            // 
            // cboLopHoc
            // 
            cboLopHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLopHoc.FormattingEnabled = true;
            cboLopHoc.Location = new Point(96, 73);
            cboLopHoc.Margin = new Padding(4, 4, 4, 4);
            cboLopHoc.Name = "cboLopHoc";
            cboLopHoc.Size = new Size(265, 27);
            cboLopHoc.TabIndex = 2;
            // 
            // lblMonHoc
            // 
            lblMonHoc.AutoSize = true;
            lblMonHoc.Location = new Point(392, 77);
            lblMonHoc.Margin = new Padding(4, 0, 4, 0);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Size = new Size(67, 19);
            lblMonHoc.TabIndex = 3;
            lblMonHoc.Text = "Môn học:";
            // 
            // cboMonHoc
            // 
            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonHoc.FormattingEnabled = true;
            cboMonHoc.Location = new Point(473, 73);
            cboMonHoc.Margin = new Padding(4, 4, 4, 4);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(265, 27);
            cboMonHoc.TabIndex = 4;
            // 
            // dgvDanhSachHocSinh
            // 
            dgvDanhSachHocSinh.AllowUserToAddRows = false;
            dgvDanhSachHocSinh.AllowUserToDeleteRows = false;
            dgvDanhSachHocSinh.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDanhSachHocSinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachHocSinh.BackgroundColor = SystemColors.Control;
            dgvDanhSachHocSinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachHocSinh.Location = new Point(21, 132);
            dgvDanhSachHocSinh.Margin = new Padding(4, 4, 4, 4);
            dgvDanhSachHocSinh.Name = "dgvDanhSachHocSinh";
            dgvDanhSachHocSinh.ReadOnly = true;
            dgvDanhSachHocSinh.Size = new Size(1008, 455);
            dgvDanhSachHocSinh.TabIndex = 5;
            // 
            // btnXuatFile
            // 
            btnXuatFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatFile.Location = new Point(904, 70);
            btnXuatFile.Margin = new Padding(4, 4, 4, 4);
            btnXuatFile.Name = "btnXuatFile";
            btnXuatFile.Size = new Size(125, 34);
            btnXuatFile.TabIndex = 6;
            btnXuatFile.Text = "Xuất file Excel";
            btnXuatFile.UseVisualStyleBackColor = true;
            // 
            // lblThongKe
            // 
            lblThongKe.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblThongKe.BorderStyle = BorderStyle.FixedSingle;
            lblThongKe.Location = new Point(21, 602);
            lblThongKe.Margin = new Padding(4, 0, 4, 0);
            lblThongKe.Name = "lblThongKe";
            lblThongKe.Size = new Size(1007, 41);
            lblThongKe.TabIndex = 7;
            lblThongKe.Text = "Thống kê: ";
            lblThongKe.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormXemDiem
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 658);
            Controls.Add(lblThongKe);
            Controls.Add(btnXuatFile);
            Controls.Add(dgvDanhSachHocSinh);
            Controls.Add(cboMonHoc);
            Controls.Add(lblMonHoc);
            Controls.Add(cboLopHoc);
            Controls.Add(lblLopHoc);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 4, 4, 4);
            MinimumSize = new Size(795, 567);
            Name = "FormXemDiem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xem Điểm Học Sinh";
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachHocSinh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLopHoc;
        private System.Windows.Forms.ComboBox cboLopHoc;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.DataGridView dgvDanhSachHocSinh;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.Label lblThongKe;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        #endregion
    }
}