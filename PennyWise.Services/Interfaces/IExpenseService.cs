using PennyWise.Data.Models;

namespace PennyWise.Services.Interfaces;

public interface IExpenseService
{
    Task AddExpenseAsync(Expense expense, CancellationToken ct);
    Task<List<Expense>> GetExpensesAsync(CancellationToken ct);
    Task<Expense?> GetExpenseByIdAsync(int expenseId, CancellationToken ct);
    Task UpdateExpenseAsync(Expense expense, CancellationToken ct);
    Task DeleteExpenseAsync(int expenseId, CancellationToken ct);
}
