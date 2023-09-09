using PLaboratory.Core.Domain.DbContexts.Entities.Base;
using System.Linq.Expressions;

namespace PLaboratory.Core.Domain.DbContexts.Repositorys.Base;
public interface IDeleteRepository<T> where T : IEntity
{
    Task DeleteAsync(Expression<Func<T, bool>> predicate);
    Task DeleteLogicAsync(Expression<Func<T, bool>> predicate);
}
