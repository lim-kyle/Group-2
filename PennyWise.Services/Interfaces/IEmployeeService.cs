using PennyWise.Data.Models;

namespace PennyWise.Services.Interfaces;

public interface IEmployeeService
{
    void AddEmployee(Employee employee);

    IQueryable<Employee> GetEmployees();

    Employee GetEmployee(int Id);

    void UpdateEmployee(Employee employee);

    void DeleteEmployee(int Id);
}

