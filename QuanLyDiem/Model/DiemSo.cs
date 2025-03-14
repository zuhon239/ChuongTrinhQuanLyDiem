using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiem.Model
{
    public class DiemSo
    {
        public HocSinh HocSinh { get; set; }
        public MonHoc MonHoc { get; set; }
        public double DiemMieng { get; set; }
        public double Diem15Phut { get; set; }
        public double Diem1Tiet { get; set; }
        public double DiemHK { get; set; }

        public DiemSo(HocSinh hocSinh, MonHoc monHoc, double diemMieng, double diem15Phut, double diem1Tiet, double diemHK)
        {
            HocSinh = hocSinh;
            MonHoc = monHoc;
            DiemMieng = diemMieng;
            Diem15Phut = diem15Phut;
            Diem1Tiet = diem1Tiet;
            DiemHK = diemHK;
        }

        public double TinhDiemTB()
        {
            return (DiemMieng + Diem15Phut + Diem1Tiet * 2 + DiemHK * 3) / 7;
        }
    }
}
