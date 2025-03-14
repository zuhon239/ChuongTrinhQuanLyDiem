using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiem.Model
{
    public class MonHoc
    {
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public int SoTiet { get; set; }

        public MonHoc(string maMH, string tenMH, int soTiet)
        {
            MaMH = maMH;
            TenMH = tenMH;
            SoTiet = soTiet;
        }
    }
}
