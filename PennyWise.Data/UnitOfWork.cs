using Microsoft.EntityFrameworkCore;
using PennyWise.Data.Interfaces;

namespace PennyWise.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    public DbContext Database { get; private set; }

    public UnitOfWork(PennyWiseDbContext serviceContext)
    {
        Database = serviceContext;
    }

    public void SaveChanges()
    {
        Database.SaveChanges();
    }

    public void SaveChangesAsync(CancellationToken ct)
    {
        Database.SaveChangesAsync(ct);
    }

    public void Dispose()
    {
        Database.Dispose();
    }
}
