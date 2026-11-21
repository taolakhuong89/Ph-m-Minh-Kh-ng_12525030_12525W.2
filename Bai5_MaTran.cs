using System;
using System.Text;

namespace BTTH1
{
    class MaTran
    {
        private int sh, sc;
        private double[,] a;

        public MaTran(int sh, int sc)
        {
            if (sh <= 0 || sc <= 0) throw new ArgumentException("Số hàng và số cột phải > 0");
            this.sh = sh; this.sc = sc;
            a = new double[sh, sc];
        }

        public void Nhap()
        {
            for (int i = 0; i < sh; i++)
                for (int j = 0; j < sc; j++)
                {
                    Console.Write("  a[{0},{1}] = ", i, j);
                    double v;
                    while (!double.TryParse(Console.ReadLine(), out v))
                        Console.Write("  Nhập lại: ");
                    a[i, j] = v;
                }
        }

        public void Print()
        {
            for (int i = 0; i < sh; i++)
            {
                for (int j = 0; j < sc; j++) Console.Write("{0,8:0.##}", a[i, j]);
                Console.WriteLine();
            }
        }

        public bool TuongThich(MaTran m) { return sh == m.sh && sc == m.sc; }      // cùng cấp: cộng/trừ
        public bool TuongThichNhan(MaTran m) { return sc == m.sh; }                // nhân: cột A = hàng B
        public bool MaTranVuong() { return sh == sc; }

        public MaTran Cong(MaTran m)
        {
            if (!TuongThich(m)) throw new InvalidOperationException("Hai ma trận không cùng cấp!");
            MaTran k = new MaTran(sh, sc);
            for (int i = 0; i < sh; i++)
                for (int j = 0; j < sc; j++) k.a[i, j] = a[i, j] + m.a[i, j];
            return k;
        }

        public MaTran Hieu(MaTran m)
        {
            if (!TuongThich(m)) throw new InvalidOperationException("Hai ma trận không cùng cấp!");
            MaTran k = new MaTran(sh, sc);
            for (int i = 0; i < sh; i++)
                for (int j = 0; j < sc; j++) k.a[i, j] = a[i, j] - m.a[i, j];
            return k;
        }

        public void DoiDau()
        {
            for (int i = 0; i < sh; i++)
                for (int j = 0; j < sc; j++) a[i, j] = -a[i, j];
        }

        public MaTran ChuyenVi()
        {
            MaTran k = new MaTran(sc, sh);
            for (int i = 0; i < sh; i++)
                for (int j = 0; j < sc; j++) k.a[j, i] = a[i, j];
            return k;
        }

        public MaTran Tich(MaTran m)
        {
            if (!TuongThichNhan(m)) throw new InvalidOperationException("Số cột A phải bằng số hàng B!");
            MaTran k = new MaTran(sh, m.sc);
            for (int i = 0; i < sh; i++)
                for (int j = 0; j < m.sc; j++)
                {
                    double t = 0;
                    for (int l = 0; l < sc; l++) t += a[i, l] * m.a[l, j];
                    k.a[i, j] = t;
                }
            return k;
        }
    }

    class Program
    {
        static int DocInt(string nhan)
        {
            int v;
            Console.Write(nhan);
            while (!int.TryParse(Console.ReadLine(), out v) || v <= 0)
                Console.Write("  Nhập số nguyên > 0: ");
            return v;
        }

        static MaTran NhapMaTran(string ten)
        {
            int h = DocInt("Số hàng của " + ten + ": ");
            int c = DocInt("Số cột của " + ten + ": ");
            MaTran m = new MaTran(h, c);
            Console.WriteLine("Nhập " + ten + ":");
            m.Nhap();
            return m;
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            MaTran A = NhapMaTran("A");
            MaTran B = NhapMaTran("B");

            Console.WriteLine("\nMa trận A:"); A.Print();
            Console.WriteLine("Ma trận B:"); B.Print();
            Console.WriteLine("A là ma trận vuông? {0}", A.MaTranVuong() ? "Có" : "Không");
            Console.WriteLine("A, B cùng cấp (cộng/trừ được)? {0}", A.TuongThich(B) ? "Có" : "Không");

            try { Console.WriteLine("\nA + B:"); A.Cong(B).Print(); }
            catch (Exception e) { Console.WriteLine("Lỗi: " + e.Message); }
            try { Console.WriteLine("A - B:"); A.Hieu(B).Print(); }
            catch (Exception e) { Console.WriteLine("Lỗi: " + e.Message); }
            try { Console.WriteLine("A * B:"); A.Tich(B).Print(); }
            catch (Exception e) { Console.WriteLine("Lỗi: " + e.Message); }

            Console.WriteLine("Chuyển vị của A:"); A.ChuyenVi().Print();
            A.DoiDau();
            Console.WriteLine("A sau khi đổi dấu:"); A.Print();
            Console.ReadKey();
        }
    }
}
