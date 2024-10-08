using Microsoft.EntityFrameworkCore;
using PennyWise.Data.Interfaces;
using PennyWise.Data.Models;

namespace PennyWise.Data.Repositories;

public class EmployeeRepository : BaseRepository, IEmployeeRepository
{
    public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public void AddEmployee(Employee employee)
    {
        this.GetDbSet<Employee>().Add(employee);
        UnitOfWork.SaveChanges();
    }

    public IQueryable<Employee> GetEmployees()
    {
        return this.GetDbSet<Employee>();
    }

    public Employee GetEmployee(int Id)
    {
        return this.GetDbSet<Employee>().FirstOrDefault(e => e.Id == Id);
    }

    public void UpdateEmployee(Employee employee)
    {
        var Employ = this.GetDbSet<Employee>().FirstOrDefault(e => e.Id == employee.Id);
        
        if (Employ != null)
        {
            Employ.FirstName = employee.FirstName;
            Employ.LastName = employee.LastName;
            Employ.Email = employee.Email;
            Employ.Contact = employee.Contact;

            UnitOfWork.SaveChanges();
        }
    }

    public void DeleteEmployee(int Id)
    {
        var employee = this.GetDbSet<Employee>().FirstOrDefault(e => e.Id == Id);
        if (employee != null)
        {
            this.GetDbSet<Employee>().Remove(employee);
            UnitOfWork.SaveChanges();
        }
    }


}
