using System.Collections.Generic;
using System.Threading.Tasks;
using Services.DTO;

namespace Services.Interfaces
{
    public interface IitemService
    {
        Task<ItemDTO> Create(ItemDTO itemDTO);
        Task<ItemDTO> Update(ItemDTO itemDTO);
        Task Remove(long id);
        Task<ItemDTO> Get(long id);
        Task<List<ItemDTO>> RandomByItem();
        
    }
}