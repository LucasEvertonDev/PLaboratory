using MS.Libs.Core.Domain.DbContexts.Entities.Base;
using MS.Libs.Core.Domain.Infra.Attributes;

namespace PLaboratory.Core.Domain.DbContexts.Entities;

[Cache(Key: "ClientCredentials", SlidingExpirationInMinutes:10, AbsoluteExpirationInMinutes: 15)]
public class ClientCredentials : BaseEntity
{
    public Guid ClientId { get; set; }

    public string ClientSecret { get; set; }

    public string ClientDescription { get; set; }
}
