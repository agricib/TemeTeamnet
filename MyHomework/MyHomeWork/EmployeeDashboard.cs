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
            Console.WriteLine("Toate proiectele finalizate ale angajatului {0}:", employee.LastName);
            foreach (var item in finishedProjects)
            {
                Console.WriteLine("Nume Proiect:{0}, Data inceperii:{1}, Data finalizarii:{2}.", item.Name, item.StartDate, item.FinalDate);
            }
        }

        public void ShowAllEmployeesOnProject(IEnumerable<Employee> employees, Project project)
        {
            Console.WriteLine("Toti angajatii de pe proiectul {0}:", project.Name);
            foreach (var item in employees.Where(e => e.ProjectList.Any(p => p.Id == project.Id)))
            {
                Console.WriteLine("Nume angajat:{0}, Prenume angajat:{1}, Salariu:{2}, Data nasterii:{3}.", item.FirstName, item.LastName, item.Salary, item.DateOfBirth);
            }
        }

        //As fi putut sa fac ShowAllEmployeeOnProject sa returneze lista si sa o folosesc in metoda de mai jos. Dar daca vroiam sa vad de pe alt proiect nu puteam.
        //Desi in Program.cs am dolosti acelasi proiect
        public void ShowAllEmployeesOnLeave(IEnumerable<Employee> employees, Project project)
        {
            Console.WriteLine("Toti angajatii in concediu de pe proiectul {0}:", project.Name);
            var allEmployeesOnProject = employees.Where(e => e.ProjectList.Any(p => p.Id == project.Id));

            foreach (var item in allEmployeesOnProject.Where(e => e.LeaveList.Any(l => l.EndDate > DateTime.Now)))
            {
                Console.WriteLine("Nume angajat:{0}, Prenume angajat:{1}, Salariu:{2}, Data nasterii:{3}.", item.FirstName, item.LastName, item.Salary, item.DateOfBirth);
            }
        }
    }
}
