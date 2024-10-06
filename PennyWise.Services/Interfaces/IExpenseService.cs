using PennyWise.Data.Models;

namespace PennyWise.Services.Interfaces;

public interface IExpenseService
{
    void AddExpense(Expense expense);
    IQueryable<Expense> GetExpenses();
}
