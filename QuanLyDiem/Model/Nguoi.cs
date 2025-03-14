using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuanLyDiem.Model
{
    public abstract class Nguoi
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }

        public Nguoi(string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
        }
        public abstract string GetInfo();
    }
}
