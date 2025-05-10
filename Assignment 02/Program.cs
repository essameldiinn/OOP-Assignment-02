using System;
using System.Globalization;

namespace CompanyApp
{
    enum SecurityLevel
    {
        Guest,
        Developer,
        Secretary,
        DBA,
        SecurityOfficer 
    }

    #region Q1
    enum Gender
    {
        M,
        F
    } 
    #endregion

    #region Q2 
    class HiringDate : IComparable<HiringDate>
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public HiringDate(int day, int month, int year)
        {
            if (day < 1 || day > 31 || month < 1 || month > 12 || year < 1900)
                throw new ArgumentException("Invalid date");

            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Day:D2}/{Month:D2}/{Year}";
        }

        public int CompareTo(HiringDate other)
        {
            DateTime thisDate = new DateTime(Year, Month, Day);
            DateTime otherDate = new DateTime(other.Year, other.Month, other.Day);
            return thisDate.CompareTo(otherDate);
        }
    } 
    #endregion

    #region Q1 & Q3: Employee Class 
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public SecurityLevel SecurityLevel { get; set; }
        public decimal Salary { get; set; }
        public HiringDate HireDate { get; set; }
        public Gender Gender { get; set; }

        public Employee(int id, string name, SecurityLevel security, decimal salary, HiringDate hireDate, Gender gender)
        {
            ID = id;
            Name = name;
            SecurityLevel = security;
            Salary = salary;
            HireDate = hireDate;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Security: {SecurityLevel}, Gender: {Gender}, Salary: {string.Format(CultureInfo.InvariantCulture, "{0:C}", Salary)}, Hire Date: {HireDate}";
        }
    } 
    #endregion

    class Program
    {
        static void Main()
        {
            Console.WriteLine("========== Employee Management System ==========\n");

            #region Q3 
            Employee[] EmpArr = new Employee[3];

            EmpArr[0] = new Employee(1, "Ali", SecurityLevel.DBA, 10000m, new HiringDate(10, 2, 2018), Gender.M);
            EmpArr[1] = new Employee(2, "Sara", SecurityLevel.Guest, 5000m, new HiringDate(15, 6, 2021), Gender.F);
            EmpArr[2] = new Employee(3, "Omar", SecurityLevel.SecurityOfficer, 15000m, new HiringDate(1, 1, 2016), Gender.M);

            Console.WriteLine(">>> All Employees:");
            foreach (var emp in EmpArr)
                Console.WriteLine(emp); 
            #endregion

            #region Q4 
            Console.WriteLine("\n>>> Sorted by Hire Date:");
            Array.Sort(EmpArr, (emp1, emp2) => emp1.HireDate.CompareTo(emp2.HireDate));

            foreach (var emp in EmpArr)
                Console.WriteLine(emp);

            int boxingCount = 0;
            object box;
            foreach (var emp in EmpArr)
            {

                box = emp.HireDate.Day;
                int day = (int)box;
                boxingCount += 2;
            }

            Console.WriteLine($"\n>>> Estimated Boxing/Unboxing Operations: {boxingCount}"); 
            #endregion
        }
    }
}

