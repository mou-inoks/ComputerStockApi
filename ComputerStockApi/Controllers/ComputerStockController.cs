using ComputerStockApi.Daos;
using ComputerStockApi.Data;
using ComputerStockApi.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ComputerStockApi.Dtos;
using ComputerStockApi.Query;
using AutoMapper;
using ComputerStockApi.Commands.Computers;
using ComputerStockApi.Querys;
using ComputerStockApi.Querys.Processor;
using ComputerStockApi.Querys.Computers;
using ComputerStockApi.Commands.Processor;
using ComputerStockApi.Querys.State;

namespace ComputerStockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerStockController : ControllerBase
    {
        private readonly ComputerStockContext _context;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public ComputerStockController(ComputerStockContext context, IMediator mediator, IMapper map )
        {
            _context = context;
            this.mediator = mediator;
            mapper = map;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComputerDto>>> GetComputers()
        {
            var request = new GetAllComputersQuery();

            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ComputerDto>> GetComputerById(int id )
        {
            var request = new GetComputerByIdQuery()
            {
                Id = id
            };
            var response = mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddComputer([FromBody]ComputerDto computer)
        {
            var command = mapper.Map<CreateComputersCommand>(computer);

            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<ComputerDto>>> DeleteComputer(int id)
        {
            var command = new DeleteComputerCommand()
            {
                Id = id
            };

            var response = await mediator.Send(command);    

            return Ok(response);
        }

        [HttpGet("processors")]
        public async Task<ActionResult<IEnumerable<ProcessorDto>>> GetProcessors()
        {
            var query = new GetAllProcessorsQuery();

            var response = await mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("processors/{id}")]
        public async Task<IActionResult> GetProcessorsById(int id)
        {
            var query = new GetProcessorByIdQuery()
            {
                Id = id
            };
            
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("processors")]
        public async Task<ActionResult<IEnumerable<ProcessorDto>>> AddProcessor([FromBody] ProcessorDto processor)
        {
            var command = mapper.Map<CreateProcessorCommand>(processor);

            var response = mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("processor/{id}")]
        public async Task<IActionResult> DeleteProcessor(int id)
        {
            var command = new DeleteProcessorCommand()
            {
                Id = id
            };

            var response = await mediator.Send(command);

            return Ok(response);

        }

        [HttpGet("state")]
        public async Task<ActionResult<IEnumerable<StateDto>>> GetStates()
        {
            var query = new GetAllStateQuery();

            var response = await mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("state/{id}")]
        public async Task<ActionResult<IEnumerable<StateDto>>> GetStateById(int id)
        {
            var query = mapper.Map<GetStateByIdQuery>(id);

            var response = await mediator.Send(query);

            return Ok(response);
        }

        [HttpPost("state")]
        public async Task<IActionResult> AddState(StateDao state)
        {
            var NState = new StateDao()
            {
                 State= state.State
            };

            await _context.State.AddAsync(NState);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("type")]
        public IEnumerable<ComputerTypeDao> GetType()
        {
            var request = _context.Set<ComputerTypeDao>().ToList();

            return request;
        }

        [HttpPost("type")]
        public async Task<IActionResult> addType(ComputerTypeDao type)
        {
            var NType = new ComputerTypeDao()
            {
                Type = type.Type
            };

            await _context.ComputerType.AddAsync(NType);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
