using StockLink.Auth.Domain.Entities;
using StockLink.Auth.Infrastructure.Commons.Bases.Request;
using StockLink.Auth.Infrastructure.Commons.Bases.Response;

namespace StockLink.Auth.Infrastructure.Persistences.Interfaces
{
    public interface IRolRepository : IGenericRepository<TbRol>
    {
        Task<BaseEntityResponse<TbRol>> ListRoles(BaseFiltersRequest filters);
    }
}