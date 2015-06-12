using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    public class EmployeeDashboard
    {
        public List<Project> ShowAllProjects(Employee employee) 
        {
            var employeeProjects = employee.ProjectList.OrderByDescending(o => o.StartDate).ToList();
            return employeeProjects;
        }
        public void ShowAllFinishedProjects() { }
        public void ShowAllEmployeesOnProject() { }
        public void ShowAllEmployeesOnLeave() { }
    }
}
