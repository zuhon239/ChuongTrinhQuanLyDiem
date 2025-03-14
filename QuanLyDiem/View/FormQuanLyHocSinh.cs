using QuanLyDiem.Controller;
using QuanLyDiem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiem.View
{
    public partial class FormQuanLyHocSinh : Form
    {
        private HocSinhController quanLyHocSinh;
        private QuanLyLopHoc quanLyLopHoc;

        private Label lblMaHS;
        private Label lblHoTen;
        private Label lblNgaySinh;
        private Label lblGioiTinh;
        private Label lblDiaChi;
        private Label lblLopHoc;

        private TextBox txtMaHS;
        private TextBox txtHoTen;
        private DateTimePicker dtpNgaySinh;
        private ComboBox cboGioiTinh;
        private TextBox txtDiaChi;
        private ComboBox cboLopHoc;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnHuy;

        private DataGridView dgvHocSinh;
        private GroupBox grbThongTin;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private GroupBox grbDanhSach;

        public FormQuanLyHocSinh(HocSinhController quanLyHocSinh, QuanLyLopHoc quanLyLopHoc)
        {
            this.quanLyHocSinh = quanLyHocSinh;
            this.quanLyLopHoc = quanLyLopHoc;
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            grbThongTin = new GroupBox();
            lblMaHS = new Label();
            lblHoTen = new Label();
            lblNgaySinh = new Label();
            lblGioiTinh = new Label();
            lblDiaChi = new Label();
            lblLopHoc = new Label();
            txtMaHS = new TextBox();
            txtHoTen = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            cboGioiTinh = new ComboBox();
            txtDiaChi = new TextBox();
            cboLopHoc = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnHuy = new Button();
            grbDanhSach = new GroupBox();
            dgvHocSinh = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            grbThongTin.SuspendLayout();
            grbDanhSach.SuspendLayout();
            ((ISupportInitialize)dgvHocSinh).BeginInit();
            SuspendLayout();
            // 
            // grbThongTin
            // 
            grbThongTin.Controls.Add(lblMaHS);
            grbThongTin.Controls.Add(lblHoTen);
            grbThongTin.Controls.Add(lblNgaySinh);
            grbThongTin.Controls.Add(lblGioiTinh);
            grbThongTin.Controls.Add(lblDiaChi);
            grbThongTin.Controls.Add(lblLopHoc);
            grbThongTin.Controls.Add(txtMaHS);
            grbThongTin.Controls.Add(txtHoTen);
            grbThongTin.Controls.Add(dtpNgaySinh);
            grbThongTin.Controls.Add(cboGioiTinh);
            grbThongTin.Controls.Add(txtDiaChi);
            grbThongTin.Controls.Add(cboLopHoc);
            grbThongTin.Controls.Add(btnThem);
            grbThongTin.Controls.Add(btnSua);
            grbThongTin.Controls.Add(btnXoa);
            grbThongTin.Controls.Add(btnLuu);
            grbThongTin.Controls.Add(btnHuy);
            grbThongTin.Location = new Point(10, 10);
            grbThongTin.Name = "grbThongTin";
            grbThongTin.Size = new Size(760, 200);
            grbThongTin.TabIndex = 0;
            grbThongTin.TabStop = false;
            grbThongTin.Text = "Thông tin học sinh";
            // 
            // lblMaHS
            // 
            lblMaHS.AutoSize = true;
            lblMaHS.Location = new Point(20, 30);
            lblMaHS.Name = "lblMaHS";
            lblMaHS.Size = new Size(87, 19);
            lblMaHS.TabIndex = 0;
            lblMaHS.Text = "Mã học sinh:";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(20, 70);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(54, 19);
            lblHoTen.TabIndex = 1;
            lblHoTen.Text = "Họ tên:";
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(20, 110);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(73, 19);
            lblNgaySinh.TabIndex = 2;
            lblNgaySinh.Text = "Ngày sinh:";
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(20, 150);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(64, 19);
            lblGioiTinh.TabIndex = 3;
            lblGioiTinh.Text = "Giới tính:";
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Location = new Point(400, 30);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(53, 19);
            lblDiaChi.TabIndex = 4;
            lblDiaChi.Text = "Địa chỉ:";
            // 
            // lblLopHoc
            // 
            lblLopHoc.AutoSize = true;
            lblLopHoc.Location = new Point(400, 70);
            lblLopHoc.Name = "lblLopHoc";
            lblLopHoc.Size = new Size(61, 19);
            lblLopHoc.TabIndex = 5;
            lblLopHoc.Text = "Lớp học:";
            // 
            // txtMaHS
            // 
            txtMaHS.Location = new Point(120, 30);
            txtMaHS.Name = "txtMaHS";
            txtMaHS.Size = new Size(200, 26);
            txtMaHS.TabIndex = 6;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(120, 70);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(200, 26);
            txtHoTen.TabIndex = 7;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(120, 110);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(200, 26);
            dtpNgaySinh.TabIndex = 8;
            dtpNgaySinh.ValueChanged += dtpNgaySinh_ValueChanged;
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGioiTinh.Location = new Point(120, 150);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(200, 27);
            cboGioiTinh.TabIndex = 9;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(500, 30);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(200, 26);
            txtDiaChi.TabIndex = 10;
            // 
            // cboLopHoc
            // 
            cboLopHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLopHoc.Location = new Point(500, 70);
            cboLopHoc.Name = "cboLopHoc";
            cboLopHoc.Size = new Size(200, 27);
            cboLopHoc.TabIndex = 11;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(400, 150);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(80, 30);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(490, 150);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(80, 30);
            btnSua.TabIndex = 13;
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(580, 150);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(80, 30);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(400, 150);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(80, 30);
            btnLuu.TabIndex = 15;
            btnLuu.Text = "Lưu";
            btnLuu.Visible = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(490, 150);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(80, 30);
            btnHuy.TabIndex = 16;
            btnHuy.Text = "Hủy";
            btnHuy.Visible = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // grbDanhSach
            // 
            grbDanhSach.Controls.Add(dgvHocSinh);
            grbDanhSach.Location = new Point(10, 220);
            grbDanhSach.Name = "grbDanhSach";
            grbDanhSach.Size = new Size(760, 320);
            grbDanhSach.TabIndex = 1;
            grbDanhSach.TabStop = false;
            grbDanhSach.Text = "Danh sách học sinh";
            // 
            // dgvHocSinh
            // 
            dgvHocSinh.AllowUserToAddRows = false;
            dgvHocSinh.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dgvHocSinh.Location = new Point(6, 29);
            dgvHocSinh.Name = "dgvHocSinh";
            dgvHocSinh.ReadOnly = true;
            dgvHocSinh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHocSinh.Size = new Size(740, 300);
            dgvHocSinh.TabIndex = 0;
            dgvHocSinh.CellClick += dgvHocSinh_CellClick;
            dgvHocSinh.CellContentClick += dgvHocSinh_CellContentClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Mã HS";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Họ tên";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Ngày sinh";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Giới tính";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Địa chỉ";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Lớp học";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // FormQuanLyHocSinh
            // 
            ClientSize = new Size(770, 561);
            Controls.Add(grbThongTin);
            Controls.Add(grbDanhSach);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormQuanLyHocSinh";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý học sinh";
            grbThongTin.ResumeLayout(false);
            grbThongTin.PerformLayout();
            grbDanhSach.ResumeLayout(false);
            ((ISupportInitialize)dgvHocSinh).EndInit();
            ResumeLayout(false);
        }

        private void LoadLopHoc()
        {
            cboLopHoc.Items.Clear();
            List<LopHoc> danhSachLopHoc = quanLyLopHoc.LayDanhSachLopHoc();
            for (int i = 0; i < danhSachLopHoc.Count; i++)
            {
                cboLopHoc.Items.Add(danhSachLopHoc[i].TenLop);
            }
        }
        private void LoadDataToDataGridView()
        {
            dgvHocSinh.Rows.Clear();
            List<HocSinh> danhSachHocSinh = quanLyHocSinh.LayDanhSachHocSinh();
            for (int i = 0; i < danhSachHocSinh.Count; i++)
            {
                HocSinh hocSinh = danhSachHocSinh[i];
                dgvHocSinh.Rows.Add(
                    hocSinh.MaHS,
                    hocSinh.HoTen,
                    hocSinh.NgaySinh.ToShortDateString(),
                    hocSinh.GioiTinh,
                    hocSinh.DiaChi,
                    hocSinh.LopHoc != null ? hocSinh.LopHoc.TenLop : ""
                );
            }
        }

        private void SetControlsEnabled(bool enabled)
        {
            txtMaHS.Enabled = enabled;
            txtHoTen.Enabled = enabled;
            dtpNgaySinh.Enabled = enabled;
            cboGioiTinh.Enabled = enabled;
            txtDiaChi.Enabled = enabled;
            cboLopHoc.Enabled = enabled;
        }

        private void ClearControls()
        {
            txtMaHS.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            cboGioiTinh.SelectedIndex = -1;
            txtDiaChi.Clear();
            cboLopHoc.SelectedIndex = -1;
        }

        private void ShowAddControls()
        {
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            SetControlsEnabled(true);
            txtMaHS.Focus();
        }

        private void ShowNormalControls()
        {
            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            SetControlsEnabled(false);
            ClearControls();
        }

        private void dgvHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHocSinh.Rows[e.RowIndex];
                txtMaHS.Text = row.Cells["MaHS"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                dtpNgaySinh.Value = DateTime.Parse(row.Cells["NgaySinh"].Value.ToString());
                cboGioiTinh.SelectedItem = row.Cells["GioiTinh"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                cboLopHoc.SelectedItem = row.Cells["LopHoc"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearControls();
            ShowAddControls();
            btnLuu.Tag = "Them";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHS.Text))
            {
                MessageBox.Show("Vui lòng chọn học sinh cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowAddControls();
            btnLuu.Tag = "Sua";
            txtMaHS.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHS.Text))
            {
                MessageBox.Show("Vui lòng chọn học sinh cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa học sinh này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Thực hiện xóa học sinh
                // Trong thực tế cần kiểm tra xem học sinh có điểm không trước khi xóa
                // Nếu có điểm thì không cho xóa hoặc xóa cả điểm

                // Tạm thời chỉ xóa học sinh khỏi danh sách
                List<HocSinh> danhSachHocSinh = quanLyHocSinh.LayDanhSachHocSinh();
                for (int i = 0; i < danhSachHocSinh.Count; i++)
                {
                    if (danhSachHocSinh[i].MaHS == txtMaHS.Text)
                    {
                        danhSachHocSinh.RemoveAt(i);
                        break;
                    }
                }

                // Cập nhật lại DataGridView
                LoadDataToDataGridView();
                ClearControls();
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(txtMaHS.Text) ||
                string.IsNullOrEmpty(txtHoTen.Text) ||
                cboGioiTinh.SelectedIndex == -1 ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                cboLopHoc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin lớp học
            LopHoc lopHoc = null;
            List<LopHoc> danhSachLopHoc = quanLyLopHoc.LayDanhSachLopHoc();
            for (int i = 0; i < danhSachLopHoc.Count; i++)
            {
                if (danhSachLopHoc[i].TenLop == cboLopHoc.SelectedItem.ToString())
                {
                    lopHoc = danhSachLopHoc[i];
                    break;
                }
            }

            if (btnLuu.Tag.ToString() == "Them")
            {
                HocSinh existingHS = quanLyHocSinh.TimHocSinhTheoMa(txtMaHS.Text);
                if (existingHS != null)
                {
                    MessageBox.Show("Mã học sinh đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                HocSinh hocSinh = new HocSinh(
               txtMaHS.Text,
               txtHoTen.Text,
               dtpNgaySinh.Value,
               cboGioiTinh.SelectedItem.ToString(),
               txtDiaChi.Text,
               lopHoc);
                // Thêm học sinh vào danh sách
                quanLyHocSinh.Them(hocSinh);
                MessageBox.Show("Thêm học sinh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (btnLuu.Tag.ToString() == "Sua")
            {
                // Tìm học sinh cần sửa
                HocSinh hocSinh = quanLyHocSinh.TimHocSinhTheoMa(txtMaHS.Text);
                if (hocSinh != null)
                {
                    // Cập nhật thông tin học sinh
                    hocSinh.HoTen = txtHoTen.Text;
                    hocSinh.NgaySinh = dtpNgaySinh.Value;
                    hocSinh.GioiTinh = cboGioiTinh.SelectedItem.ToString();
                    hocSinh.DiaChi = txtDiaChi.Text;
                    hocSinh.LopHoc = lopHoc;

                    MessageBox.Show("Cập nhật thông tin học sinh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // Cập nhật lại DataGridView
            LoadDataToDataGridView();
            ShowNormalControls();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ShowNormalControls();
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvHocSinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
