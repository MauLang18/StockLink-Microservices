using Microsoft.EntityFrameworkCore;
using StockLink.Auth.Domain.Entities;
using StockLink.Auth.Infrastructure.Commons.Bases.Request;
using StockLink.Auth.Infrastructure.Commons.Bases.Response;
using StockLink.Auth.Infrastructure.Persistences.Contexts;
using StockLink.Auth.Infrastructure.Persistences.Interfaces;

namespace StockLink.Auth.Infrastructure.Persistences.Repository
{
    public class UsuarioRepository : GenericRepository<TbUsuario>, IUsuarioRepository
    {
        private readonly UsuariosContext _context;
        public UsuarioRepository(UsuariosContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BaseEntityResponse<TbUsuario>> ListUsuarios(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<TbUsuario>();

            var usuarios = GetEntityQuery(x => x.Id != 0 && x.Username != null)
                .Include(x => x.RolNavigation)
                .AsNoTracking();

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        usuarios = usuarios.Where(x => x.Username!.Contains(filters.TextFilter));
                        break;
                }
            }

            if (filters.Sort is null) filters.Sort = "Id";

            response.TotalRecords = await usuarios.CountAsync();
            response.Items = await Ordering(filters, usuarios, !(bool)filters.Download!).ToListAsync();

            return response;
        }

        public async Task<TbUsuario> UserByUser(string users)
        {
            var user = await _context.TbUsuarios.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Username!.Equals(users));

            return user!;
        }
    }
}