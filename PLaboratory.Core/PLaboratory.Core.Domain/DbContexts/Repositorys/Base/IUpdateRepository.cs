using PLaboratory.Core.Domain.DbContexts.Entities.Base;

namespace PLaboratory.Core.Domain.DbContexts.Repositorys.Base;
public interface IUpdateRepository<T> where T : IEntity
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    Task<T> UpdateAsync(T domain);
}
