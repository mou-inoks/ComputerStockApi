using AutoMapper;
using ComputerStockApi.Commands.State;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using ComputerStockApi.Querys.Type;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStockApi.Controllers
{
    [Route("api/computer-type")]
    [ApiController]
    public class ComputerTypeController: ControllerBase
    {
        private readonly ComputerStockContext _context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public ComputerTypeController(ComputerStockContext context, IMapper map, IMediator mediator)
        {
            _context = context;
            mapper = map;
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComputerTypeDto>>> GetType()
        {
            var request = new GetAllTypesQuery();

            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddType([FromBody] ComputerTypeDto typeDto)
        {
            var command = mapper.Map<CreateStateCommand>(typeDto);

            var response = mediator.Send(command);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            var command = new DeleteStateCommand()
            {
                Id = id
            };

            var response = await mediator.Send(command);

            return Ok(response);
        }

    }
}
