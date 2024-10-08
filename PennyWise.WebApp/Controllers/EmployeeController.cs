using Microsoft.AspNetCore.Mvc;
using PennyWise.Data.Models;
using PennyWise.Services.Interfaces;

namespace PennyWise.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> employees = _employeeService.GetEmployees();
            return View(employees);
        }

        public IActionResult AddEmployees()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployees(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (_employeeService.GetEmployees().Any(e => e.Email == employee.Email))
                {
                    TempData["ErrorMessage"] = "An employee with this email already exists.";
                    return View(employee); 
                }

                _employeeService.AddEmployee(employee);
                TempData["SuccessMessage"] = "Employee added successfully!";
                return RedirectToAction("Index");
            }

            return View(employee); 
        }


        public IActionResult UpdateEmployees(int Id)
        {
            var employee = _employeeService.GetEmployee(Id);
            if (employee == null)
            {
                TempData["ErrorMessage"] = "Employee not found. Please try again."; 
                return RedirectToAction("Index");
            }

            return View(employee); 
        }

        [HttpPost]
        public IActionResult UpdateEmployees(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(employee);
                TempData["SuccessMessage"] = "Employee updated successfully!"; 
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public IActionResult DeleteEmployee(int Id)
        {
            var employee = _employeeService.GetEmployee(Id);

            if (employee != null)
            {
                _employeeService.DeleteEmployee(Id);
                TempData["SuccessMessage"] = "Employee deleted successfully!";
            }
            return RedirectToAction("Index");
        }

    }
}
