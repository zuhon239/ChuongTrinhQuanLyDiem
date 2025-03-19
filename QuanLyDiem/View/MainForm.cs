using QuanLyDiem.Controller;
using QuanLyDiem.View;
using QuanLyDiem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace QuanLyDiem
{
    public partial class MainForm : Form
    {
        // Các controller
        private DiemManager diemSoController;

        // Các thành phần giao diện (UI Components)
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlHeader;
        private Panel pnlContent;
        private Panel pnlFooter;
        private Button btnQuanLyDiem;
        private Button btnXemDiem;
        private Button btnThoat;
        private PictureBox picLogo;

        // Constructor
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Áp dụng animation khi form mở
            AnimateControls();
        }

        private void AnimateControls()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 30;
            int opacity = 0;

            pnlContent.Visible = false;
            lblSubtitle.Visible = false;

            // Lưu màu ban đầu
            Color originalBackColor = pnlContent.BackColor;

            timer.Tick += (s, e) => {
                opacity += 5;
                if (opacity == 5) pnlContent.Visible = true;
                if (opacity == 25) lblSubtitle.Visible = true;

                if (opacity >= 100)
                {
                    timer.Stop();
                    timer.Dispose();
                }
                else
                {
                    lblTitle.ForeColor = Color.FromArgb(opacity, lblTitle.ForeColor);
                    if (pnlContent.Visible)
                        pnlContent.BackColor = Color.FromArgb(opacity, originalBackColor);
                    if (lblSubtitle.Visible)
                        lblSubtitle.ForeColor = Color.FromArgb(opacity, lblSubtitle.ForeColor);
                }
            };

            timer.Start();
        }

        private void InitializeComponent()
        {
            // Khởi tạo các thành phần giao diện
            this.pnlHeader = new Panel();
            this.pnlContent = new Panel();
            this.pnlFooter = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.btnQuanLyDiem = new Button();
            this.btnXemDiem = new Button();
            this.btnThoat = new Button();
            this.picLogo = new PictureBox();

            // Thiết lập thuộc tính cho Form
            this.Text = "Quản Lý Điểm Trường THPT Lý Thường Kiệt";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 247);
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.MinimumSize = new Size(800, 550);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Icon = SystemIcons.Application;

            // Thiết lập Panel Header
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 140;
            this.pnlHeader.BackColor = Color.FromArgb(44, 62, 80); // Màu tối hiện đại
            this.pnlHeader.Padding = new Padding(20);
            this.Controls.Add(this.pnlHeader);

            // Thiết lập Logo
            this.picLogo = new PictureBox();
            this.picLogo.Size = new Size(64, 64);
            this.picLogo.Location = new Point(20, 30);
            this.picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            // Tạo logo đơn giản
            Bitmap logoBitmap = new Bitmap(64, 64);
            using (Graphics g = Graphics.FromImage(logoBitmap))
            {
                g.Clear(Color.FromArgb(52, 152, 219));
                g.FillEllipse(new SolidBrush(Color.White), 10, 10, 44, 44);
                g.DrawString("LTK", new Font("Arial", 14, FontStyle.Bold), new SolidBrush(Color.FromArgb(52, 152, 219)), 11, 21);
            }
            this.picLogo.Image = logoBitmap;
            this.pnlHeader.Controls.Add(this.picLogo);

            // Panel cho tiêu đề
            Panel titlePanel = new Panel();
            titlePanel.Location = new Point(95, 20);
            titlePanel.Size = new Size(650, 100);
            titlePanel.BackColor = Color.Transparent;
            this.pnlHeader.Controls.Add(titlePanel);

            // Thiết lập Label Title
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ ĐIỂM";
            this.lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.TextAlign = ContentAlignment.BottomLeft;
            this.lblTitle.Dock = DockStyle.Top;
            this.lblTitle.Height = 50;
            titlePanel.Controls.Add(this.lblTitle);

            // Thiết lập Label Subtitle
            this.lblSubtitle.Text = "TRƯỜNG THPT LÝ THƯỜNG KIỆT";
            this.lblSubtitle.Font = new Font("Segoe UI Light", 14F, FontStyle.Regular);
            this.lblSubtitle.ForeColor = Color.FromArgb(189, 195, 199);
            this.lblSubtitle.TextAlign = ContentAlignment.TopLeft;
            this.lblSubtitle.Dock = DockStyle.Bottom;
            this.lblSubtitle.Height = 30;
            titlePanel.Controls.Add(this.lblSubtitle);

            // Thiết lập Panel Content
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.Padding = new Padding(40);
            this.pnlContent.BackColor = Color.FromArgb(245, 245, 247);
            this.Controls.Add(this.pnlContent);

            // Thiết lập Panel Footer
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Height = 70;
            this.pnlFooter.BackColor = Color.FromArgb(236, 240, 241);
            this.pnlFooter.Padding = new Padding(20);
            this.Controls.Add(this.pnlFooter);

            // Thiết lập nút Thoát ở Footer
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.btnThoat.BackColor = Color.FromArgb(231, 76, 60); // Màu đỏ hiện đại
            this.btnThoat.ForeColor = Color.White;
            this.btnThoat.FlatStyle = FlatStyle.Flat;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.Size = new Size(120, 40);
            this.btnThoat.Dock = DockStyle.Right;
            this.btnThoat.Cursor = Cursors.Hand;
            this.btnThoat.Click += btnThoat_Click;
            this.pnlFooter.Controls.Add(this.btnThoat);

            // Thêm thông tin phiên bản vào footer
            Label lblVersion = new Label();
            lblVersion.Text = "Phiên bản 2.0 | Năm học 2024-2025";
            lblVersion.ForeColor = Color.FromArgb(127, 140, 141);
            lblVersion.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(20, 25);
            this.pnlFooter.Controls.Add(lblVersion);

            // Tạo card layout để chứa các nút chức năng
            TableLayoutPanel cardLayout = new TableLayoutPanel();
            cardLayout.Dock = DockStyle.Fill;
            cardLayout.ColumnCount = 2;
            cardLayout.RowCount = 1;
            cardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            cardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            cardLayout.Padding = new Padding(10);
            this.pnlContent.Controls.Add(cardLayout);

            // Tạo card cho nút Quản Lý Điểm
            Panel cardQuanLyDiem = CreateCard("Quản Lý Điểm", "Nhập, chỉnh sửa và quản lý điểm số của học sinh",
                Color.FromArgb(41, 128, 185), "📊");
            this.btnQuanLyDiem = (Button)cardQuanLyDiem.Tag;
            this.btnQuanLyDiem.Click += btnQuanLyDiem_Click;
            cardLayout.Controls.Add(cardQuanLyDiem, 0, 0);

            // Tạo card cho nút Xem Điểm
            Panel cardXemDiem = CreateCard("Xem Điểm", "Tra cứu và xem bảng điểm học sinh theo lớp và môn học",
                Color.FromArgb(46, 204, 113), "🔍");
            this.btnXemDiem = (Button)cardXemDiem.Tag;
            this.btnXemDiem.Click += btnXemDiem_Click;
            cardLayout.Controls.Add(cardXemDiem, 1, 0);

            // Thêm hiệu ứng hover cho nút thoát
            this.btnThoat.MouseEnter += new EventHandler(Button_MouseEnter);
            this.btnThoat.MouseLeave += new EventHandler(Button_MouseLeave);

            // Đăng ký sự kiện thay đổi kích thước form
            this.Resize += new EventHandler(MainForm_Resize);
        }

        // Phương thức tạo card UI
        private Panel CreateCard(string title, string description, Color color, string emoji)
        {
            Panel card = new Panel();
            card.Margin = new Padding(15);
            card.BackColor = Color.White;
            card.Size = new Size(300, 250);
            card.Padding = new Padding(20);
            // Thêm đổ bóng
            card.Paint += (sender, e) => {
                Rectangle rect = new Rectangle(0, 0, card.Width, card.Height);
                using (GraphicsPath path = RoundedRect(rect, 10))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    using (SolidBrush brush = new SolidBrush(card.BackColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }
            };

            // Nhãn emoji
            Label lblEmoji = new Label();
            lblEmoji.Text = emoji;
            lblEmoji.Font = new Font("Segoe UI", 32F, FontStyle.Regular);
            lblEmoji.AutoSize = true;
            lblEmoji.Location = new Point(20, 20);
            card.Controls.Add(lblEmoji);

            // Nhãn tiêu đề
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(20, 85);
            lblTitle.AutoSize = true;
            card.Controls.Add(lblTitle);

            // Nhãn mô tả
            Label lblDescription = new Label();
            lblDescription.Text = description;
            lblDescription.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblDescription.ForeColor = Color.FromArgb(127, 140, 141);
            lblDescription.Location = new Point(20, 120);
            lblDescription.Size = new Size(260, 60);
            card.Controls.Add(lblDescription);

            // Nút chức năng
            Button btnFunction = new Button();
            btnFunction.Text = "Mở " + title;
            btnFunction.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnFunction.ForeColor = Color.White;
            btnFunction.BackColor = color;
            btnFunction.FlatStyle = FlatStyle.Flat;
            btnFunction.FlatAppearance.BorderSize = 0;
            btnFunction.Size = new Size(260, 45);
            btnFunction.Location = new Point(20, 185);
            btnFunction.Cursor = Cursors.Hand;

            // Hiệu ứng hover cho nút
            btnFunction.MouseEnter += (sender, e) => {
                btnFunction.BackColor = ControlPaint.Light(color, 0.2f);
            };
            btnFunction.MouseLeave += (sender, e) => {
                btnFunction.BackColor = color;
            };

            card.Controls.Add(btnFunction);

            // Lưu tham chiếu button vào Tag của card
            card.Tag = btnFunction;

            return card;
        }

        // Tạo GraphicsPath cho hình chữ nhật bo góc
        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            // Top left arc  
            path.AddArc(arc, 180, 90);

            // Top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        // Xử lý sự kiện thay đổi kích thước form
        private void MainForm_Resize(object sender, EventArgs e)
        {
            // Điều chỉnh kích thước font cho phù hợp với kích thước form
            if (this.Width < 800)
            {
                this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
                this.lblSubtitle.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular);
            }
            else
            {
                this.lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
                this.lblSubtitle.Font = new Font("Segoe UI Light", 14F, FontStyle.Regular);
            }
        }

        // Xử lý sự kiện hover vào nút thoát
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Lưu màu gốc vào Tag nếu chưa lưu
                if (btn.Tag == null)
                    btn.Tag = btn.BackColor;

                // Làm đậm màu nút khi hover
                btn.BackColor = Color.FromArgb(192, 57, 43); // Đỏ đậm hơn
            }
        }

        // Xử lý sự kiện rời khỏi nút thoát
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag != null)
            {
                // Khôi phục màu gốc
                btn.BackColor = Color.FromArgb(231, 76, 60); // Màu đỏ gốc
            }
        }

        // Sự kiện click cho nút Quản lý Điểm
        private void btnQuanLyDiem_Click(object sender, EventArgs e)
        {
            FormQuanLyDiem diemSoForm = new FormQuanLyDiem();
            diemSoForm.ShowDialog();
        }

        // Sự kiện click cho nút Xem Điểm
        private void btnXemDiem_Click(object sender, EventArgs e)
        {
            FormXemDiem xemDiemForm = new FormXemDiem();
            xemDiemForm.ShowDialog();
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
