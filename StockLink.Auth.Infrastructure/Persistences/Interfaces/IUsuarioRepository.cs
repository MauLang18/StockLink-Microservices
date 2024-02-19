using StockLink.Auth.Domain.Entities;
using StockLink.Auth.Infrastructure.Commons.Bases.Request;
using StockLink.Auth.Infrastructure.Commons.Bases.Response;

namespace StockLink.Auth.Infrastructure.Persistences.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<TbUsuario>
    {
        Task<BaseEntityResponse<TbUsuario>> ListUsuarios(BaseFiltersRequest filters);
        Task<TbUsuario> UserByUser(string user);
    }
}