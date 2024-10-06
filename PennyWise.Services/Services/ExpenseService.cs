using PennyWise.Data.Interfaces;
using PennyWise.Data.Models;
using PennyWise.Services.Interfaces;

namespace PennyWise.Services.Services;

public class ExpenseService: IExpenseService
{
    private readonly IExpenseRepository _repository;

    public ExpenseService(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public void AddExpense(Expense expense)
    {
        _repository.AddExpense(expense);
    }

    public IQueryable<Expense> GetExpenses()
    {
        IQueryable<Expense> expenses =  _repository.GetExpenses();
        return expenses;
    }
}
