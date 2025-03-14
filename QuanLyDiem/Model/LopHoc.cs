using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiem.Model
{
    public class LopHoc
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public GiaoVien GiaoVienChuNhiem { get; set; }

        public LopHoc(string maLop, string tenLop, GiaoVien giaoVienChuNhiem)
        {
            MaLop = maLop;
            TenLop = tenLop;
            GiaoVienChuNhiem = giaoVienChuNhiem;
        }
    }
}
