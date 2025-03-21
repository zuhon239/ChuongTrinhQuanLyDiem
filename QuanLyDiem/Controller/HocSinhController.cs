using QuanLyDiem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuanLyDiem.Controller
{
    public class HocSinhController
    {
        private List<HocSinh> danhSachHocSinh;
        private string filePath = "Data/HocSinh.json";

        public HocSinhController()
        {
            danhSachHocSinh = new List<HocSinh>();
        }

        public void Them(HocSinh hocSinh)
        {
            danhSachHocSinh.Add(hocSinh);
        }

        public HocSinh TimHocSinhTheoMa(string maHS)
        {
            for (int i = 0; i < danhSachHocSinh.Count; i++)
            {
                if (danhSachHocSinh[i].MaHS == maHS)
                {
                    return danhSachHocSinh[i];
                }
            }
            return null;
        }

        public List<HocSinh> LayDanhSachHocSinh()
        {
            return danhSachHocSinh;
        }

        public bool LuuDanhSachHocSinhJson(string filePath)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(danhSachHocSinh, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, jsonString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DocDanhSachHocSinhJson(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    danhSachHocSinh = JsonSerializer.Deserialize<List<HocSinh>>(jsonString);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
