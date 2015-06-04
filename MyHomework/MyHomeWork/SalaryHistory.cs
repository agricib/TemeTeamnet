using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    public class SalaryHistory
    {
        public DateTime ModificationDate { get; set; }
        public int EmployeeId { get; set; }
        public int Salary { get; set; }

        public SalaryHistory(DateTime modifDate,int emplId,int salary)
        {
            ModificationDate = modifDate;
            EmployeeId = emplId;
            Salary = salary;
        }
    }
}
