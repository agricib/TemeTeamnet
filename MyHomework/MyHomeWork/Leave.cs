using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    class Leave 
    {
        public DateTime StartingDate { get; set; }
        public int Duration { get; set; }
        public Enum LeaveType { get; set; }
        public Employee Employee { get; set; }

        public Leave(DateTime startingDate, int duration, Enum leaveType, Employee employee)
        {
            StartingDate = startingDate;
            Duration = duration;
            LeaveType = leaveType;
            Employee = employee;
        }
    }
}
