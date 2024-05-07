namespace Day07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instances of HiringDate
            HiringDate hiringDate1 = new HiringDate(11, 1, 2020);
            HiringDate hiringDate2 = new HiringDate(19, 5, 2021);
            HiringDate hiringDate3 = new HiringDate(25, 1, 2011);

            Employee[] EmpArr = new Employee[3];

            EmpArr[0] = new Employee(1, "DBA Employee", SecurityPrivilege.DBA, 15000, hiringDate1, 'F');
            EmpArr[1] = new Employee(2, "Guest Employee", SecurityPrivilege.Guest, 25000, hiringDate2, 'M');
            EmpArr[2] = new Employee(3, "Security Officer", SecurityPrivilege.Secretary, 20000, hiringDate3, 'F');

            Array.Sort(EmpArr, new empHireDate());

            foreach (Employee emp in EmpArr)
            {
                emp.empData();
                Console.WriteLine(); 
            }

            // Using ToString() method for sorted array
            foreach (Employee emp in EmpArr)
            {
                Console.WriteLine(emp.ToString());
                Console.WriteLine(); 
            }


        }
    }


    //Implement a Class for the employees in a company
    public class Employee
    {
        // Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public SecurityPrivilege SecurityLevel { get; set; }
        public decimal Salary { get; set; }
        public HiringDate HireDate { get; set; }
        private char gender;

        // Gender validation 
        public char Gender
        {
            get { return gender; }
            set
            {
                if (value == 'M' || value == 'F')
                {
                    gender = value;
                }
                else
                {
                    throw new ArgumentException("Gender must be 'M' or 'F'.");
                }
            }
        }

        // Employee constructor 
        public Employee(int id, string name, SecurityPrivilege securityLevel, decimal salary, HiringDate hireDate, char gender)
        {
            ID = id;
            Name = name;
            SecurityLevel = securityLevel;
            Salary = salary;
            HireDate = hireDate;
            Gender = gender;
        }

        // Method for print employee datta
        public void empData()
        {
            Console.WriteLine($"Employee ID: {ID} \n");
            Console.WriteLine($"Employee Name: {Name} \n");
            Console.WriteLine($"Security Level: {SecurityLevel}\n");
            Console.WriteLine($"Employee Salary: {String.Format("{0:C}", Salary)}\n");
            Console.WriteLine($"Hire Date of Employee: {HireDate.Day}/{HireDate.Month}/{HireDate.Year}\n");
            Console.WriteLine($"Employee Gender: {Gender}");
        }

        // Override method
        public override string ToString()
        {
            return $"Employee ID: {ID},Employee Name: {Name}, Security Level: {SecurityLevel}," +
                   $" Employee Salary: {String.Format("{0:C}", Salary)}, Hire Date of an Employee: {HireDate.Day}/{HireDate.Month}/{HireDate.Year},Employee Gender: {Gender}";
        }
    }
    // Class to represent the Hiring Date Data
    public class HiringDate
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        // Param constructor for HiringDate
        public HiringDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
    }

    // Enum to represent security privileges
    public enum SecurityPrivilege
    {
        Guest,
        Developer,
        Secretary,
        DBA
    }

    // Sort the employees based on their hire date
    public class empHireDate : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            // Compare by hire date
            DateTime hireDateX = new DateTime(x.HireDate.Year, x.HireDate.Month, x.HireDate.Day);
            DateTime hireDateY = new DateTime(y.HireDate.Year, y.HireDate.Month, y.HireDate.Day);

            return DateTime.Compare(hireDateX, hireDateY);
        }


    }
}