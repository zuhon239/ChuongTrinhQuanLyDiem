using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiem.Model
{
    public interface IQuanLy<T>
    {
        void Them(T item);
        void Sua(T item);
        void Xoa(string ma);
        T TimKiem(string ma);
        List<T> LoadDanhSach();
        void SaveDanhSach(List<T> danhSach);
    }
}
