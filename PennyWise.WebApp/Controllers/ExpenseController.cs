using Microsoft.AspNetCore.Mvc;
using PennyWise.Data.Models;
using PennyWise.Services.Interfaces;

namespace PennyWise.WebApp.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService) 
        {
            _expenseService = expenseService;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> expenses = _expenseService.GetExpenses();
            return View(expenses);
        }

        public IActionResult AddExpenses()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddExpenses(Expense expense) 
        {
            _expenseService.AddExpense(expense);
            return RedirectToAction("Index", "Expense");
        }
    }
}
