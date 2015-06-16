
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    class Program
    {
        private static List<Employee> employeeList = new List<Employee>();
        public List<Employee> GetList()
        {
            return employeeList;
        }

        static ListOfEmployeeListWriter writeToText = new ListOfEmployeeListWriter();
        static EmployeeDashboard employeeDashboard = new EmployeeDashboard();

        static void Main(string[] args)
        {
            Employee empl1 = new Employee(1, DateTime.Now, 2000, 200, DateTime.Today, "White", "Walter",1);
            Employee empl2 = new Employee(2, DateTime.Now, 1500, 100, DateTime.Today, "Fox", "Jane",1);
            Employee empl3 = new Employee(3, DateTime.Now, 500, 100, DateTime.Today, "Body", "Loo",1);
            Employee empl4 = new Employee(4, DateTime.Now, 100, 100, DateTime.Today, "Nanda", "Wolf",2);
            Leave leave1 = new Leave(empl1.LastName,DateTime.Today, 5, LeaveType.Medical);
            Leave leave2 = new Leave(empl2.LastName,new DateTime(2014, 02, 02), 201, LeaveType.Other);
            Project project1 = new Project(1,"Proiect",new DateTime(2014, 02, 02),new DateTime(2015, 02, 02));
            Project project2 = new Project(1, "Nume", new DateTime(2014, 02, 02), new DateTime(2015, 02, 02));
            Project project3 = new Project(1, "Aqua", new DateTime(2014, 02, 02), new DateTime(2015, 02, 02));
            Project project4 = new Project(1, "Shalabam,", new DateTime(2014, 02, 02), new DateTime(2015, 10, 10));

            employeeList.Add(empl1);
            employeeList.Add(empl2);
            employeeList.Add(empl3);
            employeeList.Add(empl4);

            AddProjectsToProjectList(empl1, project1);
            AddProjectsToProjectList(empl1, project2);

            var serializedObject = JsonHelper.SerializeObject(empl1);
            Console.WriteLine(serializedObject);
            var deserializedObject = JsonHelper.DeserializeObject(serializedObject);
            Console.WriteLine(deserializedObject);


            AddProjectsToProjectList(empl1, project3);
            AddProjectsToProjectList(empl1, project4);
            AddNewLeave(empl1, leave1);
            employeeList.Sort();
            
            foreach (var item in employeeList)
            {
                Console.WriteLine(item);
            }

            WriteListOfEmployeeToTxt(employeeList);

            SalaryHistory newSalaryHistory = new SalaryHistory(DateTime.Now,1,1);

            empl1.NewSalaryAdded += empl1_NewSalaryAdded;
            empl1.AddNewSalaryHistory(newSalaryHistory);

           

            DisplayAllMethodsOfEmployeeDashboard(employeeDashboard, empl1, employeeList);

            Console.Read();
            
        }

        static void empl1_NewSalaryAdded(object sender, EventArgs e)
        {
            Console.WriteLine("S-a ridicat evenimentul");
        }

        static void DisplayAllMethodsOfEmployeeDashboard(EmployeeDashboard employeeDashboard,Employee employee,List<Employee> employeeList)
        {
            foreach (var item in employeeDashboard.ShowAllProjects(employee.ProjectList))
            {
                Console.WriteLine("{0} , {1} , {2} , {3}",item.Id,item.Name,item.StartDate,item.FinalDate);
            }

            foreach (var item in employeeDashboard.ShowAllEmployeesOnProject(employeeList))
            {
                Console.WriteLine("{0} , {1} , {2} , {3}", item.LastName, item.FirstName, item.ProjectId, item.Employee_Id);
            }

            foreach (var item in employeeDashboard.ShowAllFinishedProjects(employee.ProjectList))
            {
                Console.WriteLine("{0} , {1} , {2} , {3}", item.Id, item.Name, item.StartDate, item.FinalDate);
            }
            foreach (var item in employeeDashboard.ShowAllEmployeesOnLeave(employee.LeaveList))
            {
                Console.WriteLine("{0} , {1} , {2} , {3}", item.EmployeeName, item.Duration, item.LeaveType, item.StartingDate);
            }

        }

        static void AddNewLeave(Employee employee, Leave leave)
        {
            try 
            {
                employee.AddLeave(leave); 
            }
            catch (NegativeLeaveDaysException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine(employee.DisplayInfo());
            Console.WriteLine("Number of leave days to substract is {0}", leave.Duration);
            Console.WriteLine("Remainig days of vacation:{0}", employee.AvailableDaysOff);
            foreach (var item in employee.GetLeavePeriods(2014))
            {
                Console.WriteLine("Year {0} , duration {1} , {2}", item.StartingDate, item.Duration, item.LeaveType);
            }
        }

        static void AddProjectsToProjectList(Employee employee,Project project)
        {
            employee.AddProjectsToList(project);
        }

        static void WriteListOfEmployeeToTxt(List<Employee> employeeList)
        {
            writeToText.WriteListOfEmployeeToTextFile(employeeList);
        }
    }
}
