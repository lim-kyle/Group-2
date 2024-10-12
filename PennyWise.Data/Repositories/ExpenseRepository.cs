using Microsoft.EntityFrameworkCore;
using PennyWise.Data.Interfaces;
using PennyWise.Data.Models;

namespace PennyWise.Data.Repositories;

public class ExpenseRepository : BaseRepository, IExpenseRepository
{
    public ExpenseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task AddExpenseAsync(Expense expense, CancellationToken ct)
    {
        await this.GetDbSet<Expense>().AddAsync(expense, ct);
        await UnitOfWork.SaveChangesAsync(ct);
    }

    public async Task<List<Expense>> GetExpensesAsync(CancellationToken ct)
    {
        return await this.GetDbSet<Expense>().ToListAsync(ct);
    }

    public async Task UpdateExpenseAsync(Expense expense, CancellationToken ct)
    {
        var existingExpense = await this.GetDbSet<Expense>().FirstOrDefaultAsync(c => c.Id == expense.Id, ct);
        if (existingExpense != null)
        {
            existingExpense.ExpenseTitle = expense.ExpenseTitle;
            existingExpense.Category = expense.Category;
            existingExpense.Amount = expense.Amount;
            await UnitOfWork.SaveChangesAsync(ct);
        }
    }

    public async Task<Expense?> GetExpenseByIdAsync(int expenseId, CancellationToken ct)
    {
        return await this.GetDbSet<Expense>().FirstOrDefaultAsync(c => c.Id == expenseId, ct);
    }

    public async Task DeleteExpenseAsync(int expenseId, CancellationToken ct)
    {
        var expense = await this.GetDbSet<Expense>().FirstOrDefaultAsync(c => c.Id == expenseId, ct);
        if (expense != null)
        {
            this.GetDbSet<Expense>().Remove(expense);
            await UnitOfWork.SaveChangesAsync(ct);
        }
    }
}
