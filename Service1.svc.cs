using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ExpenseTrackingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IExpenseTrackerService<string, int>
    {
        public Expense expense;

        public Income income;
        public ExpenseTrackerDatabaseEntities db;

        ~Service1() { }

        public Service1()
        {
            db = new ExpenseTrackerDatabaseEntities();
        }

        public void Add_Expense(ExpenseDefinition<string, int> Object)
        {
            expense = new Expense()
            {
                Name = Object.Name.ToString(),
                Date = Object.Date.ToString(),
                Amount = -(Convert.ToInt32(Object.Amount))
            };

            db.Expenses.Add(expense);
            db.SaveChanges();
        }

        public void Add_Income(ExpenseDefinition<string, int> Object)
        {
            income = new Income()
            {
                Name = Object.Name.ToString(),
                Date = Object.Date.ToString(),
                Amount = Convert.ToInt32(Object.Amount)
            };

            db.Incomes.Add(income);
            db.SaveChanges();
        }

        public void Update_Income(ExpenseDefinition<string, int> Object)
        {
            var inc = db.Incomes.Where(x => x.Id == Object.Id).Select(x => x).FirstOrDefault();
            inc.Name = Object.Name;
            inc.Date = Object.Date;
            inc.Amount = Object.Amount;
            db.SaveChanges();
        }

        public void Update_Expense(ExpenseDefinition<string, int> Object)
        {
            var exp = db.Expenses.Where(x => x.Id == Object.Id).FirstOrDefault();
            if (exp != null)
            {
                exp.Name = Object.Name;
                exp.Date = Object.Date;
                exp.Amount = Object.Amount;
                db.SaveChanges();
            }
            else
            {
                // Handle the case where the expense was not found
                throw new Exception($"Expense with Id {Object.Id} not found");
            }
        }



        public List<Income> Get_Income()
        {
            return db.Incomes.ToList();
        }

        public List<Expense> Get_Expense()
        {
            return db.Expenses.ToList();
        }

        public void Delete_Income(int Id)
        {
            var inc = db.Incomes.Where(x => x.Id == Id).Select(x => x).FirstOrDefault();
            db.Incomes.Remove(inc);
            db.SaveChanges();
        }

        public void Delete_Expense(int Id)
        {
            var exp = db.Expenses.Where(x => x.Id == Id).Select(x => x).FirstOrDefault();
            db.Expenses.Remove(exp);
            db.SaveChanges();
        }

        public Income Get_Income_By_Id(int Id)
        {
            return db.Incomes.Where(x => x.Id == Id).Select(x => x).FirstOrDefault();
        }

        public Expense Get_Expense_By_Id(int Id)
        {
            return db.Expenses.Where(x => x.Id == Id).Select(x => x).FirstOrDefault();
        }
    }
}
