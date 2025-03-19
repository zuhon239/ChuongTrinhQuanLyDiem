using QuanLyDiem.Controller;
using QuanLyDiem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiem.View
{
    public partial class FormXemDiem : Form
    {
        private DiemManager quanLyDiem;
        private QuanLyGiaoVien quanLyGiaoVien;
        private HocSinhController hocSinhController;
        private QuanLyLopHoc quanLyLopHoc;
        private QuanLyMonHoc quanLyMonHoc;
        private string dataFolder = "Data";

        public FormXemDiem()
        {
            InitializeComponent();
            KhoiTaoQuanLy();
            LoadDuLieuTuFile();
            SetupControls();
        }

       
        private void KhoiTaoQuanLy()
        {
            quanLyDiem = new DiemManager();
            quanLyGiaoVien = new QuanLyGiaoVien();
            hocSinhController = new HocSinhController();
            quanLyLopHoc = new QuanLyLopHoc();
            quanLyMonHoc = new QuanLyMonHoc();
        }

        private void LoadDuLieuTuFile()
        {
            // Tạo thư mục Data nếu chưa tồn tại
            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            // Đọc dữ liệu từ các file JSON
            DocDuLieuGiaoVien();
            DocDuLieuHocSinh();
            DocDuLieuLopHoc();
            DocDuLieuMonHoc();
            DocDuLieuDiemSo();
        }

        private void DocDuLieuGiaoVien()
        {
            string filePath = Path.Combine(dataFolder, "GiaoVien.json");
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    List<GiaoVien> danhSachGiaoVien = JsonSerializer.Deserialize<List<GiaoVien>>(jsonString);

                    foreach (var giaoVien in danhSachGiaoVien)
                    {
                        quanLyGiaoVien.ThemGiaoVien(giaoVien);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc file giáo viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DocDuLieuHocSinh()
        {
            string filePath = Path.Combine(dataFolder, "HocSinh.json");
            hocSinhController.DocDanhSachHocSinhJson(filePath);
        }

        private void DocDuLieuLopHoc()
        {
            string filePath = Path.Combine(dataFolder, "LopHoc.json");
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    List<LopHoc> danhSachLopHoc = JsonSerializer.Deserialize<List<LopHoc>>(jsonString);

                    foreach (var lopHoc in danhSachLopHoc)
                    {
                        quanLyLopHoc.ThemLopHoc(lopHoc);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc file lớp học: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DocDuLieuMonHoc()
        {
            string filePath = Path.Combine(dataFolder, "MonHoc.json");
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    List<MonHoc> danhSachMonHoc = JsonSerializer.Deserialize<List<MonHoc>>(jsonString);

                    foreach (var monHoc in danhSachMonHoc)
                    {
                        quanLyMonHoc.ThemMonHoc(monHoc);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc file môn học: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DocDuLieuDiemSo()
        {
            string filePath = Path.Combine(dataFolder, "DiemSo.json");
            quanLyDiem.DocDanhSachDiemJson(filePath);
        }

        private void SetupControls()
        {
            // Thiết lập các control trên form
            LoadDanhSachLopHoc();
            LoadDanhSachMonHoc();

            // Đăng ký sự kiện
            cboLopHoc.SelectedIndexChanged += CboLopHoc_SelectedIndexChanged;
            cboMonHoc.SelectedIndexChanged += CboMonHoc_SelectedIndexChanged;
            btnXuatFile.Click += BtnXuatFile_Click;
        }

        private void LoadDanhSachLopHoc()
        {
            cboLopHoc.Items.Clear();
            var danhSachLopHoc = quanLyLopHoc.LayDanhSachLopHoc();
            foreach (var lopHoc in danhSachLopHoc)
            {
                cboLopHoc.Items.Add(new ComboBoxItem { Value = lopHoc.MaLop, Text = lopHoc.TenLop });
            }

            if (cboLopHoc.Items.Count > 0)
            {
                cboLopHoc.SelectedIndex = 0;
            }
        }

        private void LoadDanhSachMonHoc()
        {
            cboMonHoc.Items.Clear();
            cboMonHoc.Items.Add(new ComboBoxItem { Value = "ALL", Text = "Tất cả các môn" });

            var danhSachMonHoc = quanLyMonHoc.LayDanhSachMonHoc();
            foreach (var monHoc in danhSachMonHoc)
            {
                cboMonHoc.Items.Add(new ComboBoxItem { Value = monHoc.MaMH, Text = monHoc.TenMH });
            }

            if (cboMonHoc.Items.Count > 0)
            {
                cboMonHoc.SelectedIndex = 0;
            }
        }

        private void CboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachHocSinhTheoLop();
        }

        private void CboMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachHocSinhTheoLop();
        }

        private void LoadDanhSachHocSinhTheoLop()
        {
            if (cboLopHoc.SelectedItem == null)
                return;

            string maLop = ((ComboBoxItem)cboLopHoc.SelectedItem).Value;
            string maMH = cboMonHoc.SelectedItem != null ? ((ComboBoxItem)cboMonHoc.SelectedItem).Value : "ALL";

            var danhSachHocSinh = hocSinhController.LayDanhSachHocSinh()
                .Where(hs => hs.LopHoc != null && hs.LopHoc.MaLop == maLop)
                .ToList();

            // Tạo DataTable để hiển thị lên DataGridView
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("MaHS", typeof(string));
            dt.Columns.Add("HoTen", typeof(string));

            // Thêm cột cho từng môn học nếu chọn "Tất cả các môn"
            if (maMH == "ALL")
            {
                var danhSachMonHoc = quanLyMonHoc.LayDanhSachMonHoc();
                foreach (var monHoc in danhSachMonHoc)
                {
                    dt.Columns.Add(monHoc.MaMH, typeof(double));
                }
                dt.Columns.Add("DiemTBChung", typeof(double));
            }
            else
            {
                dt.Columns.Add("DiemTB", typeof(double));
            }

            int stt = 1;
            foreach (var hocSinh in danhSachHocSinh)
            {
                if (maMH == "ALL")
                {
                    // Trường hợp xem tất cả các môn
                    DataRow row = dt.NewRow();
                    row["STT"] = stt++;
                    row["MaHS"] = hocSinh.MaHS;
                    row["HoTen"] = hocSinh.HoTen;

                    double tongDiem = 0;
                    int soMonCoTheDiemDuoc = 0;

                    // Lấy điểm từng môn học
                    var danhSachMonHoc = quanLyMonHoc.LayDanhSachMonHoc();
                    foreach (var monHoc in danhSachMonHoc)
                    {
                        var diemSo = quanLyDiem.TimDiemSo(hocSinh.MaHS, monHoc.MaMH);
                        if (diemSo != null)
                        {
                            double diemTB = Math.Round(diemSo.TinhDiemTB(), 1);
                            row[monHoc.MaMH] = diemTB;
                            tongDiem += diemTB;
                            soMonCoTheDiemDuoc++;
                        }
                        else
                        {
                            row[monHoc.MaMH] = DBNull.Value; // Hiển thị là null nếu chưa có điểm
                        }
                    }

                    // Tính điểm trung bình chung
                    if (soMonCoTheDiemDuoc > 0)
                    {
                        row["DiemTBChung"] = Math.Round(tongDiem / soMonCoTheDiemDuoc, 1);
                    }
                    else
                    {
                        row["DiemTBChung"] = DBNull.Value;
                    }

                    dt.Rows.Add(row);
                }
                else
                {
                    // Trường hợp xem 1 môn cụ thể
                    var diemSo = quanLyDiem.TimDiemSo(hocSinh.MaHS, maMH);
                    double diemTB = diemSo != null ? Math.Round(diemSo.TinhDiemTB(), 1) : 0;

                    // Chỉ hiển thị nếu có điểm
                    DataRow row = dt.NewRow();
                    row["STT"] = stt++;
                    row["MaHS"] = hocSinh.MaHS;
                    row["HoTen"] = hocSinh.HoTen;
                    row["DiemTB"] = diemSo != null ? diemTB : DBNull.Value;
                    dt.Rows.Add(row);
                }
            }

            dgvDanhSachHocSinh.DataSource = dt;
            ConfigureDataGridView(maMH);
            CapNhatThongKe(dt, maMH);
        }

        private void ConfigureDataGridView(string maMH)
        {
            // Thiết lập hiển thị cột
            dgvDanhSachHocSinh.Columns["STT"].Width = 50;
            dgvDanhSachHocSinh.Columns["MaHS"].HeaderText = "Mã HS";
            dgvDanhSachHocSinh.Columns["HoTen"].HeaderText = "Họ và Tên";
            dgvDanhSachHocSinh.Columns["HoTen"].Width = 200;

            if (maMH == "ALL")
            {
                dgvDanhSachHocSinh.Columns["DiemTBChung"].HeaderText = "Điểm TB Chung";
                dgvDanhSachHocSinh.Columns["DiemTBChung"].DefaultCellStyle.Format = "N2";

                // Đặt tiêu đề cho các cột môn học
                var danhSachMonHoc = quanLyMonHoc.LayDanhSachMonHoc();
                foreach (var monHoc in danhSachMonHoc)
                {
                    if (dgvDanhSachHocSinh.Columns.Contains(monHoc.MaMH))
                    {
                        dgvDanhSachHocSinh.Columns[monHoc.MaMH].HeaderText = monHoc.TenMH;
                        dgvDanhSachHocSinh.Columns[monHoc.MaMH].DefaultCellStyle.Format = "N2";
                    }
                }
            }
            else
            {
                dgvDanhSachHocSinh.Columns["DiemTB"].HeaderText = "Điểm TB";
                dgvDanhSachHocSinh.Columns["DiemTB"].DefaultCellStyle.Format = "N2";
            }

            // Định dạng màu cho các ô điểm
            dgvDanhSachHocSinh.CellFormatting += DgvDanhSachHocSinh_CellFormatting;
        }

        private void DgvDanhSachHocSinh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value != DBNull.Value && dgvDanhSachHocSinh.Columns[e.ColumnIndex].ValueType == typeof(double))
            {
                double diem = Convert.ToDouble(e.Value);

                if (diem < 5)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if (diem >= 8)
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
            }
        }

        private void CapNhatThongKe(DataTable dt, string maMH)
        {
            try
            {
                string tenLop = cboLopHoc.SelectedItem != null ? ((ComboBoxItem)cboLopHoc.SelectedItem).Text : "";
                int soLuongHocSinh = dt.Rows.Count;
                string thongKeDiem = "";

                if (maMH == "ALL")
                {
                    int soDat = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["DiemTBChung"] != DBNull.Value && Convert.ToDouble(row["DiemTBChung"]) >= 5)
                        {
                            soDat++;
                        }
                    }
                    double tyLe = soLuongHocSinh > 0 ? (double)soDat / soLuongHocSinh * 100 : 0;
                    thongKeDiem = $"Đạt (≥ 5.0): {soDat}/{soLuongHocSinh} ({Math.Round(tyLe, 2)}%)";
                }
                else
                {
                    string tenMonHoc = cboMonHoc.SelectedItem != null ? ((ComboBoxItem)cboMonHoc.SelectedItem).Text : "";
                    int soDat = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["DiemTB"] != DBNull.Value && Convert.ToDouble(row["DiemTB"]) >= 5)
                        {
                            soDat++;
                        }
                    }
                    double tyLe = soLuongHocSinh > 0 ? (double)soDat / soLuongHocSinh * 100 : 0;
                    thongKeDiem = $"Môn {tenMonHoc} - Đạt (≥ 5.0): {soDat}/{soLuongHocSinh} ({Math.Round(tyLe, 2)}%)";
                }

                lblThongKe.Text = $"Lớp: {tenLop} | Tổng số học sinh: {soLuongHocSinh} | {thongKeDiem}";
            }
            catch (Exception ex)
            {
                lblThongKe.Text = "Lỗi khi tính thống kê";
                Console.WriteLine($"Lỗi thống kê: {ex.Message}");
            }
        }

        private void BtnXuatFile_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHocSinh.DataSource == null || cboLopHoc.SelectedItem == null)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files|*.xlsx";
                saveDialog.Title = "Lưu file bảng điểm";
                saveDialog.FileName = $"BangDiem_{DateTime.Now:yyyyMMdd}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Code xuất Excel ở đây (sử dụng thư viện như EPPlus, ClosedXML...)
                    MessageBox.Show("Đã xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
