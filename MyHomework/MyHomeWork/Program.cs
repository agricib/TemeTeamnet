using System;
using System.Collections.Generic;
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

        static void Main(string[] args)
        {
            Employee empl1 = new Employee(1, DateTime.Now, 2000, 200, DateTime.Today, "White", "Walter");
            Employee empl2 = new Employee(2, DateTime.Now, 1500, 100, DateTime.Today, "Fox", "Jane");
            employeeList.Add(empl1);
            employeeList.Add(empl2);
            Leave leave1 = new Leave(DateTime.Today, 5, LeaveType.Medical);
            Leave leave2 = new Leave(new DateTime(2014, 02, 02), 201, LeaveType.Other);

            AddNewLeave(empl1, leave1);
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
            employee.AddLeave(leave);
            Console.WriteLine("Remainig days of vacation:{0}", employee.AvailableDaysOff);
            foreach (var item in employee.GetLeavePeriods(2014))
            {
                Console.WriteLine("Year {0} , duration {1} , {2}", item.StartingDate, item.Duration, item.LeaveType);
            }
            Console.Read();
        }
    }
}
