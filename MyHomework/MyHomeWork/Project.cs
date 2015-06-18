using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        

        public Project(int id,string name,DateTime startDate,DateTime finalDate)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            FinalDate = finalDate;
        }
    }
}
