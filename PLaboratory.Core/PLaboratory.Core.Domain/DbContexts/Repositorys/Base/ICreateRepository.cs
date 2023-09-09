using PLaboratory.Core.Domain.DbContexts.Entities.Base;

namespace PLaboratory.Core.Domain.DbContexts.Repositorys.Base;

public interface ICreateRepository<T> where T : IEntity
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    Task<T> CreateAsync(T domain);
}
