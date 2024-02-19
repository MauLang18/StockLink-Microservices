using StockLink.Auth.Infrastructure.Persistences.Contexts;
using StockLink.Auth.Infrastructure.Persistences.Interfaces;

namespace StockLink.Auth.Infrastructure.Persistences.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UsuariosContext _context;

        public IUsuarioRepository Usuario { get; private set; }
        public IRolRepository Rol { get; private set; }

        public UnitOfWork(UsuariosContext context)
        {
            _context = context;
            Usuario = new UsuarioRepository(_context);
            Rol = new RolRepository(_context); ;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}