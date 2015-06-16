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
            return employee.ProjectList.OrderByDescending(e => e.StartDate).ToList();
        }

        public List<Project> ShowAllFinishedProjects(List<Project> projectList) 
        {
            return projectList.Where(e => e.FinalDate < DateTime.Today).ToList();
        }

        public List<Employee> ShowAllEmployeesOnProject(List<Employee> employeeList)
        {
            return employeeList.Where(e => e.ProjectId == e.ProjectId).ToList();
        }

        public List<Leave> ShowAllEmployeesOnLeave(List<Leave> leaveList)
        {
            return leaveList.ToList();
        }
    }
}
