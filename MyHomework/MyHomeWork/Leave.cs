using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    public class Leave
    {
        public string EmployeeName { get; set; }
        public int Duration { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate;
        public LeaveType LeaveType { get; set; }
        
        public Leave(string employeeName,DateTime startingDate, int duration, LeaveType leaveType)
        {
            EmployeeName = employeeName;
            StartingDate = startingDate;
            Duration = duration;
            EndDate = StartingDate.AddDays(Duration);
            this.LeaveType = leaveType;
        }
    }
}
