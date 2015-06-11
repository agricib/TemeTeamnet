using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    public class MyEventArgs : EventArgs
    {
        string oldString;
        string newString;

        public MyEventArgs(string oldString,string newString)
        {
            this.oldString = oldString;
            this.newString = newString;
        }
    }
}
