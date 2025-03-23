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
    public delegate void ThongBaoCapNhatHandler(string tieuDe, string noiDung, MessageBoxIcon icon);

    public partial class FormQuanLyDiem : Form
    {
        private DiemManager quanLyDiem;
        private QuanLyGiaoVien quanLyGiaoVien;
        private HocSinhController hocSinhController;
        private QuanLyLopHoc quanLyLopHoc;
        private QuanLyMonHoc quanLyMonHoc;
        private GiaoVien giaoVienHienTai;
        private string dataFolder = "Data";

        public event ThongBaoCapNhatHandler ThongBaoCapNhat;

        public FormQuanLyDiem()
        {
            InitializeComponent();
            KhoiTaoQuanLy();
            LoadDuLieuTuFile();
            SetupControls();
            ThongBaoCapNhat += HienThiThongBao;
        }
        private void HienThiThongBao(string tieuDe, string noiDung, MessageBoxIcon icon)
        {
            MessageBox.Show(noiDung, tieuDe, MessageBoxButtons.OK, icon);
        }
        private void PhatSinhThongBao(string tieuDe, string noiDung, MessageBoxIcon icon)
        {
            ThongBaoCapNhat?.Invoke(tieuDe, noiDung, icon);
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
            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }
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
                PhatSinhThongBao("Lỗi", $"Lỗi khi đọc file giáo viên: {ex.Message}", MessageBoxIcon.Error);
            }
        }
        private void DocDuLieuHocSinh()
        {
            string filePath = Path.Combine(dataFolder, "HocSinh.json");
            try
            {
                hocSinhController.DocDanhSachHocSinhJson(filePath);
            }
            catch (Exception ex)
            {
                PhatSinhThongBao("Lỗi", $"Lỗi khi đọc file học sinh: {ex.Message}", MessageBoxIcon.Error);
            }
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
                PhatSinhThongBao("Lỗi", $"Lỗi khi đọc file lớp học: {ex.Message}", MessageBoxIcon.Error);
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
                PhatSinhThongBao("Lỗi", $"Lỗi khi đọc file môn học: {ex.Message}", MessageBoxIcon.Error);
            }
        }

        private void DocDuLieuDiemSo()
        {
            string filePath = Path.Combine(dataFolder, "DiemSo.json");
            try
            {
                quanLyDiem.DocDanhSachDiemJson(filePath);
            }
            catch (Exception ex)
            {
                PhatSinhThongBao("Lỗi", $"Lỗi khi đọc file điểm số: {ex.Message}", MessageBoxIcon.Error);
            }
        }

        private void SetupControls()
        {
            // Thiết lập các control trên form
            LoadDanhSachGiaoVien();

            // Đăng ký sự kiện
            cboGiaoVien.SelectedIndexChanged += CboGiaoVien_SelectedIndexChanged;
            cboLopHoc.SelectedIndexChanged += CboLopHoc_SelectedIndexChanged;
            btnLuu.Click += BtnLuu_Click;
            btnXuatFile.Click += BtnXuatFile_Click;
            btnXoaDiem.Click += BtnXoaDiem_Click;
        }

        private void LoadDanhSachGiaoVien()
        {
            cboGiaoVien.Items.Clear();
            List<GiaoVien> danhSachGiaoVien = quanLyGiaoVien.LayDanhSachGiaoVien();
            foreach (var giaoVien in danhSachGiaoVien)
            {
                cboGiaoVien.Items.Add(new ComboBoxItem { Value = giaoVien.MaGV, Text = $"{giaoVien.HoTen} - {giaoVien.MonHoc?.TenMH ?? "Chưa phân môn"}" });
            }
        }

        private void CboGiaoVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGiaoVien.SelectedItem != null)
            {
                string maGV = ((ComboBoxItem)cboGiaoVien.SelectedItem).Value;
                giaoVienHienTai = quanLyGiaoVien.TimGiaoVienTheoMa(maGV);

                if (giaoVienHienTai != null && giaoVienHienTai.MonHoc != null)
                {
                    lblMonHoc.Text = $"Môn học: {giaoVienHienTai.MonHoc.TenMH}";
                    LoadDanhSachLopDay();
                }
                else
                {
                    lblMonHoc.Text = "Môn học: Chưa được phân công";
                    cboLopHoc.Items.Clear();
                    dgvDanhSachHocSinh.DataSource = null;

                    // Phát sinh thông báo cảnh báo
                    PhatSinhThongBao("Cảnh báo", "Giáo viên chưa được phân công môn học", MessageBoxIcon.Warning);
                }
            }
        }

        private void LoadDanhSachLopDay()
        {
            cboLopHoc.Items.Clear();
            List<LopHoc> danhSachLopHoc = quanLyLopHoc.LayDanhSachLopHoc();
            foreach (var lopHoc in danhSachLopHoc)
            {
                cboLopHoc.Items.Add(new ComboBoxItem { Value = lopHoc.MaLop, Text = lopHoc.TenLop });
            }
        }

        private void CboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLopHoc.SelectedItem != null && giaoVienHienTai != null && giaoVienHienTai.MonHoc != null)
            {
                string maLop = ((ComboBoxItem)cboLopHoc.SelectedItem).Value;
                string tenLop = ((ComboBoxItem)cboLopHoc.SelectedItem).Text;
                LoadDanhSachHocSinhTheoLop(maLop);
            }
        }

        private void LoadDanhSachHocSinhTheoLop(string maLop)
        {
            if (giaoVienHienTai == null || giaoVienHienTai.MonHoc == null) return;

            List<HocSinh> danhSachHocSinh = new List<HocSinh>();
            List<HocSinh> tatCaHocSinh = hocSinhController.LayDanhSachHocSinh();
            for (int i = 0; i < tatCaHocSinh.Count; i++)
            {
                HocSinh hs = tatCaHocSinh[i];
                if (hs.LopHoc != null && hs.LopHoc.MaLop == maLop)
                {
                    danhSachHocSinh.Add(hs);
                }
            }

            // Tạo DataTable để hiển thị lên DataGridView
            DataTable dt = new DataTable();
            dt.Columns.Add("MaHS", typeof(string));
            dt.Columns.Add("HoTen", typeof(string));
            dt.Columns.Add("DiemMieng", typeof(object));   // Thay đổi kiểu dữ liệu từ double sang object
            dt.Columns.Add("Diem15Phut", typeof(object));  // để có thể chứa DBNull.Value
            dt.Columns.Add("Diem1Tiet", typeof(object));
            dt.Columns.Add("DiemHK", typeof(object));
            dt.Columns.Add("DiemTB", typeof(object));

            foreach (var hocSinh in danhSachHocSinh)
            {
                DiemSo diemSo = quanLyDiem.TimDiemSo(hocSinh.MaHS, giaoVienHienTai.MonHoc.MaMH);

                if (diemSo != null)
                {
                    // Nếu có điểm
                    double diemTB = diemSo.TinhDiemTB();
                    object diemTBValue = diemTB > 0 ? Math.Round(diemTB, 1) : DBNull.Value;

                    dt.Rows.Add(
                        hocSinh.MaHS,
                        hocSinh.HoTen,
                        diemSo.DiemMieng > 0 ? diemSo.DiemMieng : DBNull.Value,
                        diemSo.Diem15Phut > 0 ? diemSo.Diem15Phut : DBNull.Value,
                        diemSo.Diem1Tiet > 0 ? diemSo.Diem1Tiet : DBNull.Value,
                        diemSo.DiemHK > 0 ? diemSo.DiemHK : DBNull.Value,
                        diemTBValue
                    );
                }
                else
                {
                    // Nếu chưa có điểm
                    dt.Rows.Add(
                        hocSinh.MaHS,
                        hocSinh.HoTen,
                        DBNull.Value,
                        DBNull.Value,
                        DBNull.Value,
                        DBNull.Value,
                        DBNull.Value
                    );
                }
            }

            dgvDanhSachHocSinh.DataSource = dt;
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            dgvDanhSachHocSinh.Columns["MaHS"].HeaderText = "Mã HS";
            dgvDanhSachHocSinh.Columns["MaHS"].ReadOnly = true;
            dgvDanhSachHocSinh.Columns["HoTen"].HeaderText = "Họ và Tên";
            dgvDanhSachHocSinh.Columns["HoTen"].ReadOnly = true;
            dgvDanhSachHocSinh.Columns["DiemMieng"].HeaderText = "Điểm Miệng";
            dgvDanhSachHocSinh.Columns["Diem15Phut"].HeaderText = "Điểm 15 Phút";
            dgvDanhSachHocSinh.Columns["Diem1Tiet"].HeaderText = "Điểm 1 Tiết";
            dgvDanhSachHocSinh.Columns["DiemHK"].HeaderText = "Điểm HK";
            dgvDanhSachHocSinh.Columns["DiemTB"].HeaderText = "Điểm TB";
            dgvDanhSachHocSinh.Columns["DiemTB"].ReadOnly = true;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHocSinh.DataSource == null || cboLopHoc.SelectedItem == null ||
                giaoVienHienTai == null || giaoVienHienTai.MonHoc == null)
            {
                PhatSinhThongBao("Thông báo", "Vui lòng chọn giáo viên và lớp học trước khi lưu điểm!", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = (DataTable)dgvDanhSachHocSinh.DataSource;
                int soHocSinhCapNhat = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string maHS = row["MaHS"].ToString();
                    HocSinh hocSinh = hocSinhController.TimHocSinhTheoMa(maHS);

                    if (hocSinh != null)
                    {
                        // Kiểm tra nếu tất cả các điểm đều DBNull (đã xóa điểm)
                        bool allScoresDeleted = row["DiemMieng"] == DBNull.Value &&
                                               row["Diem15Phut"] == DBNull.Value &&
                                               row["Diem1Tiet"] == DBNull.Value &&
                                               row["DiemHK"] == DBNull.Value;

                        if (allScoresDeleted)
                        {
                            // Xóa hoàn toàn bản ghi điểm nếu tất cả điểm đã bị xóa
                            quanLyDiem.XoaDiemSo(maHS, giaoVienHienTai.MonHoc.MaMH);
                        }
                        else
                        {
                            // Kiểm tra và xử lý các ô trống
                            double diemMieng = row["DiemMieng"] == DBNull.Value ? -1 : Convert.ToDouble(row["DiemMieng"]);
                            double diem15Phut = row["Diem15Phut"] == DBNull.Value ? -1 : Convert.ToDouble(row["Diem15Phut"]);
                            double diem1Tiet = row["Diem1Tiet"] == DBNull.Value ? -1 : Convert.ToDouble(row["Diem1Tiet"]);
                            double diemHK = row["DiemHK"] == DBNull.Value ? -1 : Convert.ToDouble(row["DiemHK"]);

                            // Kiểm tra điểm hợp lệ (nếu có giá trị thì phải từ 0-10)
                            if ((row["DiemMieng"] != DBNull.Value && (diemMieng < 0 || diemMieng > 10)) ||
                                (row["Diem15Phut"] != DBNull.Value && (diem15Phut < 0 || diem15Phut > 10)) ||
                                (row["Diem1Tiet"] != DBNull.Value && (diem1Tiet < 0 || diem1Tiet > 10)) ||
                                (row["DiemHK"] != DBNull.Value && (diemHK < 0 || diemHK > 10)))
                            {
                                PhatSinhThongBao("Lỗi", $"Điểm của học sinh {row["HoTen"]} không hợp lệ. Điểm phải từ 0-10!", MessageBoxIcon.Error);
                                return;
                            }

                            DiemSo diemSo = quanLyDiem.TimDiemSo(maHS, giaoVienHienTai.MonHoc.MaMH);
                            if (diemSo != null)
                            {
                                // Cập nhật điểm số nếu đã tồn tại
                                quanLyDiem.CapNhatDiemSo(maHS, giaoVienHienTai.MonHoc.MaMH, diemMieng, diem15Phut, diem1Tiet, diemHK);
                            }
                            else
                            {
                                // Thêm mới điểm số nếu chưa tồn tại
                                DiemSo diemSoMoi = new DiemSo(hocSinh, giaoVienHienTai.MonHoc, diemMieng, diem15Phut, diem1Tiet, diemHK);
                                quanLyDiem.ThemDiemSo(diemSoMoi);
                            }
                            soHocSinhCapNhat++;
                        }
                    }
                }

                // Lưu dữ liệu
                string filePath = Path.Combine(dataFolder, "DiemSo.json");
                if (quanLyDiem.LuuDanhSachDiemJson(filePath))
                {
                    PhatSinhThongBao("Thông báo", $"Đã lưu điểm thành công cho {soHocSinhCapNhat} học sinh!", MessageBoxIcon.Information);
                    RefreshDiemTrungBinh();
                }
                else
                {
                    PhatSinhThongBao("Lỗi", "Lưu điểm không thành công!", MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                PhatSinhThongBao("Lỗi", $"Đã xảy ra lỗi: {ex.Message}", MessageBoxIcon.Error);
            }
        }

        private void RefreshDiemTrungBinh()
        {
            if (dgvDanhSachHocSinh.DataSource is DataTable dt)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string maHS = row["MaHS"].ToString();
                    DiemSo diemSo = quanLyDiem.TimDiemSo(maHS, giaoVienHienTai.MonHoc.MaMH);
                    if (diemSo != null)
                    {
                        double diemTB = diemSo.TinhDiemTB();
                        row["DiemTB"] = diemTB > 0 ? Math.Round(diemTB, 1) : DBNull.Value;
                    }
                }
                dgvDanhSachHocSinh.Refresh();
            }
        }

        private void BtnXoaDiem_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHocSinh.DataSource == null || cboLopHoc.SelectedItem == null ||
                giaoVienHienTai == null || giaoVienHienTai.MonHoc == null)
            {
                PhatSinhThongBao("Thông báo", "Vui lòng chọn giáo viên và lớp học trước khi xóa điểm!", MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem có hàng nào được chọn không
            if (dgvDanhSachHocSinh.SelectedRows.Count == 0 && dgvDanhSachHocSinh.SelectedCells.Count == 0)
            {
                PhatSinhThongBao("Thông báo", "Vui lòng chọn học sinh cần xóa điểm!", MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã học sinh từ hàng được chọn
            string maHS = "";
            string tenHS = "";
            if (dgvDanhSachHocSinh.SelectedRows.Count > 0)
            {
                maHS = dgvDanhSachHocSinh.SelectedRows[0].Cells["MaHS"].Value.ToString();
                tenHS = dgvDanhSachHocSinh.SelectedRows[0].Cells["HoTen"].Value.ToString();
            }
            else if (dgvDanhSachHocSinh.SelectedCells.Count > 0)
            {
                int rowIndex = dgvDanhSachHocSinh.SelectedCells[0].RowIndex;
                maHS = dgvDanhSachHocSinh.Rows[rowIndex].Cells["MaHS"].Value.ToString();
                tenHS = dgvDanhSachHocSinh.Rows[rowIndex].Cells["HoTen"].Value.ToString();
            }

            // Xác nhận từ người dùng
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa điểm của học sinh {tenHS} cho môn {giaoVienHienTai.MonHoc.TenMH}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (quanLyDiem.XoaDiemSo(maHS, giaoVienHienTai.MonHoc.MaMH))
                {
                    // Lưu dữ liệu vào file
                    string filePath = Path.Combine(dataFolder, "DiemSo.json");
                    if (quanLyDiem.LuuDanhSachDiemJson(filePath))
                    {
                        PhatSinhThongBao("Thông báo", $"Đã xóa điểm của học sinh {tenHS} thành công!", MessageBoxIcon.Information);

                        // Cập nhật lại DataGridView
                        string maLop = ((ComboBoxItem)cboLopHoc.SelectedItem).Value;
                        LoadDanhSachHocSinhTheoLop(maLop);
                    }
                    else
                    {
                        PhatSinhThongBao("Cảnh báo", "Xóa điểm thành công nhưng lưu file không thành công!", MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    PhatSinhThongBao("Thông báo", "Không tìm thấy điểm để xóa!", MessageBoxIcon.Information);
                }
            }
        }

        private void BtnXuatFile_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHocSinh.DataSource == null || cboLopHoc.SelectedItem == null || giaoVienHienTai == null)
            {
                PhatSinhThongBao("Thông báo", "Vui lòng chọn giáo viên và lớp học trước khi xuất file!", MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xuất file điểm môn {giaoVienHienTai.MonHoc.TenMH} của lớp này không ?",
              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string maLop = ((ComboBoxItem)cboLopHoc.SelectedItem).Value;
                    LopHoc lopHoc = quanLyLopHoc.TimLopHocTheoMa(maLop);

                    if (lopHoc != null && giaoVienHienTai.MonHoc != null)
                    {
                        // Lấy danh sách học sinh có điểm số của môn học hiện tại trong lớp hiện tại
                        List<HocSinh> danhSachHocSinh = new List<HocSinh>();
                        List<HocSinh> tatCaHocSinh = hocSinhController.LayDanhSachHocSinh();
                        for (int i = 0; i < tatCaHocSinh.Count; i++)
                        {
                            HocSinh hs = tatCaHocSinh[i];
                            if (hs.LopHoc != null && hs.LopHoc.MaLop == maLop)
                            {
                                danhSachHocSinh.Add(hs);
                            }
                        }

                        // Tạo danh sách điểm số để xuất
                        var danhSachDiem = new List<object>();
                        foreach (var hocSinh in danhSachHocSinh)
                        {
                            DiemSo diemSo = quanLyDiem.TimDiemSo(hocSinh.MaHS, giaoVienHienTai.MonHoc.MaMH);
                            if (diemSo != null)
                            {
                                danhSachDiem.Add(new
                                {
                                    MaHS = hocSinh.MaHS,
                                    HoTen = hocSinh.HoTen,
                                    DiemMieng = diemSo.DiemMieng,
                                    Diem15Phut = diemSo.Diem15Phut,
                                    Diem1Tiet = diemSo.Diem1Tiet,
                                    DiemHK = diemSo.DiemHK,
                                    DiemTB = Math.Round(diemSo.TinhDiemTB(), 1)
                                });
                            }
                        }

                        // Tạo đối tượng bảng điểm để xuất
                        var bangDiem = new
                        {
                            TenLop = lopHoc.TenLop,
                            MonHoc = giaoVienHienTai.MonHoc.TenMH,
                            GiaoVien = giaoVienHienTai.HoTen,
                            NgayXuat = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                            DanhSachDiem = danhSachDiem
                        };

                        // Xuất file JSON
                        string fileName = $"BangDiem_{lopHoc.TenLop}_{giaoVienHienTai.MonHoc.TenMH}_{DateTime.Now:yyyyMMdd_HHmmss}.json";
                        string exportPath = Path.Combine(dataFolder, "Exports");

                        if (!Directory.Exists(exportPath))
                        {
                            Directory.CreateDirectory(exportPath);
                        }

                        string filePath = Path.Combine(exportPath, fileName);
                        string jsonString = JsonSerializer.Serialize(bangDiem, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(filePath, jsonString);

                        MessageBox.Show($"Đã xuất file thành công!\nĐường dẫn: {filePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    // Class hỗ trợ cho ComboBox
    public class ComboBoxItem
    {
        public string Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}

