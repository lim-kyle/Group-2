using Microsoft.EntityFrameworkCore;
using PennyWise.Data.Interfaces;

namespace PennyWise.Data.Repositories;

public class BaseRepository
{
    protected IUnitOfWork UnitOfWork { get; set; }

    protected PennyWiseDbContext Context => (PennyWiseDbContext)UnitOfWork.Database;

    public BaseRepository(IUnitOfWork unitOfWork)
    {
        if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));
        UnitOfWork = unitOfWork;
    }

    protected virtual DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
    {
        return Context.Set<TEntity>();
    }

    protected virtual void SetEntityState(object entity, EntityState entityState)
    {
        Context.Entry(entity).State = entityState;
    }
}
