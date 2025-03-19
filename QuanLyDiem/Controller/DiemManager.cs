using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.Json;
using QuanLyDiem.Model;

namespace QuanLyDiem.Controller
{
    public class DiemManager
    {
        private List<DiemSo> danhSachDiemSo;

        public DiemManager()
        {
            danhSachDiemSo = new List<DiemSo>();
        }

        public void ThemDiemSo(DiemSo diemSo)
        {
            danhSachDiemSo.Add(diemSo);
        }

        public bool XoaDiemSo(string maHS, string maMH)
        {
            for (int i = 0; i < danhSachDiemSo.Count; i++)
            {
                if (danhSachDiemSo[i].HocSinh.MaHS == maHS && danhSachDiemSo[i].MonHoc.MaMH == maMH)
                {
                    danhSachDiemSo.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool CapNhatDiemSo(string maHS, string maMH, double diemMieng, double diem15Phut, double diem1Tiet, double diemHK)
        {
            for (int i = 0; i < danhSachDiemSo.Count; i++)
            {
                if (danhSachDiemSo[i].HocSinh.MaHS == maHS && danhSachDiemSo[i].MonHoc.MaMH == maMH)
                {
                    danhSachDiemSo[i].DiemMieng = diemMieng;
                    danhSachDiemSo[i].Diem15Phut = diem15Phut;
                    danhSachDiemSo[i].Diem1Tiet = diem1Tiet;
                    danhSachDiemSo[i].DiemHK = diemHK;
                    return true;
                }
            }
            return false;
        }

        public DiemSo TimDiemSo(string maHS, string maMH)
        {
            for (int i = 0; i < danhSachDiemSo.Count; i++)
            {
                if (danhSachDiemSo[i].HocSinh.MaHS == maHS && danhSachDiemSo[i].MonHoc.MaMH == maMH)
                {
                    return danhSachDiemSo[i];
                }
            }
            return null;
        }

        public List<DiemSo> LayDiemSoTheoHocSinh(string maHS)
        {
            List<DiemSo> ketQua = new List<DiemSo>();
            for (int i = 0; i < danhSachDiemSo.Count; i++)
            {
                if (danhSachDiemSo[i].HocSinh.MaHS == maHS)
                {
                    ketQua.Add(danhSachDiemSo[i]);
                }
            }
            return ketQua;
        }

        public List<DiemSo> LayDiemSoTheoMonHoc(string maMH)
        {
            List<DiemSo> ketQua = new List<DiemSo>();
            for (int i = 0; i < danhSachDiemSo.Count; i++)
            {
                if (danhSachDiemSo[i].MonHoc.MaMH == maMH)
                {
                    ketQua.Add(danhSachDiemSo[i]);
                }
            }
            return ketQua;
        }

        public double TinhDiemTBHocSinh(string maHS)
        {
            double tongDiem = 0;
            int soMon = 0;
            for (int i = 0; i < danhSachDiemSo.Count; i++)
            {
                if (danhSachDiemSo[i].HocSinh.MaHS == maHS)
                {
                    tongDiem += danhSachDiemSo[i].TinhDiemTB();
                    soMon++;
                }
            }
            return soMon > 0 ? tongDiem / soMon : 0;
        }

        public List<DiemSo> LayDanhSachDiemSo()
        {
            return danhSachDiemSo;
        }

        public bool LuuDanhSachDiemJson(string filePath)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(danhSachDiemSo, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, jsonString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DocDanhSachDiemJson(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    danhSachDiemSo = JsonSerializer.Deserialize<List<DiemSo>>(jsonString);
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