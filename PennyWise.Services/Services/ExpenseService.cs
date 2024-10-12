﻿using PennyWise.Data.Interfaces;
using PennyWise.Data.Models;
using PennyWise.Services.Interfaces;

namespace PennyWise.Services.Services;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _repository;

    public ExpenseService(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task AddExpenseAsync(Expense expense, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(expense.ExpenseTitle))
        {
            throw new ArgumentException("Expense title cannot be null or empty.", nameof(expense.ExpenseTitle));
        }

        if (string.IsNullOrWhiteSpace(expense.Category))
        {
            throw new ArgumentException("Category cannot be null or empty.", nameof(expense.Category));
        }

        try
        {
            var newExpense = new Expense
            {
                ExpenseTitle = expense.ExpenseTitle,
                Category = expense.Category,
                Amount = expense.Amount,
                DateCreated = DateTime.Now
            };

            await _repository.AddExpenseAsync(newExpense, ct);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error adding expense", ex);
        }
    }

    public async Task<List<Expense>> GetExpensesAsync(CancellationToken ct)
    {
        try
        {
            var expenses = await _repository.GetExpensesAsync(ct);

            if (expenses == null)
            {
                return new List<Expense>();
            }

            return expenses;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error retrieving expenses", ex);
        }
    }

    public async Task<Expense?> GetExpenseByIdAsync(int expenseId, CancellationToken ct)
    {
        try
        {
            var expense = await _repository.GetExpenseByIdAsync(expenseId, ct);

            if (expense == null)
            {
                throw new KeyNotFoundException($"Expense with ID {expenseId} not found.");
            }

            return expense;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error retrieving expense by ID", ex);
        }
    }

    public async Task UpdateExpenseAsync(Expense expense, CancellationToken ct)
    {
        if (expense == null)
        {
            throw new ArgumentNullException(nameof(expense));
        }

        if (string.IsNullOrWhiteSpace(expense.ExpenseTitle))
        {
            throw new ArgumentException("Expense title cannot be null or empty.", nameof(expense.ExpenseTitle));
        }

        if (string.IsNullOrWhiteSpace(expense.Category))
        {
            throw new ArgumentException("Category cannot be null or empty.", nameof(expense.Category));
        }

        try
        {
            var existingExpense = await _repository.GetExpenseByIdAsync(expense.Id, ct);
            if (existingExpense == null)
            {
                throw new KeyNotFoundException($"Expense with ID {expense.Id} not found.");
            }

            await _repository.UpdateExpenseAsync(expense, ct);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error updating expense", ex);
        }
    }

    public async Task DeleteExpenseAsync(int expenseId, CancellationToken ct)
    {
        try
        {
            var existingExpense = await _repository.GetExpenseByIdAsync(expenseId, ct);
            if (existingExpense == null)
            {
                throw new KeyNotFoundException($"Expense with ID {expenseId} not found.");
            }

            await _repository.DeleteExpenseAsync(expenseId, ct);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error deleting expense", ex);
        }
    }
}
