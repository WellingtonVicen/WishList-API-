using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IitemRepository
    {

        private readonly ItemContext _context;

        public ItemRepository(ItemContext context) : base(context)
        {
            _context = context;
        }
        public virtual async Task<List<Item>> RandomByItem()
        {
            var random = new Random();
            int toSkip = random.Next(0, _context.Itens.Count());

            var item = await _context.Itens
                .OrderBy(x => Guid.NewGuid())
                .Skip(toSkip)
                .Take(1)
                .ToListAsync();

                return item;
        }
        public virtual async Task<Item> GetTitle(string title)
        {
             var item = await _context.Itens
                .Where
                (
                    x =>
                        x.Title.ToLower() == title.ToLower()
                )
                .AsNoTracking()
                .ToListAsync();

                return item.FirstOrDefault();



        }

    }
}