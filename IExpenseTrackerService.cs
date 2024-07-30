using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ExpenseTrackingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IExpenseTrackerService<E, A>
    {
        [OperationContract]
        void Add_Income(ExpenseDefinition<E, A> Object);
        [OperationContract]
        void Add_Expense(ExpenseDefinition<E, A> Object);

        [OperationContract]
        void Update_Income(ExpenseDefinition<E, A> Object);
        [OperationContract]
        void Update_Expense(ExpenseDefinition<E, A> Object);

        [OperationContract]
        void Delete_Income(A Id);
        [OperationContract]
        void Delete_Expense(A Id);

        [OperationContract]
        List<Income> Get_Income();
        [OperationContract]
        List<Expense> Get_Expense();

        [OperationContract]
        Income Get_Income_By_Id(A Id);
        [OperationContract]
        Expense Get_Expense_By_Id(A Id);
    }
}
