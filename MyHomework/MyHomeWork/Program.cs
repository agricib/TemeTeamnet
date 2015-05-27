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

            Employee empl1 = new Employee(1, "12/12/2012", 2000, 200, "1/1/1993", "White", "Walter");
            Employee empl2 = new Employee(2, "1/1/2014", 1500, 100, "12/12/1991", "Fox", "Jane");
            employeeList.Add(empl1);
            employeeList.Add(empl2);

            Console.WriteLine("Do you wish to add a new leave? Answer with yes or no!");
            var answer = Console.ReadLine();
            if(answer == "yes")
                Employee.AddNewLeave();




            Console.ReadLine();
        }
    }
}
