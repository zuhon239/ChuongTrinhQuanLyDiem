using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiem.Model
{
    public class HocSinh : Nguoi 
    {
        public string MaHS { get; set; }
        public LopHoc LopHoc { get; set; }

        public HocSinh(string maHS, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, LopHoc lopHoc)
            : base(hoTen, ngaySinh, gioiTinh, diaChi)
        {
            MaHS = maHS;
            LopHoc = lopHoc;
        }
        public override string GetInfo()
        {
            return $"Họ và Tên: {HoTen}, MSSV: {MaHS}";
        }
    }
}
