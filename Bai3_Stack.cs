using System;
using System.Text;

namespace BTTH1
{
    class Stack
    {
        private int top;
        private int[] s;

        public Stack() : this(20) { }
        public Stack(int n)
        {
            if (n <= 0) throw new ArgumentException("Kích thước stack phải > 0");
            s = new int[n];
            top = -1;
        }

        public bool IsEmpty() { return top == -1; }
        public bool IsFull() { return top == s.Length - 1; }

        public void Push(int x)
        {
            if (IsFull()) throw new InvalidOperationException("Stack đầy!");
            s[++top] = x;
        }

        public int Pop()
        {
            if (IsEmpty()) throw new InvalidOperationException("Stack rỗng!");
            return s[top--];
        }
    }

    class Program
    {
        static int DocInt(string nhan)
        {
            int v;
            Console.Write(nhan);
            while (!int.TryParse(Console.ReadLine(), out v))
                Console.Write("  Nhập lại: ");
            return v;
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            int n = DocInt("Nhập số phần tử tối đa của stack (0 = mặc định 20): ");
            Stack st = n > 0 ? new Stack(n) : new Stack();

            int chon;
            do
            {
                Console.WriteLine("\n1. Push  2. Pop  3. Kiểm tra rỗng  4. Kiểm tra đầy  0. Thoát");
                chon = DocInt("Chọn: ");
                try
                {
                    switch (chon)
                    {
                        case 1:
                            int x = DocInt("Giá trị: ");
                            st.Push(x);
                            Console.WriteLine("Đã thêm {0}", x);
                            break;
                        case 2:
                            Console.WriteLine("Lấy ra: {0}", st.Pop());
                            break;
                        case 3:
                            Console.WriteLine(st.IsEmpty() ? "Stack rỗng" : "Stack không rỗng");
                            break;
                        case 4:
                            Console.WriteLine(st.IsFull() ? "Stack đầy" : "Stack chưa đầy");
                            break;
                    }
                }
                catch (Exception e) { Console.WriteLine("Lỗi: " + e.Message); }
            } while (chon != 0);
        }
    }
}
