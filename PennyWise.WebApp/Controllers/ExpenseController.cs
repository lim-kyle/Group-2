using Microsoft.AspNetCore.Mvc;
using PennyWise.Data.Models;
using PennyWise.Services.Interfaces;

namespace PennyWise.WebApp.Controllers;

public class ExpenseController : Controller
{
    private readonly IExpenseService _expenseService;

    public ExpenseController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        IEnumerable<Expense> expenses = await _expenseService.GetExpensesAsync(ct);
        return View(expenses);
    }

    public IActionResult AddExpenses()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddExpenses(Expense expense, CancellationToken ct)
    {
        if (expense == null)
        {
            ModelState.AddModelError(string.Empty, "Expense cannot be null.");
            return View(expense);
        }

        try
        {
            await _expenseService.AddExpenseAsync(expense, ct);
            return RedirectToAction("Index");
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(expense);
        }
    }

    public async Task<IActionResult> UpdateExpenses(int id, CancellationToken ct)
    {
        var expense = await _expenseService.GetExpenseByIdAsync(id, ct);
        if (expense == null)
        {
            return NotFound();
        }
        return View(expense);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Expense expense, CancellationToken ct)
    {
        if (expense == null)
        {
            ModelState.AddModelError(string.Empty, "Expense cannot be null.");
            return View(expense);
        }

        try
        {
            await _expenseService.UpdateExpenseAsync(expense, ct);
            return RedirectToAction("Index");
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(expense);
        }
    }

    public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken ct)
    {
        try
        {
            await _expenseService.DeleteExpenseAsync(id, ct);
            return RedirectToAction("Index");
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return RedirectToAction("Index");
        }
    }
}
