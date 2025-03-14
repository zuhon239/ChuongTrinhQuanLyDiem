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
{ //comment diem
    public partial class Form1 : Form
    {
        private Label lblTieuDe;
        private Label lblTaiKhoan;
        private Label lblMatKhau;
        private TextBox txtTaiKhoan;
        private TextBox txtMatKhau;
        private Button btnDangNhap;
        private Button btnThoat;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Đăng nhập hệ thống";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            lblTieuDe = new Label();
            lblTieuDe.Text = "HỆ THỐNG QUẢN LÝ ĐIỂM HỌC SINH";
            lblTieuDe.AutoSize = false;
            lblTieuDe.Size = new Size(380, 30);
            lblTieuDe.Location = new Point(10, 20);
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.Font = new Font("Arial", 12, FontStyle.Bold);

            lblTaiKhoan = new Label();
            lblTaiKhoan.Text = "Tài khoản:";
            lblTaiKhoan.AutoSize = true;
            lblTaiKhoan.Location = new Point(50, 70);

            lblMatKhau = new Label();
            lblMatKhau.Text = "Mật khẩu:";
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(50, 110);

            txtTaiKhoan = new TextBox();
            txtTaiKhoan.Location = new Point(150, 70);
            txtTaiKhoan.Size = new Size(200, 25);

            txtMatKhau = new TextBox();
            txtMatKhau.Location = new Point(150, 110);
            txtMatKhau.Size = new Size(200, 25);
            txtMatKhau.PasswordChar = '*';

            btnDangNhap = new Button();
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.Location = new Point(100, 160);
            btnDangNhap.Size = new Size(100, 30);

            btnThoat = new Button();
            btnThoat.Text = "Thoát";
            btnThoat.Location = new Point(220, 160);
            btnThoat.Size = new Size(100, 30);
            btnThoat.Click += new EventHandler(btnThoat_Click);

            this.Controls.Add(lblTieuDe);
            this.Controls.Add(lblTaiKhoan);
            this.Controls.Add(lblMatKhau);
            this.Controls.Add(txtTaiKhoan);
            this.Controls.Add(txtMatKhau);
            this.Controls.Add(btnDangNhap);
            this.Controls.Add(btnThoat);
        }
     
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
