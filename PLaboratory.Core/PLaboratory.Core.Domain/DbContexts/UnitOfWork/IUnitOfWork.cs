namespace PLaboratory.Core.Domain.DbContexts.UnitOfWork;

public interface IUnitOfWork
{
    Task CommitAsync();
    Task RollbackAsync();
}
