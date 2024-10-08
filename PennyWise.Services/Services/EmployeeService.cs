using PennyWise.Data.Interfaces;
using PennyWise.Data.Models;
using PennyWise.Services.Interfaces;

namespace PennyWise.Services.Services;

public class EmployeeService: IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public void AddEmployee(Employee employee)
    {
        _repository.AddEmployee(employee);
    }

    public IQueryable<Employee> GetEmployees()
    {
        IQueryable<Employee> employees = _repository.GetEmployees();
        return employees;
    }

    public Employee GetEmployee(int Id)
    {
        return _repository.GetEmployee(Id);
    }

    public void UpdateEmployee(Employee employee)
    {
        _repository.UpdateEmployee(employee);
    }

    public void DeleteEmployee(int Id)
    {
        _repository.DeleteEmployee(Id);
    }
}

