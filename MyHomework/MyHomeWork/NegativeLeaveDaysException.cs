using System;

namespace MyHomeWork
{
    public class NegativeLeaveDaysException : Exception
    {
        public NegativeLeaveDaysException(string message)
            : base(message)
        {
        }
    }
}
