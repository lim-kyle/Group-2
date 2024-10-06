using PennyWise.Data.Interfaces;
using PennyWise.Data.Models;

namespace PennyWise.Data.Repositories;

public class ExpenseRepository: BaseRepository, IExpenseRepository
{
    public ExpenseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public void AddExpense(Expense expense)
    {
        this.GetDbSet<Expense>().Add(expense);
        UnitOfWork.SaveChanges();
    }

    public IQueryable<Expense> GetExpenses()
    {
        return this.GetDbSet<Expense>();
    }
}
