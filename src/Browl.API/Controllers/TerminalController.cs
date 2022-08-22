using AutoMapper;
using Browl.API.Utilities;
using Browl.Application.Interface;
using Browl.Application.Resources;
using Browl.Application.ViewModels;
using Browl.Core.Exceptions;
using Browl.Domain.Enums;
using Browl.Domain.Models;
using Browl.Domain.Notifications;
using Browl.Domain.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Browl.API.Controllers
{
    [ApiController]
    [Route("/api/register/[controller]")]
    [Produces("application/json")]
    public class TerminalController : MainController
    {

        private readonly ITerminalAppService _terminalAppService;
        private readonly IMapper _mapper;

        public TerminalController(ITerminalAppService terminalAppService,
             IMapper mapper,
            INotifier notificador) : base(notificador)
        {
            _terminalAppService = terminalAppService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IEnumerable<Terminal>> GetAll()
        {
            return await _terminalAppService.GetAllTerminals();

        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Terminal>> GetById(Guid id)
        {

            try
            {
                var terminal = await _terminalAppService.GetById(id);

                if(terminal == null)
                {
                    return NotFound();
                }

                return Ok(new ResultViewModel
                {
                    Message = "The model found with sucesso!",
                    Success = true,
                    Data = terminal
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }


        }

        [HttpPost]
        public async Task<ActionResult<Terminal>> Create(Terminal terminal)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return CustomResponse(ModelState);
                }
                await _terminalAppService.Create(terminal);

                return Ok(new ResultViewModel
                {
                    Message = "Terminal Created Success!",
                    Success = true,
                    Data = terminal
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult<Terminal>> Adicionar(Terminal terminal)
        {

            try
            {
                if(!ModelState.IsValid)
                {
                    NotifyError("Model State is InValid ");
                    return CustomResponse(ModelState);
                }
                await _terminalAppService.Create(terminal);

                return Ok(new ResultViewModel
                {
                    Message = "Terminal Created Success!",
                    Success = true,
                    Data = terminal
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Terminal>> Update(Guid id, Terminal terminalViewModel)
        {
            try
            {
                if(id != terminalViewModel.Id)
                {
                    NotifyError("The ids are not equal!!");
                    return CustomResponse(terminalViewModel);
                }

                if(!ModelState.IsValid)
                {
                    NotifyError("Model State is InValid ");
                    return CustomResponse(ModelState);
                }

                await _terminalAppService.Update(_mapper.Map<Terminal>(terminalViewModel));

                return Ok(new ResultViewModel
                {
                    Message = "Terminal Updated Success!",
                    Success = true,
                    Data = terminalViewModel
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Terminal>> Excluir(Guid id)
        {
            var terminal = await _terminalAppService.GetById(id);

            if(terminal == null)
            {
                NotifyError("The ids not can be null!");
                return NotFound();
            }

            await _terminalAppService.DeleteById(id);

            return CustomResponse(terminal);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Terminal>>> Search(string name, EStatus? status)
        {
            try
            {
                var result = await _terminalAppService.Search(name, status);

                if(result.Any())
                {
                    return Ok(result);
                }
                NotifyError("Not found!");
                return NotFound();
            }
            catch(Exception ex)
            {
                NotifyError("Error retrieving data? from the database");

                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database {ex.Message}");
            }
        }

        [HttpGet("GetAllDeleted")]
        public async Task<ActionResult<IEnumerable<Terminal>>> GetAllDeleted()
        {

            try
            {
                var result = await _terminalAppService.GetAllDeleted();

                return Ok(new ResultViewModel
                {
                    Message = "Terminal found success!",
                    Success = true,
                    Data = result
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }


        /// <summary>
        /// Lists all existing terminals.
        /// </summary>
        /// <returns>List of terminals.</returns>
        [HttpGet("resource")]
        [ProducesResponseType(typeof(QueryResultResource<TerminalResource>), 200)]
        public async Task<QueryResultResource<TerminalResource>> ListAsync([FromQuery] ProductsQueryResource query)
        {
            var productsQuery = _mapper.Map<ProductsQueryResource, TerminalsQuery>(query);

            var queryResult = await _terminalAppService.ListAsync(productsQuery);

            var resource = _mapper.Map<QueryResult<Terminal>, QueryResultResource<TerminalResource>>(queryResult);
            return resource;


        }
    }

}
