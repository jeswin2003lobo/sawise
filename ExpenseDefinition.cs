using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTrackingService
{
    public class ExpenseDefinition<E, A>
    {
        public A Id { get; set; }
        public E Name { get; set; }
        public E Date { get; set; }
        public A Amount { get; set; }
    }
}