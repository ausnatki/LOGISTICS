using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.LOG.Services
{
    public interface ISysExpenses
    {
        public Task<List<object>> Get_All_Expenses_ListAsync(int Page, int Limit, string name);
       
        public Task<string> Save_Update_ExpensesAsync(CQIE.LOG.Models.Expenses.Expenses expenses,CQIE.LOG.Models.Expenses.Cost cost);
        public Task<CQIE.LOG.Models.Expenses.Expenses> Get_By_IdAsync(int id);
    }
}
