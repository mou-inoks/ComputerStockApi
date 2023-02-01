using ComputerStockApi.Data;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ComputerStockApi.Dtos;
using ComputerStockApi.Query;
using AutoMapper;
using ComputerStockApi.Commands.Borrow;
using ComputerStockApi.Commands.Computers;
using ComputerStockApi.Querys;
using ComputerStockApi.Querys.Processor;
using ComputerStockApi.Querys.Computers;
using ComputerStockApi.Commands.Processor;
using ComputerStockApi.Querys.State;
using ComputerStockApi.Commands.State;
using ComputerStockApi.Querys.Borrow;
using ComputerStockApi.Querys.Type;
using MediatRApi.Commands.User;
using MediatRApi.Querys.User;

namespace ComputerStockApi.Controllers
{
    [Route("api/computer-stock")]
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

        [HttpPost("update")]
        public async Task<ActionResult<ComputerDto>> UpdateComputer([FromBody] ComputerDto computer)
        {
            var command = mapper.Map<UpdateComputerCommand>(computer);

            var response = await mediator.Send(command);

            return Ok(response); 
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ComputerDto>> GetComputerById(int id )
        {
            var request = new GetComputerByIdQuery()
            {
                Id = id
            };
            var response = await mediator.Send(request);

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



    }
}
