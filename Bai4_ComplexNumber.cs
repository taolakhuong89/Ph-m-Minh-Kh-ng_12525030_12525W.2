using System;
using System.Text;

namespace BTTH1
{
    class ComplexNumber
    {
        private double thuc;   // phần thực
        private double ao;     // phần ảo

        public ComplexNumber(double thuc, double ao) { this.thuc = thuc; this.ao = ao; }

        public void HienThi()
        {
            if (ao >= 0) Console.Write("{0} + {1}i", thuc, ao);
            else Console.Write("{0} - {1}i", thuc, -ao);
        }

        public ComplexNumber Tong(ComplexNumber t2) { return new ComplexNumber(thuc + t2.thuc, ao + t2.ao); }
        public ComplexNumber Hieu(ComplexNumber t2) { return new ComplexNumber(thuc - t2.thuc, ao - t2.ao); }

        // (a+bi)(c+di) = (ac-bd) + (bc+ad)i
        public ComplexNumber Tich(ComplexNumber t2)
        {
            return new ComplexNumber(thuc * t2.thuc - ao * t2.ao, ao * t2.thuc + thuc * t2.ao);
        }
    }

    class Program
    {
        static double DocSo(string nhan)
        {
            double v;
            Console.Write(nhan);
            while (!double.TryParse(Console.ReadLine(), out v))
                Console.Write("  Nhập lại: ");
            return v;
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("Số phức thứ nhất:");
            double a = DocSo("  Phần thực: ");
            double b = DocSo("  Phần ảo: ");
            ComplexNumber z1 = new ComplexNumber(a, b);

            Console.WriteLine("Số phức thứ hai:");
            double c = DocSo("  Phần thực: ");
            double d = DocSo("  Phần ảo: ");
            ComplexNumber z2 = new ComplexNumber(c, d);

            Console.Write("z1 = "); z1.HienThi(); Console.WriteLine();
            Console.Write("z2 = "); z2.HienThi(); Console.WriteLine();
            Console.Write("z1 + z2 = "); z1.Tong(z2).HienThi(); Console.WriteLine();
            Console.Write("z1 - z2 = "); z1.Hieu(z2).HienThi(); Console.WriteLine();
            Console.Write("z1 * z2 = "); z1.Tich(z2).HienThi(); Console.WriteLine();
            Console.ReadKey();
        }
    }
}
