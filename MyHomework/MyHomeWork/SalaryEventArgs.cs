﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    public class SalaryEventArgs : EventArgs
    {
        public string oldSalaryInfo;
        public string newSalaryInfo;

        public SalaryEventArgs(string oldSalaryInfo, string newSalaryInfo)
        {
            this.oldSalaryInfo = oldSalaryInfo;
            this.newSalaryInfo = newSalaryInfo;
        }
    }
}
