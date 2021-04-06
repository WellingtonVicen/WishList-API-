using System.Linq;
using Infra.Context;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {

        private readonly ItemContext _context;

        public BaseRepository() { }

        public BaseRepository(ItemContext context)
        {
            _context = context;
        }
        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Get(long id)
        {
            var obj = await _context.Set<T>()
                    .AsNoTracking()
                    .Where(x => x.Id == id)
                    .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task Remove(long id)
        {
            var obj = await Get(id);

            if(obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<T> Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }
    }
}