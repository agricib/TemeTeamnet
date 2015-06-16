using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    public class WriteListOfEmployeeToTextFile
    {
        public void WriteListOfEmployeeToText(List<Employee> employeeList)
        {
            StreamWriter file = new StreamWriter("text.txt");
            foreach (var line in employeeList)
                file.WriteLineAsync(line.ToString());
            file.Close();
        }
    }
}
