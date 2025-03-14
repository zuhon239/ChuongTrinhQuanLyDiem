using QuanLyDiem.Controller;
using QuanLyDiem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiem.View
{
    public partial class HocSinhForm : Form
    {
        private HocSinhController hocSinhController;

        // Các thành phần giao diện
        private Label lblTitle;
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
        private Button btnThoat;

        private DataGridView dataGridViewHocSinh;

        public HocSinhForm(HocSinhController controller)
        {
            hocSinhController = controller;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Khởi tạo các thành phần giao diện
            lblTitle = new Label();
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
            btnThoat = new Button();

            dataGridViewHocSinh = new DataGridView();

            // Tạo TableLayoutPanel để bố trí các thành phần
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.RowCount = 8; // 8 hàng: tiêu đề, 6 hàng nhập liệu, hàng nút, hàng DataGridView
            tableLayoutPanel.ColumnCount = 2; // 2 cột: nhãn và ô nhập liệu
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F)); // Cột nhãn
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F)); // Cột ô nhập liệu
            for (int i = 0; i < 7; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            }
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Hàng DataGridView chiếm phần còn lại

            // Thiết lập tiêu đề
            lblTitle.Text = "Quản Lý Học Sinh";
            lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(lblTitle, 0, 0);
            tableLayoutPanel.SetColumnSpan(lblTitle, 2); // Tiêu đề chiếm cả 2 cột

            // Thiết lập nhãn và ô nhập liệu
            // Mã HS
            lblMaHS.Text = "Mã HS:";
            lblMaHS.TextAlign = ContentAlignment.MiddleRight;
            tableLayoutPanel.Controls.Add(lblMaHS, 0, 1);
            txtMaHS.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(txtMaHS, 1, 1);

            // Họ tên
            lblHoTen.Text = "Họ tên:";
            lblHoTen.TextAlign = ContentAlignment.MiddleRight;
            tableLayoutPanel.Controls.Add(lblHoTen, 0, 2);
            txtHoTen.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(txtHoTen, 1, 2);

            // Ngày sinh
            lblNgaySinh.Text = "Ngày sinh:";
            lblNgaySinh.TextAlign = ContentAlignment.MiddleRight;
            tableLayoutPanel.Controls.Add(lblNgaySinh, 0, 3);
            dtpNgaySinh.Dock = DockStyle.Fill;
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            tableLayoutPanel.Controls.Add(dtpNgaySinh, 1, 3);

            // Giới tính
            lblGioiTinh.Text = "Giới tính:";
            lblGioiTinh.TextAlign = ContentAlignment.MiddleRight;
            tableLayoutPanel.Controls.Add(lblGioiTinh, 0, 4);
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ", "Khác" });
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(cboGioiTinh, 1, 4);

            // Địa chỉ
            lblDiaChi.Text = "Địa chỉ:";
            lblDiaChi.TextAlign = ContentAlignment.MiddleRight;
            tableLayoutPanel.Controls.Add(lblDiaChi, 0, 5);
            txtDiaChi.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(txtDiaChi, 1, 5);

            // Lớp học
            lblLopHoc.Text = "Lớp học:";
            lblLopHoc.TextAlign = ContentAlignment.MiddleRight;
            tableLayoutPanel.Controls.Add(lblLopHoc, 0, 6);
            cboLopHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLopHoc.Dock = DockStyle.Fill;
            // Giả sử danh sách lớp học được lấy từ controller
            //cboLopHoc.DataSource = hocSinhController.GetDanhSachLopHoc();
            tableLayoutPanel.Controls.Add(cboLopHoc, 1, 6);

            // Thiết lập các nút trong FlowLayoutPanel
            FlowLayoutPanel flowPanelButtons = new FlowLayoutPanel();
            flowPanelButtons.Dock = DockStyle.Fill;
            flowPanelButtons.FlowDirection = FlowDirection.LeftToRight;
            flowPanelButtons.AutoSize = true;

            btnThem.Text = "Thêm";
            btnThem.BackColor = Color.LightGreen;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Click += btnThem_Click;

            btnSua.Text = "Sửa";
            btnSua.BackColor = Color.LightBlue;
            btnSua.FlatStyle = FlatStyle.Flat;
            // btnSua.Click += btnSua_Click; // Thêm sự kiện sau nếu cần

            btnXoa.Text = "Xóa";
            btnXoa.BackColor = Color.LightCoral;
            btnXoa.FlatStyle = FlatStyle.Flat;
            // btnXoa.Click += btnXoa_Click; // Thêm sự kiện sau nếu cần

            btnThoat.Text = "Thoát";
            btnThoat.BackColor = Color.LightGray;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Click += (s, e) => this.Close();

            flowPanelButtons.Controls.Add(btnThem);
            flowPanelButtons.Controls.Add(btnSua);
            flowPanelButtons.Controls.Add(btnXoa);
            flowPanelButtons.Controls.Add(btnThoat);

            tableLayoutPanel.Controls.Add(flowPanelButtons, 0, 7);
            tableLayoutPanel.SetColumnSpan(flowPanelButtons, 2); // Các nút chiếm cả 2 cột

            // Thiết lập DataGridView
            dataGridViewHocSinh.Dock = DockStyle.Fill;
            dataGridViewHocSinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewHocSinh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHocSinh.MultiSelect = false;
            dataGridViewHocSinh.ReadOnly = true;
            tableLayoutPanel.Controls.Add(dataGridViewHocSinh, 0, 8);
            tableLayoutPanel.SetColumnSpan(dataGridViewHocSinh, 2); // DataGridView chiếm cả 2 cột

            // Thiết lập thuộc tính cho Form
            this.Text = "Quản Lý Học Sinh";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Controls.Add(tableLayoutPanel);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maHS = txtMaHS.Text;
            string hoTen = txtHoTen.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string gioiTinh = cboGioiTinh.SelectedItem.ToString();
            string diaChi = txtDiaChi.Text;
            LopHoc lopHoc = (LopHoc)cboLopHoc.SelectedItem;

            HocSinh hocSinh = new HocSinh(maHS, hoTen, ngaySinh, gioiTinh, diaChi, lopHoc);
            hocSinhController.Them(hocSinh);
            MessageBox.Show("Thêm học sinh thành công!");
        }
    }
}
