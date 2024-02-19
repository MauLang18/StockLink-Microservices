﻿using Microsoft.EntityFrameworkCore;
using StockLink.Auth.Domain.Entities;
using StockLink.Auth.Infrastructure.Commons.Bases.Request;
using StockLink.Auth.Infrastructure.Helpers;
using StockLink.Auth.Infrastructure.Persistences.Interfaces;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using StockLink.Auth.Infrastructure.Persistences.Contexts;

namespace StockLink.Auth.Infrastructure.Persistences.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly UsuariosContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(UsuariosContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var getAll = await _entity
                .AsNoTracking()
                .ToListAsync();

            return getAll;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var getById = await _entity!
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            return getById!;
        }

        public async Task<bool> RegisterAsync(T entity)
        {
            await _context.AddAsync(entity);

            var recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }

        public async Task<bool> EditAsync(T entity)
        {
            _context.Update(entity);

            var recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T entity = await GetByIdAsync(id);

            _context.Remove(entity);

            var recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity;

            if (filter != null) query = query.Where(filter);

            return query;
        }

        public IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class
        {
            IQueryable<TDTO> queryDto = request.Order == "desc" ? queryable.OrderBy($"{request.Sort} descending") : queryable.OrderBy($"{request.Sort} ascending");

            if (pagination) queryDto = queryDto.Paginate(request);

            return queryDto;
        }
    }
}