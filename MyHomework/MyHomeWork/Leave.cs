using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    public class Leave
    {
        public DateTime StartingDate { get; set; }
        public int Duration { get; set; }
        public LeaveType LeaveType { get; set; }
        
        public Leave(DateTime startingDate, int duration, LeaveType leaveType)
        {
            StartingDate = startingDate;
            Duration = duration;
            this.LeaveType = leaveType;
        }
    }
}
