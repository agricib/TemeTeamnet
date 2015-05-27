using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    class Leave 
    {
        public string StartingDate { get; set; }
        public int Duration { get; set; }
        public string LeaveType { get; set; }
        public Employee Employee { get; set; }

        public Leave(string startingDate,int duration,string leaveType,Employee employee)
        {
            StartingDate = startingDate;
            Duration = duration;
            LeaveType = leaveType;
            Employee = employee;
        }
    }
}
