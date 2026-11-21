using System;
using System.Text;

namespace BTTH1
{
    class Employee
    {
        private static int dem = 0;            // bộ đếm sinh id tự động
        private static double basicSalary = 1; // lương cơ bản dùng chung

        private int id;
        private string name;
        private readonly int yearOfBirth;      // không đổi sau khi tạo
        private double salaryLevel;

        public Employee(string name, int yearOfBirth, double salaryLevel)
        {
            this.id = ++dem;
            this.name = name;
            this.yearOfBirth = yearOfBirth;
            this.salaryLevel = salaryLevel;
        }

        public int GetId() { return id; }
        public string GetName() { return name; }
        public int GetYearOfBirth() { return yearOfBirth; }
        public double GetIncome() { return salaryLevel * basicSalary; }

        public void SetSalaryLevel(double level) { salaryLevel = level; }
        public static void SetBasicSalary(double salary) { basicSalary = salary; }

        public void Display()
        {
            Console.WriteLine("ID: {0} | Họ tên: {1} | Năm sinh: {2} | Lương cơ bản: {3} | Thu nhập: {4}",
                id, name, yearOfBirth, basicSalary, GetIncome());
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Employee.SetBasicSalary(1500000);
            Employee e1 = new Employee("Nguyen Van A", 1995, 2.34);
            Employee e2 = new Employee("Tran Thi B", 1998, 3.0);
            e1.Display();
            e2.Display();

            Console.WriteLine("\nSau khi đặt bậc lương e1 = 4.0 và lương cơ bản = 1800000:");
            e1.SetSalaryLevel(4.0);
            Employee.SetBasicSalary(1800000);
            e1.Display();
            e2.Display();
            Console.ReadKey();
        }
    }
}
