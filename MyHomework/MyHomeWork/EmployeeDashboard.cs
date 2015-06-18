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
        public void ShowAllProjects(Employee employee)
        {
            var projects = employee.ProjectList.OrderBy(project => project.StartDate).ToList();
            Console.WriteLine("Toate proiectele pe care este un angajat:");
            foreach (var item in projects)
            {
                Console.WriteLine("Nume Proiect:{0}, Data inceperii:{1}, Data finalizarii:{2}.", item.Name, item.StartDate, item.FinalDate);
            }
        }

        public void ShowAllFinishedProjects(Employee employee)
        {
            var finishedProjects = employee.ProjectList.Where(project => project.FinalDate < DateTime.Now).ToList();
            Console.WriteLine("Toate proiectele finalizate ale angajatului:");
            foreach (var item in finishedProjects)
            {
                Console.WriteLine("Nume Proiect:{0}, Data inceperii:{1}, Data finalizarii:{2}.", item.Name, item.StartDate, item.FinalDate);
            }
        }

        public void ShowAllEmployeesOnProject(IEnumerable<Employee> employees, Project project)
        {
            var query = employees.Where(e => e.ProjectList.Where(p => p.Name == project.Name)).ToList();
            Console.WriteLine("Toti angajatii de pe un proiect:");
            foreach (var item in query)
            {
                Console.WriteLine("Nume angajat:{0}, Prenume angajat:{1}, Salariu:{2}, Data nasterii:{3}.");
            }
        }

        public void ShowAllEmployeesOnLeave(List<Leave> leaveList)
        {

        }
    }
}
