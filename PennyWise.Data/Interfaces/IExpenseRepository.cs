using PennyWise.Data.Models;

namespace PennyWise.Data.Interfaces;

public interface IExpenseRepository
{
    void AddExpense(Expense expense);
    IQueryable<Expense> GetExpenses();
}
