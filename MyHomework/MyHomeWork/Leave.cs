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
        public Employee Employee { get; set; }

        private LeaveType leaveType;
        public enum LeaveType
        {
            medical,
            holiday,
            other,
        };
        
        public Leave(DateTime startingDate, int duration, LeaveType leaveType, Employee employee)
        {
            StartingDate = startingDate;
            Duration = duration;
            this.leaveType = leaveType;
            Employee = employee;
        }
    }
}
