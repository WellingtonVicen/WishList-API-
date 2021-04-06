using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infra.Interfaces
{
    public interface IitemRepository : IBaseRepository<Item>
    {
        Task<List<Item>> RandomByItem();
        Task<Item> GetTitle(string title);
        
    }
}