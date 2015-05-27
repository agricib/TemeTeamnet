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
        public DateTime DateOfEmployment{ get; set; }
        public int Salary { get; set; }
        public int AvailableDaysOff { get; set; }
        public List<Leave> LeaveList { get; set; }

        public Employee(int Id, DateTime dateOfEmployment, int salary, int availableDaysOff, DateTime dateOfBirth, string lastName, string firstName)
        {
            Employee_Id = Id;
            DateOfEmployment = dateOfEmployment;
            Salary = salary;
            AvailableDaysOff = availableDaysOff;
            DateOfBirth = dateOfBirth;
            LastName = lastName;
            FirstName = firstName;
        }

        public void AddLeave(Employee employee,Leave leave)
        {
            LeaveList.Add(leave);
            SubstractDays(employee, leave.Duration);
        }

        private void SubstractDays(Employee employee, int days)
        {
            employee.AvailableDaysOff -= days;
            Console.WriteLine("Remaining available off days :{0}", employee.AvailableDaysOff);
        }

        public void DisplayInfo(Employee employee)
        {
            Console.WriteLine("Employee's name is : {0}{1}. Salary : {2}. Number of leave day's : {3}", employee.FirstName, employee.LastName, employee.Salary, employee.AvailableDaysOff);
        }

    }
}
