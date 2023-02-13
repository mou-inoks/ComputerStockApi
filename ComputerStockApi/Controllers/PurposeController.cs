using AutoMapper;
using ComputerStockApi.Commands.Borrow;
using ComputerStockApi.Commands.Computers;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using ComputerStockApi.Querys.Borrow;
using MediatR;
using MediatRApi.Commands.Purpose;
using MediatRApi.Querys.Purpose;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStockApi.Controllers;


    [Route("api/purpose")]
    [ApiController]
    
    public class PurposeController : ControllerBase 
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public PurposeController(IMediator mediator, IMapper map)
        {
            this.mediator = mediator;
            mapper = map;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurposeDto>>> GetPurpose()
        {
            var request = new GetAllPurposeQuery();

            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddPurpose([FromBody] PurposeDto purpose)
        {
            var command = mapper.Map<CreatePurposeCommand>(purpose);

            var response = await mediator.Send(command);
            
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurpose(int id)
        {
            var command = new DeletePurposeCommand()
            {
                Id = id
            };

            var response = await mediator.Send(command);

            return Ok(response);
        }
    }
