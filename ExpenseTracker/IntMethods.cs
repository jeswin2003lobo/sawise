using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    public static class IntMethods
    {
        public static int getBalance(this int income, int expense)
        {
            return income + expense;
        }
    }
}
