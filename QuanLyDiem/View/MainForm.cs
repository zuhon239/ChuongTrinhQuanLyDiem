using QuanLyDiem.Controller;
using QuanLyDiem.View;
using QuanLyDiem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiem
{
    public partial class MainForm : Form
    {
        // Các controller
        private HocSinhController hocSinhController;
        //private GiaoVienController giaoVienController;
        private QuanLyLopHoc lopHocController;
        //private MonHocController monHocController;
        //private DiemSoController diemSoController;
        private DiemManager quanlydiem;

        // Các thành phần giao diện (UI Components)
        private Label lblTitle;
        private Panel pnlHeader;
        private Panel pnlContent;
        private Panel pnlFooter;
        private Button btnQuanLyHocSinh;
        private Button btnQuanLyGiaoVien;
        private Button btnQuanLyLopHoc;
        private Button btnQuanLyMonHoc;
        private Button btnQuanLyDiemSo;
        private Button btnThoat;

        // Constructor
        public MainForm(HocSinhController hsCtrl)
        //, GiaoVienController gvCtrl, LopHocController lhCtrl,MonHocController mhCtrl, DiemSoController dsCtrl, QuanLyDiemController qldCtrl)
        {
            InitializeComponent();
            hocSinhController = hsCtrl;
            //giaoVienController = gvCtrl;
            //lopHocController = lhCtrl;
            //monHocController = mhCtrl;
            //diemSoController = dsCtrl;
            //quanLyDiemController = qldCtrl;
        }

        private void InitializeComponent()
        {
            // Khởi tạo các thành phần giao diện
            this.pnlHeader = new Panel();
            this.pnlContent = new Panel();
            this.pnlFooter = new Panel();
            this.lblTitle = new Label();
            this.btnQuanLyHocSinh = new Button();
            this.btnQuanLyGiaoVien = new Button();
            this.btnQuanLyLopHoc = new Button();
            this.btnQuanLyMonHoc = new Button();
            this.btnQuanLyDiemSo = new Button();
            this.btnThoat = new Button();

            // Thiết lập thuộc tính cho Form
            this.Text = "Quản Lý Điểm Trường Phổ Thông";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.MinimumSize = new Size(600, 500);
            this.Icon = SystemIcons.Application;

            // Thiết lập Panel Header
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 80;
            this.pnlHeader.BackColor = Color.FromArgb(0, 122, 204); // Màu xanh Microsoft
            this.pnlHeader.Padding = new Padding(10);
            this.Controls.Add(this.pnlHeader);

            // Thiết lập Label Title
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ ĐIỂM TRƯỜNG PHỔ THÔNG";
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = DockStyle.Fill;
            this.pnlHeader.Controls.Add(this.lblTitle);

            // Thiết lập Panel Content
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.Padding = new Padding(10);
            this.pnlContent.BackColor = Color.White;
            this.Controls.Add(this.pnlContent);

            // Thiết lập Panel Footer
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Height = 60;
            this.pnlFooter.BackColor = Color.FromArgb(230, 230, 230);
            this.pnlFooter.Padding = new Padding(10);
            this.Controls.Add(this.pnlFooter);

            // Thiết lập nút Thoát ở Footer
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.btnThoat.BackColor = Color.FromArgb(220, 53, 69); // Màu đỏ
            this.btnThoat.ForeColor = Color.White;
            this.btnThoat.FlatStyle = FlatStyle.Flat;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.Size = new Size(120, 40);
            this.btnThoat.Dock = DockStyle.Right;
            this.btnThoat.Cursor = Cursors.Hand;
            this.btnThoat.Click += btnThoat_Click;
            this.pnlFooter.Controls.Add(this.btnThoat);

            // Tạo TableLayoutPanel để chứa các nút và thích ứng với kích thước
            TableLayoutPanel tableButtons = new TableLayoutPanel();
            tableButtons.Dock = DockStyle.Fill;
            tableButtons.RowCount = 3;
            tableButtons.ColumnCount = 2;
            tableButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tableButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tableButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tableButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableButtons.Padding = new Padding(5);
            this.pnlContent.Controls.Add(tableButtons);

            // Thiết lập Style chung cho các nút chức năng
            Font buttonFont = new Font("Segoe UI", 12F, FontStyle.Bold);
            Color buttonTextColor = Color.White;
            FlatStyle buttonStyle = FlatStyle.Flat;
            Padding buttonPadding = new Padding(5);

            // Thiết lập nút Quản Lý Học Sinh
            this.btnQuanLyHocSinh.Text = "Quản Lý Học Sinh";
            this.btnQuanLyHocSinh.Font = buttonFont;
            this.btnQuanLyHocSinh.ForeColor = buttonTextColor;
            this.btnQuanLyHocSinh.BackColor = Color.FromArgb(0, 123, 255); // Màu xanh
            this.btnQuanLyHocSinh.FlatStyle = buttonStyle;
            this.btnQuanLyHocSinh.FlatAppearance.BorderSize = 0;
            this.btnQuanLyHocSinh.Dock = DockStyle.Fill;
            this.btnQuanLyHocSinh.Margin = buttonPadding;
            this.btnQuanLyHocSinh.Cursor = Cursors.Hand;
            this.btnQuanLyHocSinh.Click += btnQuanLyHocSinh_Click;
            tableButtons.Controls.Add(this.btnQuanLyHocSinh, 0, 0);

            // Thiết lập nút Quản Lý Giáo Viên
            this.btnQuanLyGiaoVien.Text = "Xem điểm";
            this.btnQuanLyGiaoVien.Font = buttonFont;
            this.btnQuanLyGiaoVien.ForeColor = buttonTextColor;
            this.btnQuanLyGiaoVien.BackColor = Color.FromArgb(40, 167, 69); // Màu xanh lá
            this.btnQuanLyGiaoVien.FlatStyle = buttonStyle;
            this.btnQuanLyGiaoVien.FlatAppearance.BorderSize = 0;
            this.btnQuanLyGiaoVien.Dock = DockStyle.Fill;
            this.btnQuanLyGiaoVien.Margin = buttonPadding;
            this.btnQuanLyGiaoVien.Cursor = Cursors.Hand;
            this.btnQuanLyGiaoVien.Click += btnQuanLyGiaoVien_Click;
            tableButtons.Controls.Add(this.btnQuanLyGiaoVien, 1, 0);

            // Thiết lập nút Quản Lý Lớp Học
            this.btnQuanLyLopHoc.Text = "Quản Lý Lớp Học";
            this.btnQuanLyLopHoc.Font = buttonFont;
            this.btnQuanLyLopHoc.ForeColor = buttonTextColor;
            this.btnQuanLyLopHoc.BackColor = Color.FromArgb(255, 193, 7); // Màu vàng
            this.btnQuanLyLopHoc.FlatStyle = buttonStyle;
            this.btnQuanLyLopHoc.FlatAppearance.BorderSize = 0;
            this.btnQuanLyLopHoc.Dock = DockStyle.Fill;
            this.btnQuanLyLopHoc.Margin = buttonPadding;
            this.btnQuanLyLopHoc.Cursor = Cursors.Hand;
            //this.btnQuanLyLopHoc.Click += btnQuanLyLopHoc_Click;
            tableButtons.Controls.Add(this.btnQuanLyLopHoc, 0, 1);

            // Thiết lập nút Quản Lý Môn Học
            this.btnQuanLyMonHoc.Text = "Quản Lý Môn Học";
            this.btnQuanLyMonHoc.Font = buttonFont;
            this.btnQuanLyMonHoc.ForeColor = buttonTextColor;
            this.btnQuanLyMonHoc.BackColor = Color.FromArgb(111, 66, 193); // Màu tím
            this.btnQuanLyMonHoc.FlatStyle = buttonStyle;
            this.btnQuanLyMonHoc.FlatAppearance.BorderSize = 0;
            this.btnQuanLyMonHoc.Dock = DockStyle.Fill;
            this.btnQuanLyMonHoc.Margin = buttonPadding;
            this.btnQuanLyMonHoc.Cursor = Cursors.Hand;
            //this.btnQuanLyMonHoc.Click += btnQuanLyMonHoc_Click;
            tableButtons.Controls.Add(this.btnQuanLyMonHoc, 1, 1);

            // Thiết lập nút Quản Lý Điểm Số
            this.btnQuanLyDiemSo.Text = "Quản Lý Điểm Số";
            this.btnQuanLyDiemSo.Font = buttonFont;
            this.btnQuanLyDiemSo.ForeColor = buttonTextColor;
            this.btnQuanLyDiemSo.BackColor = Color.FromArgb(23, 162, 184); // Màu xanh dương
            this.btnQuanLyDiemSo.FlatStyle = buttonStyle;
            this.btnQuanLyDiemSo.FlatAppearance.BorderSize = 0;
            this.btnQuanLyDiemSo.Dock = DockStyle.Fill;
            this.btnQuanLyDiemSo.Margin = buttonPadding;
            this.btnQuanLyDiemSo.Cursor = Cursors.Hand;
            this.btnQuanLyDiemSo.Click += btnQuanLyDiemSo_Click;
            tableButtons.Controls.Add(this.btnQuanLyDiemSo, 0, 2);

            // Tạo ô trống cho căn đối trong lưới
            tableButtons.SetColumnSpan(this.btnQuanLyDiemSo, 2);

            // Thêm hiệu ứng hover cho các nút
            this.btnQuanLyHocSinh.MouseEnter += new EventHandler(Button_MouseEnter);
            this.btnQuanLyHocSinh.MouseLeave += new EventHandler(Button_MouseLeave);
            this.btnQuanLyGiaoVien.MouseEnter += new EventHandler(Button_MouseEnter);
            this.btnQuanLyGiaoVien.MouseLeave += new EventHandler(Button_MouseLeave);
            this.btnQuanLyLopHoc.MouseEnter += new EventHandler(Button_MouseEnter);
            this.btnQuanLyLopHoc.MouseLeave += new EventHandler(Button_MouseLeave);
            this.btnQuanLyMonHoc.MouseEnter += new EventHandler(Button_MouseEnter);
            this.btnQuanLyMonHoc.MouseLeave += new EventHandler(Button_MouseLeave);
            this.btnQuanLyDiemSo.MouseEnter += new EventHandler(Button_MouseEnter);
            this.btnQuanLyDiemSo.MouseLeave += new EventHandler(Button_MouseLeave);
            this.btnThoat.MouseEnter += new EventHandler(Button_MouseEnter);
            this.btnThoat.MouseLeave += new EventHandler(Button_MouseLeave);

            // Đăng ký sự kiện thay đổi kích thước form
            this.Resize += new EventHandler(MainForm_Resize);
        }
        // Xử lý sự kiện thay đổi kích thước form
        private void MainForm_Resize(object sender, EventArgs e)
        {
            // Điều chỉnh kích thước font cho phù hợp với kích thước form
            if (this.Width < 700)
            {
                this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                this.btnQuanLyHocSinh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                this.btnQuanLyGiaoVien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                this.btnQuanLyLopHoc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                this.btnQuanLyMonHoc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                this.btnQuanLyDiemSo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }
            else
            {
                this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                this.btnQuanLyHocSinh.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                this.btnQuanLyGiaoVien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                this.btnQuanLyLopHoc.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                this.btnQuanLyMonHoc.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                this.btnQuanLyDiemSo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            }
        }

        // Xử lý sự kiện hover vào nút
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Lưu màu gốc vào Tag nếu chưa lưu
                if (btn.Tag == null)
                    btn.Tag = btn.BackColor;

                // Làm sáng màu nút khi hover
                Color originalColor = (Color)btn.Tag;
                int r = Math.Min(originalColor.R + 20, 255);
                int g = Math.Min(originalColor.G + 20, 255);
                int b = Math.Min(originalColor.B + 20, 255);
                btn.BackColor = Color.FromArgb(r, g, b);

                // Thêm hiệu ứng khi hover
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.White;
            }
        }

        // Xử lý sự kiện rời khỏi nút
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag != null)
            {
                // Khôi phục màu gốc
                btn.BackColor = (Color)btn.Tag;
                btn.FlatAppearance.BorderSize = 0;
            }
        }

        // Sự kiện click cho nút Quản lý Học sinh
        private void btnQuanLyHocSinh_Click(object sender, EventArgs e)
        {
            FormQuanLyHocSinh hocSinhForm = new FormQuanLyHocSinh(hocSinhController, lopHocController);
            hocSinhForm.ShowDialog();
        }

        // Sự kiện click cho nút Quản lý Giáo viên
        private void btnQuanLyGiaoVien_Click(object sender, EventArgs e)
        {
            FormXemDiem xemdiem = new FormXemDiem();
            xemdiem.ShowDialog();
        }

        // Các phương thức xử lý sự kiện đã comment trong code gốc
        //private void btnQuanLyLopHoc_Click(object sender, EventArgs e)
        //{
        //    LopHocForm lopHocForm = new LopHocForm(lopHocController);
        //    lopHocForm.ShowDialog();
        //}

        //private void btnQuanLyMonHoc_Click(object sender, EventArgs e)
        //{
        //    MonHocForm monHocForm = new MonHocForm(monHocController);
        //    monHocForm.ShowDialog();
        //}

        private void btnQuanLyDiemSo_Click(object sender, EventArgs e)
        {
            FormQuanLyDiem diemSoForm = new FormQuanLyDiem();
            diemSoForm.ShowDialog();
        }

        // Sự kiện click cho nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi thoát
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi ứng dụng không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    }
}
