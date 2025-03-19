using QuanLyDiem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiem.Controller
{
    public class QuanLyGiaoVien
    {
        private List<GiaoVien> danhSachGiaoVien;

        public QuanLyGiaoVien()
        {
            danhSachGiaoVien = new List<GiaoVien>();
        }

        public void ThemGiaoVien(GiaoVien giaoVien)
        {
            danhSachGiaoVien.Add(giaoVien);
        }

        public GiaoVien TimGiaoVienTheoMa(string maGV)
        {
            for (int i = 0; i < danhSachGiaoVien.Count; i++)
            {
                if (danhSachGiaoVien[i].MaGV == maGV)
                {
                    return danhSachGiaoVien[i];
                }
            }
            return null;
        }

        public List<GiaoVien> LayDanhSachGiaoVien()
        {
            return danhSachGiaoVien;
        }
    }
}
