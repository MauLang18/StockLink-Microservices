using Microsoft.EntityFrameworkCore;
using StockLink.Auth.Domain.Entities;
using StockLink.Auth.Infrastructure.Commons.Bases.Request;
using StockLink.Auth.Infrastructure.Commons.Bases.Response;
using StockLink.Auth.Infrastructure.Persistences.Contexts;
using StockLink.Auth.Infrastructure.Persistences.Interfaces;


namespace StockLink.Auth.Infrastructure.Persistences.Repository
{
    public class RolRepository : GenericRepository<TbRol>, IRolRepository
    {
        private readonly UsuariosContext _context;
        public RolRepository(UsuariosContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BaseEntityResponse<TbRol>> ListRoles(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<TbRol>();

            var usuarios = GetEntityQuery(x => x.Id != 0 && x.Rol != null)
                .AsNoTracking();

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        usuarios = usuarios.Where(x => x.Rol!.Contains(filters.TextFilter));
                        break;
                }
            }

            if (filters.Sort is null) filters.Sort = "Id";

            response.TotalRecords = await usuarios.CountAsync();
            response.Items = await Ordering(filters, usuarios, !(bool)filters.Download!).ToListAsync();

            return response;
        }
    }
}