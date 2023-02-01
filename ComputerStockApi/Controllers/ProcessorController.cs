using AutoMapper;
using ComputerStockApi.Commands.Processor;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using ComputerStockApi.Querys;
using ComputerStockApi.Querys.Processor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStockApi.Controllers
{
    [Route("api/processor")]
    [ApiController]
    public class ProcessorController : ControllerBase
    {
        private readonly ComputerStockContext _context;
        private readonly IMapper mapper; 
        private readonly IMediator mediator;

        public ProcessorController(ComputerStockContext context, IMapper map, IMediator mediator)
        {
            _context = context;
            mapper = map; 
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcessorDto>>> GetProcessors()
        {
            var query = new GetAllProcessorsQuery();

            var response = await mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProcessorsById(int id)
        {
            var query = new GetProcessorByIdQuery()
            {
                Id = id
            };

            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProcessorDto>>> AddProcessor([FromBody] ProcessorDto processor)
        {
            var command = mapper.Map<CreateProcessorCommand>(processor);

            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<ActionResult<IEnumerable<ProcessorDto>>> UpdateProcessor([FromBody] ProcessorDto processor)
        {
            var command = mapper.Map<UpdateProcessorCommand>(processor);

            var response = await mediator.Send(command);

            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcessor(int id)
        {
            var command = new DeleteProcessorCommand()
            {
                Id = id
            };

            var response = await mediator.Send(command);

            return Ok(response);
        }

    }
}
