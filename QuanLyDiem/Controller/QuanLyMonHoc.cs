using QuanLyDiem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiem.Controller
{
    public class QuanLyMonHoc
    {
        private List<MonHoc> danhSachMonHoc;

        public QuanLyMonHoc()
        {
            danhSachMonHoc = new List<MonHoc>();
        }

        public void ThemMonHoc(MonHoc monHoc)
        {
            danhSachMonHoc.Add(monHoc);
        }

        public MonHoc TimMonHocTheoMa(string maMH)
        {
            for (int i = 0; i < danhSachMonHoc.Count; i++)
            {
                if (danhSachMonHoc[i].MaMH == maMH)
                {
                    return danhSachMonHoc[i];
                }
            }
            return null;
        }
        public List<MonHoc> LayDanhSachMonHoc()
        {
            return danhSachMonHoc;
        }
    }
}
