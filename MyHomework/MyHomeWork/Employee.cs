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
            if (employee.AvailableDaysOff < 0)
                throw NegativeLeaveDaysException();
            LeaveList.Add(leave);
            SubstractDays(leave.Duration);
            
        }

        private Exception NegativeLeaveDaysException()
        {
           string message = "Numarul de zile ramase nu poate fi mai mare decat durata concediului";
           return new Exception(message);
        }

        private void SubstractDays(int days)
        {
            this.AvailableDaysOff -= days;
            Console.WriteLine("Remaining available off days :{0}", this.AvailableDaysOff);
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Employee's name is : {0}{1}. Salary : {2}. Number of leave day's : {3}", this.FirstName, this.LastName, this.Salary, this.AvailableDaysOff);
        }

    }
}
