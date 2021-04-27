using API.Utilities;
using API.ViewModels;
using AutoMapper;
using Core.Execptions;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IitemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IitemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/itens/create")]
        public async Task<IActionResult> Create([FromForm] CreateViewModel itemviewmodel)
        {
            try
            {
                var itemDTO = _mapper.Map<ItemDTO>(itemviewmodel);
                var itemCreated = await _itemService.Create(itemDTO);

                return Ok(new ResultViewModel
                {
                    Message = "item Adicionado a WishList",
                    Success = true,
                    Data = itemCreated

                });

            }
            catch (DomainExecptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }


        [HttpPut]
        [Route("/api/v1/itens/update")]
        public async Task<IActionResult> Update([FromForm] UpdateViewModel updateViewModel)
        {
            try
            {
                var itemDTO = _mapper.Map<ItemDTO>(updateViewModel);
                var itemUpdate = await _itemService.Update(itemDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Item atualizado!",
                    Success = true,
                    Data = itemUpdate
                });
            }
            catch (DomainExecptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/users/get-item/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var item = await _itemService.Get(id);

                if (item == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum Item encontrado com o ID Digitado",
                        Success = true,
                        Data = item

                    });

                return Ok(new ResultViewModel
                {
                    Message = "Item encontrado!",
                    Success = true,
                    Data = item
                });
            }
            catch (DomainExecptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Route("/api/v1/itens/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _itemService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Item removido com sucesso!",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainExecptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/itens/random-item")]
        public async Task<IActionResult> RandomByItem()
        {
            try
            {
                var itemRandom = await _itemService.RandomByItem();

                return Ok(new ResultViewModel
                {
                    Message = "Retornando Item Randomico",
                    Success = true,
                    Data = itemRandom
                });

            }
            catch (DomainExecptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}