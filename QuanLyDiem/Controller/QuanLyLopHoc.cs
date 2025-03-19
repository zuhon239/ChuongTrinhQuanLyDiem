using QuanLyDiem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiem.Controller
{
    public class QuanLyLopHoc
    {
        private List<LopHoc> danhSachLopHoc;

        public QuanLyLopHoc()
        {
            danhSachLopHoc = new List<LopHoc>();
        }

        public void ThemLopHoc(LopHoc lopHoc)
        {
            danhSachLopHoc.Add(lopHoc);
        }

        public LopHoc TimLopHocTheoMa(string maLop)
        {
            for (int i = 0; i < danhSachLopHoc.Count; i++)
            {
                if (danhSachLopHoc[i].MaLop == maLop)
                {
                    return danhSachLopHoc[i];
                }
            }
            return null;
        }

        public List<LopHoc> LayDanhSachLopHoc()
        {
            return danhSachLopHoc;
        }
    }
}
