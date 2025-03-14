namespace QuanLyDiem.View
{
    public partial class FormDangNhap : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Label lblTieuDe;
        private Label lblTaiKhoan;
        private Label lblMatKhau;
        private TextBox txtTaiKhoan;
        private TextBox txtMatKhau;
        private Button btnDangNhap;
        private Button btnThoat;

        public FormDangNhap()
        {
            Text = "Đăng nhập hệ thống";
            Size = new Size(400, 250);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

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

            Controls.Add(lblTieuDe);
            Controls.Add(lblTaiKhoan);
            Controls.Add(lblMatKhau);
            Controls.Add(txtTaiKhoan);
            Controls.Add(txtMatKhau);
            Controls.Add(btnDangNhap);
            Controls.Add(btnThoat);
        }
     

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
                
    }
}