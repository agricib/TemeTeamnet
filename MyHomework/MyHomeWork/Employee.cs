using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    public class Employee : Person , IComparable<Employee>
    {
        public int Employee_Id { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public int Salary { get; set; }
        public int AvailableDaysOff { get; set; }
        public List<Leave> LeaveList { get; set; }
        public List<Project> ProjectList { get; set; }

        public event EventHandler NewSalaryAdded;

        public Employee(int Id, DateTime dateOfEmployment, int salary, int availableDaysOff, DateTime dateOfBirth, string lastName, string firstName)
        {
            Employee_Id = Id;
            DateOfEmployment = dateOfEmployment;
            Salary = salary;
            AvailableDaysOff = availableDaysOff;
            DateOfBirth = dateOfBirth;
            LastName = lastName;
            FirstName = firstName;
            LeaveList = new List<Leave>();
            ProjectList = new List<Project>();
        }

        private void SubstractDays(int days)
        {
            this.AvailableDaysOff -= days;
        }

        public void AddLeave(Leave leave)
        {
            if (this.AvailableDaysOff < leave.Duration)
                throw new NegativeLeaveDaysException("Numarul de zile ramase nu poate fi mai mare decat durata concediului");
            LeaveList.Add(leave);
            SubstractDays(leave.Duration);
            DisplayInfo();
        }

        public string DisplayInfo()
        {
            string info = String.Format("Employee's name is : {0}{1}. Salary : {2}. Number of leave day's : {3}", this.FirstName, this.LastName, this.Salary, this.AvailableDaysOff);
            return info;
        }

        public List<Leave> GetLeavePeriods(int year)
        {
            var leaveDays = LeaveList.Where(x => x.StartingDate.Year == year).ToList();
            return leaveDays;
        }

        public void AddProjectToEmployee(Project project)
        {
            ProjectList.Add(project);
        }

        public void AddNewSalaryHistory(SalaryHistory salaryHistory)
        {
            SalaryHistory newSalaryHistory = new SalaryHistory(salaryHistory.ModificationDate, salaryHistory.EmployeeId, salaryHistory.Salary);
            this.Salary = newSalaryHistory.Salary;
            OnNewSalaryAdded(EventArgs.Empty); 
        }

        public virtual void OnNewSalaryAdded(EventArgs e)
        {
            if (NewSalaryAdded != null)
                NewSalaryAdded(this, e);
        }

        public int CompareTo(Employee other)
        {
            if (this.Salary == other.Salary)
                return this.FirstName.CompareTo(other.FirstName);
            return other.Salary.CompareTo(this.Salary);
        }

        public override string ToString()
        {
            return this.Salary.ToString() + "," + this.FirstName;
        }
    }
}
