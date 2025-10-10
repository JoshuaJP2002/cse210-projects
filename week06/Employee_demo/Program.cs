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

            List<Employee> employees = new List<Employee>();
            employees.Add(hEmployee);
            employees.Add(sEmployee);

            foreach (employee emp in employees)
            {
                float pay = emp.GetPay();
            }
        }

        public static void DisplayEmployeeInformation(employee employee)
        {
            float pay = employee.GetPay();
            Console.WriteLine($"{employee.Getname()} will be paid ${pay}");
        
        }

    }
}