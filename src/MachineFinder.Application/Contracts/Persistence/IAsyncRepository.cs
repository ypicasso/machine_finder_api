using MachineFinder.Domain.Entities;

namespace MachineFinder.Application.Contracts.Persistence
{
    public interface IAsyncRepository
    {
        Task AddEntityAsync<D>(D entity) where D : BaseDomainModel;
        Task UpdateEntityAsync<D>(D entity) where D : BaseDomainModel;
        Task DeleteEntityAsync<D>(D entity) where D : BaseDomainModel;
    }
}
