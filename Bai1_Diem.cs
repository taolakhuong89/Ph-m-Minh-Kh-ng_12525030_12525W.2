using System;
using System.Text;

namespace BTTH1
{
    class Diem
    {
        private double x;   // Hoành độ
        private double y;   // Tung độ

        public Diem() { x = 0; y = 0; }
        public Diem(double x, double y) { this.x = x; this.y = y; }

        public void Nhap()
        {
            x = DocSo("  Nhập hoành độ x: ");
            y = DocSo("  Nhập tung độ y: ");
        }

        private static double DocSo(string nhan)
        {
            double v;
            Console.Write(nhan);
            while (!double.TryParse(Console.ReadLine(), out v))
                Console.Write("  Nhập lại: ");
            return v;
        }

        public void HienThi() { Console.Write("({0}, {1})", x, y); }

        public double KhoangCach(Diem d)
        {
            double dx = x - d.x, dy = y - d.y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Diem o = new Diem();
            Console.Write("Điểm gốc: "); o.HienThi(); Console.WriteLine();

            Diem p = new Diem(3, 4);
            Console.Write("Điểm P: "); p.HienThi(); Console.WriteLine();

            Diem q = new Diem();
            Console.WriteLine("Nhập điểm Q:");
            q.Nhap();
            Console.Write("Điểm Q: "); q.HienThi(); Console.WriteLine();

            Console.WriteLine("Khoảng cách P - Q = {0:0.####}", p.KhoangCach(q));
            Console.ReadKey();
        }
    }
}
