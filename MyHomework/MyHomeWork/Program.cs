﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    class Program
    {
        static List<Employee> employeeList = new List<Employee>();
        public List<Employee> GetList()
        {
            return employeeList;
        }

        static void Main(string[] args)
        {
            #region Populare liste
            Employee employee1 = new Employee(1, DateTime.Now, 2000, 200, DateTime.Today, "White", "Walter");
            Employee employee2 = new Employee(2, DateTime.Now, 1500, 100, DateTime.Today, "Fox", "Jane");
            Employee employee3 = new Employee(3, DateTime.Now, 500, 100, DateTime.Today, "Body", "Loo");
            Employee employee4 = new Employee(4, DateTime.Now, 100, 100, DateTime.Today, "Nanda", "Wolf");
            Leave leave1 = new Leave(employee1.LastName, DateTime.Today, 5, LeaveType.Medical);
            Leave leave2 = new Leave(employee2.LastName, new DateTime(2016, 02, 02), 201, LeaveType.Other);
            Project project1 = new Project(1, "Proiect", new DateTime(2014, 02, 02), new DateTime(2015, 02, 02));
            Project project2 = new Project(1, "Nume", new DateTime(2014, 02, 02), new DateTime(2015, 02, 02));
            Project project3 = new Project(1, "Aqua", new DateTime(2014, 02, 02), new DateTime(2015, 02, 02));
            Project project4 = new Project(1, "Shalabam,", new DateTime(2014, 02, 02), new DateTime(2015, 10, 10));
            SalaryHistory newSalaryHistory = new SalaryHistory(DateTime.Now, 1, 1000);


            employeeList.Add(employee1);
            employeeList.Add(employee2);
            employeeList.Add(employee3);
            employeeList.Add(employee4);

            AddProjectsToProjectList(employee1, project1);
            AddProjectsToProjectList(employee1, project2);
            AddProjectsToProjectList(employee1, project3);
            AddProjectsToProjectList(employee1, project4);
            #endregion

            Employee_Serializer_Desirializer(employee1);

            ShowSortedEmployeeList(employeeList);

            AddNewLeave(employee1, leave1);

            WriteListOfEmployeeToTxt(employeeList);

            employee1.NewSalaryAdded += empl1_NewSalaryAdded;
            employee1.AddNewSalaryHistory(newSalaryHistory);

            AllMethodFromEmployeeDashboard(employee1, project1);

            Console.Read();
        }
        static void AllMethodFromEmployeeDashboard(Employee employee, Project project)
        {
            EmployeeDashboard employeeDashboard = new EmployeeDashboard();
            employeeDashboard.ShowAllProjects(employee);
            employeeDashboard.ShowAllFinishedProjects(employee);
            employeeDashboard.ShowAllEmployeesOnProject(employeeList, project);
            employeeDashboard.ShowAllEmployeesOnLeave(employeeList, project);
        }

        static void empl1_NewSalaryAdded(object sender, EventArgs e)
        {
            Console.WriteLine("S-a ridicat evenimentul");
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
            catch (NullReferenceException ex)
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

        static void AddProjectsToProjectList(Employee employee, Project project)
        {
            employee.AddProjectsToList(project);
        }

        static void WriteListOfEmployeeToTxt(List<Employee> employeeList)
        {
            ListOfEmployeeListWriter writeToText = new ListOfEmployeeListWriter();
            writeToText.WriteListOfEmployeeToTextFile(employeeList);
        }

        static void Employee_Serializer_Desirializer(Employee employee)
        {
            var serializedObject = JsonHelper<Employee>.SerializeObject(employee, @"d:\serialized.json");
            Console.WriteLine(serializedObject);

            var deserializedObject = JsonHelper<Employee>.DeserializeObject(serializedObject, @"d:\deserialized.txt");
            Console.WriteLine(deserializedObject);
        }

        static void ShowSortedEmployeeList(List<Employee> employeeList)
        {
            employeeList.Sort();

            foreach (var item in employeeList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
