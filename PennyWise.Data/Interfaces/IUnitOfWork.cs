using Microsoft.EntityFrameworkCore;

namespace PennyWise.Data.Interfaces;

public interface IUnitOfWork
{
    DbContext Database { get; }

    void SaveChanges();

    Task SaveChangesAsync(CancellationToken ct);
}
