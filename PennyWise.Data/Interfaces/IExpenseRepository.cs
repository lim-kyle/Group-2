using PennyWise.Data.Models;

namespace PennyWise.Data.Interfaces;

public interface IExpenseRepository
{
    Task AddExpenseAsync(Expense expense, CancellationToken ct);
    Task<List<Expense>> GetExpensesAsync(CancellationToken ct);
    Task UpdateExpenseAsync(Expense expense, CancellationToken ct);
    Task<Expense?> GetExpenseByIdAsync(int expenseId, CancellationToken ct);
    Task DeleteExpenseAsync(int expenseId, CancellationToken ct);
}
