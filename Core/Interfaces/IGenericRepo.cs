using Core.Entitites;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepo<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecs<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecs<T> spec);
    }
}