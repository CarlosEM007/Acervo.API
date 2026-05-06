using Acervo.Domain.Common;

namespace Acervo.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<Result<T>> GetById(long Id);
        Task<Result> Update(T Entity);
        Task<Result> Insert(T Entity);
        Task<Result> Delete(long Id);
    }
}
