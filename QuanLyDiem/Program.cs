using System;
using System.Windows.Forms;
using QuanLyDiem.Controller;

namespace QuanLyDiem
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Khởi tạo các controller
            HocSinhController hocSinhController = new HocSinhController();
            //GiaoVienController giaoVienController = new GiaoVienController();
            //LopHocController lopHocController = new LopHocController();
            //MonHocController monHocController = new MonHocController();
            //DiemSoController diemSoController = new DiemSoController();
            //QuanLyDiemController quanLyDiemController = new QuanLyDiemController();

            // Khởi tạo form chính và truyền các controller
            MainForm mainForm = new MainForm(hocSinhController);//, giaoVienController, lopHocController, monHocController, diemSoController, quanLyDiemController);
            Application.Run(mainForm);
        }
    }
}