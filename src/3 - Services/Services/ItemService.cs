using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Infra.Interfaces;
using Services.DTO;
using Core.Execptions;
using Services.Interfaces;
using System.IO;
using System;


namespace Services.Services
{
    public class ItemService : IitemService
    {

        private readonly IMapper _mapper;
        private readonly IitemRepository _itemRepository;

        public ItemService(IMapper mapper, IitemRepository itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        public async Task<ItemDTO> Create(ItemDTO itemDTO)
        {
            var itemExists = await _itemRepository.GetTitle(itemDTO.Title);
            string unifiqueFileName = null;
            if (itemExists != null)
                throw new DomainExecptions("Já existe o item cadastrado na  de lista de desejos com o titulo informado.");



            if (itemDTO.Photos != null)
            {
                string uploadFolder = Path.Combine(@"", Directory.GetCurrentDirectory());
                unifiqueFileName = Guid.NewGuid().ToString() + "_" + itemDTO.Photos.FileName;
                string filePath = Path.Combine(uploadFolder, unifiqueFileName);
                itemDTO.PhotoUrl = filePath;

            }

            var item = _mapper.Map<Item>(itemDTO);
            item.Validate();

            var itemCreated = await _itemRepository.Create(item);

            return _mapper.Map<ItemDTO>(itemCreated);


        }
        public async Task<ItemDTO> Update(ItemDTO itemDTO)
        {
            var itemExists = await _itemRepository.GetTitle(itemDTO.Title);
            string unifiqueFileName = null;
            if (itemExists != null)
                throw new DomainExecptions("Já existe o item cadastrado na  de lista de desejos com o titulo informado.");


            if (itemDTO.Photos != null)
            {
                string uploadFolder = Path.Combine(@"", Directory.GetCurrentDirectory());
                unifiqueFileName = Guid.NewGuid().ToString() + "_" + itemDTO.Photos.FileName;
                string filePath = Path.Combine(uploadFolder, unifiqueFileName);
                itemDTO.PhotoUrl = filePath;

            }

            var item = _mapper.Map<Item>(itemDTO);
            item.Validate();

            var itemCreated = await _itemRepository.Update(item);

            return _mapper.Map<ItemDTO>(itemCreated);

        }

        public async Task<ItemDTO> Get(long id)
        {
            var item = await _itemRepository.Get(id);

            return _mapper.Map<ItemDTO>(item);
        }

        public Task<ItemDTO> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ItemDTO>> RandomByItem()
        {
            var itemRandom = await _itemRepository.RandomByItem();

            return _mapper.Map<List<ItemDTO>>(itemRandom);
        }

        public async Task Remove(long id)
        {
            var itemExists = await _itemRepository.Get(id);
            
            if(itemExists != null)
                await _itemRepository.Remove(id);
            else
             throw new DomainExecptions("ID não Encontrado");
        }

      
    }
}