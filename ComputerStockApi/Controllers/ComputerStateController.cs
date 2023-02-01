using AutoMapper;
using ComputerStockApi.Commands.State;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using ComputerStockApi.Querys.State;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStockApi.Controllers
{
    [Route("api/computer-state")]
    [ApiController]
    public class ComputerStateController : ControllerBase
    {
        private readonly ComputerStockContext _context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public ComputerStateController(ComputerStockContext context, IMapper map, IMediator mediator)
        {
            _context = context;
            mapper = map;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StateDto>>> GetStates()
        {
            var query = new GetAllStateQuery();

            var response = await mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<StateDto>>> GetStateById(int id)
        {
            var query = new GetStateByIdQuery()
            {
                Id = id
            };

            var response = await mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddState([FromBody] StateDto state)
        {
            var command = mapper.Map<CreateStateCommand>(state);

            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<StateDto>>> DeleteState(int id)
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
