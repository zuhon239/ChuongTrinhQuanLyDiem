using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiem.Model
{
    public class GiaoVien : Nguoi
    {
        public string MaGV { get; set; }
        public MonHoc MonHoc { get; set; }

        public GiaoVien(string maGV, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, MonHoc monHoc)
            : base(hoTen, ngaySinh, gioiTinh, diaChi)
        {
            MaGV = maGV;
            MonHoc = monHoc;
        }
        public override string GetInfo()
        {
            return $"Họ và Tên: {HoTen}, MSSV: {MaGV}";
        }
    }
}
