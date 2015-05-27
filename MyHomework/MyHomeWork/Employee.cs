using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    class Employee : Person
    {
        public int Employee_Id { get; set; }
        public string DateOfEmployment{ get; set; }
        public int Salary { get; set; }
        public int AvailableDaysOff { get; set; }


        public Employee(int Id,string dateOfEmployment,int salary,int availableDaysOff,string dateOfBirth,string lastName,string firstName)
        {
            Employee_Id = Id;
            DateOfEmployment = dateOfEmployment;
            Salary = salary;
            AvailableDaysOff = availableDaysOff;
            DateOfBirth = dateOfBirth;
            LastName = lastName;
            FirstName = firstName;
        }

        public static void DisplayInfo(Employee employee)
        {
            Console.WriteLine("Employee's name is : {0}{1}. Salary : {2}. Number of leave day's : {3}", employee.FirstName, employee.LastName, employee.Salary, employee.AvailableDaysOff);
        }

        private static void SubstractDays(Employee employee, int days)
        {
            employee.AvailableDaysOff -= days;
            Console.WriteLine("Remaining available off days :{0}", employee.AvailableDaysOff);
        }

        public static void AddNewLeave()
        {
            Console.WriteLine("Please specify the starting date of the leave, the duration, leave type and employee:");
            string s = Console.ReadLine();
            string[] values = s.Split(' ');
            string startingDate = values[0];
            int duration = int.Parse(values[1]);
            string leaveType = values[2];
            int employeeId = int.Parse(values[3]);

            Program List = new Program();
            var employeeList = List.GetList();
            var employee = employeeList.Where(x => x.Employee_Id == employeeId).SingleOrDefault();

            DisplayInfo(employee);
            Leave newLeave = new Leave(startingDate, duration, leaveType, employee);
            Console.WriteLine("New Leave added with : Starting Date {0} , Duration {1} , Leave Type {2} for employee {3} {4}", startingDate, duration, leaveType, employee.FirstName, employee.LastName);
            SubstractDays(employee, duration);
        }
    }
}
