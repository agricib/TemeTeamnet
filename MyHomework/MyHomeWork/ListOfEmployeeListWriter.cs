using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    public class ListOfEmployeeListWriter
    {
        public void WriteListOfEmployeeToTextFile(List<Employee> employeeList)
        {
            using (StreamWriter file = new StreamWriter("text.txt"))
            {
                foreach (var item in employeeList)
                    file.WriteLineAsync(item.ToString());
                file.Close();
            }
        }
    }
}
