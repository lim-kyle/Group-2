using PennyWise.Data.Models;

namespace PennyWise.Data.Interfaces;

public interface IEmployeeRepository
{
    void AddEmployee(Employee employee);

    IQueryable<Employee> GetEmployees();

    Employee GetEmployee(int Id);

    void UpdateEmployee(Employee employee);

    void DeleteEmployee(int Id);

}

