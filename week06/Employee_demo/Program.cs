using System;

namespace employee_demo
{
    class Program
    {
        static void main(string[] args)
        {
            HourlyEmployee hEmployee = new HourlyEmployee();
            hEmployee.SetName("John");
            hEmployee.SetIdNumber("123abc");
            hEmployee.SetPayRate(15);
            hEmployee.SetHoursWorked(35);

            SalaryEmployee sEmployee = new SalaryEmployee();
            sEmployee.SetName("Peter");
            sEmployee.SetIdNumber("456def");
            sEmployee.SetSalary(60000);


            DisplayEmployeeInformation(hEmployee);
            DisplayEmployeeInformation(sEmployee);
        }

        public static void DisplayEmployeeInformation(employee employee)
        {
            Console.WriteLine($"{employee.Getname()}");
        }

    }
}