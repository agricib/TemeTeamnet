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

            AddNewLeave(empl1, leave1);
        }
        
        static void AddNewLeave(Employee employee,Leave leave)
        {
            employee.AddLeave(leave);
            Console.WriteLine("")
        }
    }
}
