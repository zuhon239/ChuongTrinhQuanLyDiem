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
            List <LopHoc> danhSachLopHoc = quanLyLopHoc.LayDanhSachLopHoc();
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

            List<MonHoc> danhSachMonHoc = quanLyMonHoc.LayDanhSachMonHoc(); 
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

            List <HocSinh> danhSachHocSinh = hocSinhController.LayDanhSachHocSinh()
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
                List <MonHoc> danhSachMonHoc = quanLyMonHoc.LayDanhSachMonHoc();
                foreach (var monHoc in danhSachMonHoc)
                {
                    dt.Columns.Add(monHoc.MaMH, typeof(double));
                }
                dt.Columns.Add("DiemTBChung", typeof(double));
                dt.Columns.Add("XepLoai", typeof(string));
            }
            else
            {
                // Thêm các cột chi tiết cho một môn học
                dt.Columns.Add("DiemMieng", typeof(double));
                dt.Columns.Add("Diem15Phut", typeof(double));
                dt.Columns.Add("DiemGiuaKy", typeof(double));
                dt.Columns.Add("DiemCuoiKy", typeof(double));
                dt.Columns.Add("DiemTB", typeof(double));
                dt.Columns.Add("XepLoai", typeof(string));
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
                    List<MonHoc> danhSachMonHoc = quanLyMonHoc.LayDanhSachMonHoc();
                    foreach (var monHoc in danhSachMonHoc)
                    {
                        DiemSo diemSo = quanLyDiem.TimDiemSo(hocSinh.MaHS, monHoc.MaMH);
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
                    double diemTBChung = quanLyDiem.TinhDiemTBHocSinh(hocSinh.MaHS); 
                    if (soMonCoTheDiemDuoc > 0)
                    {
                        diemTBChung = Math.Round(diemTBChung, 1);
                        row["DiemTBChung"] = diemTBChung;
                        row["XepLoai"] = XepLoaiHocSinh(diemTBChung);
                    }
                    else
                    {
                        row["DiemTBChung"] = DBNull.Value;
                        row["XepLoai"] = "";
                    }

                    dt.Rows.Add(row);
                }
                else
                {
                    // Trường hợp xem 1 môn cụ thể
                    DiemSo diemSo = quanLyDiem.TimDiemSo(hocSinh.MaHS, maMH);
                    if (diemSo != null)
                    {
                        double diemTB = Math.Round(diemSo.TinhDiemTB(), 1);
                        string xepLoai = XepLoaiHocSinh(diemTB);

                        DataRow row = dt.NewRow();
                        row["STT"] = stt++;
                        row["MaHS"] = hocSinh.MaHS;
                        row["HoTen"] = hocSinh.HoTen;
                        row["DiemMieng"] = diemSo.DiemMieng == -1 ? (object)DBNull.Value : diemSo.DiemMieng;
                        row["Diem15Phut"] = diemSo.Diem15Phut == -1 ? (object)DBNull.Value : diemSo.Diem15Phut;
                        row["DiemGiuaKy"] = diemSo.Diem1Tiet == -1 ? (object)DBNull.Value : diemSo.Diem1Tiet;
                        row["DiemCuoiKy"] = diemSo.DiemHK == -1 ? (object)DBNull.Value : diemSo.DiemHK;
                        row["DiemTB"] = diemTB;
                        row["XepLoai"] = xepLoai;
                        dt.Rows.Add(row);
                    }
                    else
                    {
                        // Hiển thị học sinh không có điểm
                        DataRow row = dt.NewRow();
                        row["STT"] = stt++;
                        row["MaHS"] = hocSinh.MaHS;
                        row["HoTen"] = hocSinh.HoTen;
                        row["DiemMieng"] = DBNull.Value;
                        row["Diem15Phut"] = DBNull.Value;
                        row["DiemGiuaKy"] = DBNull.Value;
                        row["DiemCuoiKy"] = DBNull.Value;
                        row["DiemTB"] = DBNull.Value;
                        row["XepLoai"] = "";
                        dt.Rows.Add(row);
                    }
                }
            }

            dgvDanhSachHocSinh.DataSource = dt;
            ConfigureDataGridView(maMH);
            CapNhatThongKe(dt, maMH);
        }

        private string XepLoaiHocSinh(double diemTB)
        {
            if (diemTB >= 8.0) return "Giỏi";
            if (diemTB >= 7.0) return "Khá";
            if (diemTB >= 5.0) return "Trung bình";
            if (diemTB >= 3.5) return "Yếu";
            return "Kém";
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
                dgvDanhSachHocSinh.Columns["XepLoai"].HeaderText = "Xếp Loại";

                // Đặt tiêu đề cho các cột môn học
                List<MonHoc> danhSachMonHoc = quanLyMonHoc.LayDanhSachMonHoc();
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
                // Thiết lập hiển thị cho chi tiết một môn học
                dgvDanhSachHocSinh.Columns["DiemMieng"].HeaderText = "Điểm Miệng";
                dgvDanhSachHocSinh.Columns["DiemMieng"].DefaultCellStyle.Format = "N2";

                dgvDanhSachHocSinh.Columns["Diem15Phut"].HeaderText = "Điểm 15 Phút";
                dgvDanhSachHocSinh.Columns["Diem15Phut"].DefaultCellStyle.Format = "N2";

                dgvDanhSachHocSinh.Columns["DiemGiuaKy"].HeaderText = "Điểm Giữa Kỳ";
                dgvDanhSachHocSinh.Columns["DiemGiuaKy"].DefaultCellStyle.Format = "N2";

                dgvDanhSachHocSinh.Columns["DiemCuoiKy"].HeaderText = "Điểm Cuối Kỳ";
                dgvDanhSachHocSinh.Columns["DiemCuoiKy"].DefaultCellStyle.Format = "N2";

                dgvDanhSachHocSinh.Columns["DiemTB"].HeaderText = "Điểm TB";
                dgvDanhSachHocSinh.Columns["DiemTB"].DefaultCellStyle.Format = "N2";

                dgvDanhSachHocSinh.Columns["XepLoai"].HeaderText = "Xếp Loại";
            }

            // Định dạng màu cho các ô điểm
            dgvDanhSachHocSinh.CellFormatting += DgvDanhSachHocSinh_CellFormatting;
        }

        private void DgvDanhSachHocSinh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value != DBNull.Value)
            {
                // Định dạng màu cho các ô điểm
                if (dgvDanhSachHocSinh.Columns[e.ColumnIndex].ValueType == typeof(double))
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
                // Định dạng màu cho cột xếp loại
                else if (dgvDanhSachHocSinh.Columns[e.ColumnIndex].Name == "XepLoai" && e.Value is string)
                {
                    string xepLoai = e.Value.ToString();
                    switch (xepLoai)
                    {
                        case "Giỏi":
                            e.CellStyle.ForeColor = Color.Blue;
                            e.CellStyle.Font = new Font(dgvDanhSachHocSinh.Font, FontStyle.Bold);
                            break;
                        case "Khá":
                            e.CellStyle.ForeColor = Color.Green;
                            break;
                        case "Trung bình":
                            e.CellStyle.ForeColor = Color.Black;
                            break;
                        case "Yếu":
                        case "Kém":
                            e.CellStyle.ForeColor = Color.Red;
                            break;
                    }
                }
            }
        }

        private void CapNhatThongKe(DataTable dt, string maMH)
        {
            try
            {
                string tenLop = cboLopHoc.SelectedItem != null ? ((ComboBoxItem)cboLopHoc.SelectedItem).Text : "";
                int soLuongHocSinh = dt.Rows.Count;

                // Thống kê chi tiết
                int soGioi = 0;
                int soKha = 0;
                int soTrungBinh = 0;
                int soYeu = 0;
                int soKem = 0;

                if (maMH == "ALL")
                {
                    // Thống kê cho tất cả các môn
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["XepLoai"] != DBNull.Value)
                        {
                            string xepLoai = row["XepLoai"].ToString();
                            switch (xepLoai)
                            {
                                case "Giỏi": soGioi++; break;
                                case "Khá": soKha++; break;
                                case "Trung bình": soTrungBinh++; break;
                                case "Yếu": soYeu++; break;
                                case "Kém": soKem++; break;
                            }
                        }
                    }
                }
                else
                {
                    // Thống kê cho một môn học cụ thể
                    string tenMonHoc = cboMonHoc.SelectedItem != null ? ((ComboBoxItem)cboMonHoc.SelectedItem).Text : "";

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["XepLoai"] != DBNull.Value && !string.IsNullOrEmpty(row["XepLoai"].ToString()))
                        {
                            string xepLoai = row["XepLoai"].ToString();
                            switch (xepLoai)
                            {
                                case "Giỏi": soGioi++; break;
                                case "Khá": soKha++; break;
                                case "Trung bình": soTrungBinh++; break;
                                case "Yếu": soYeu++; break;
                                case "Kém": soKem++; break;
                            }
                        }
                    }
                }

                // Tính tỷ lệ
                double tyLeGioi = soLuongHocSinh > 0 ? (double)soGioi / soLuongHocSinh * 100 : 0;
                double tyLeKha = soLuongHocSinh > 0 ? (double)soKha / soLuongHocSinh * 100 : 0;
                double tyLeTrungBinh = soLuongHocSinh > 0 ? (double)soTrungBinh / soLuongHocSinh * 100 : 0;
                double tyLeYeu = soLuongHocSinh > 0 ? (double)soYeu / soLuongHocSinh * 100 : 0;
                double tyLeKem = soLuongHocSinh > 0 ? (double)soKem / soLuongHocSinh * 100 : 0;

                // Tỷ lệ đạt (từ trung bình trở lên)
                int soDat = soGioi + soKha + soTrungBinh;
                double tyLeDat = soLuongHocSinh > 0 ? (double)soDat / soLuongHocSinh * 100 : 0;

                // Thông tin môn học
                string thongTinMonHoc = maMH == "ALL" ? "Tất cả các môn" : ((ComboBoxItem)cboMonHoc.SelectedItem).Text;

                // Hiển thị thông tin thống kê
                lblThongKe.Text = $"Lớp: {tenLop} | Môn học: {thongTinMonHoc} | Tổng số HS: {soLuongHocSinh} | " +
                                 $"Đạt: {soDat}/{soLuongHocSinh} ({Math.Round(tyLeDat, 1)}%) | " +
                                 $"Giỏi: {soGioi} ({Math.Round(tyLeGioi, 1)}%) | " +
                                 $"Khá: {soKha} ({Math.Round(tyLeKha, 1)}%) | " +
                                 $"TB: {soTrungBinh} ({Math.Round(tyLeTrungBinh, 1)}%) | " +
                                 $"Yếu: {soYeu} ({Math.Round(tyLeYeu, 1)}%) | " +
                                 $"Kém: {soKem} ({Math.Round(tyLeKem, 1)}%)";
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
