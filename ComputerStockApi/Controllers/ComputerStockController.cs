using ComputerStockApi.Data;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ComputerStockApi.Dtos;
using ComputerStockApi.Query;
using AutoMapper;
using ComputerStockApi.Commands.Computers;
using ComputerStockApi.Querys;
using ComputerStockApi.Querys.Processor;
using ComputerStockApi.Querys.Computers;
using ComputerStockApi.Commands.Processor;
using ComputerStockApi.Querys.State;
using ComputerStockApi.Commands.State;
using ComputerStockApi.Querys.Type;
using MediatRApi.Commands.User;
using MediatRApi.Querys.User;

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

            var response = await mediator.Send(command);

            return Ok(response);
        }
        
        [HttpPost("processors/update")]
        public async Task<ActionResult<IEnumerable<ProcessorDto>>> UpdateProcessor([FromBody] ProcessorDto processor)
        {
            var command = mapper.Map<UpdateProcessorCommand>(processor);

            var response = await mediator.Send(command);

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
            var query = new GetStateByIdQuery()
            {
                Id = id
            };

            var response = await mediator.Send(query);

            return Ok(response);
        }

        [HttpPost("state")]
        public async Task<IActionResult> AddState([FromBody] StateDto state)
        {
            var command = mapper.Map<CreateStateCommand>(state);

            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("state/{id}")]
        public async Task<ActionResult<IEnumerable<StateDto>>> DeleteState(int id)
        {
            var command = new DeleteStateCommand()
            {
                Id = id
            };

            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("type")]
        public async Task<ActionResult<IEnumerable<ComputerTypeDto>>> GetType()
        {
            var request = new GetAllTypesQuery();

            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("type")]
        public async Task<IActionResult> AddType([FromBody] ComputerTypeDto typeDto)
        {
            var command = mapper.Map<CreateStateCommand>(typeDto);

            var response = mediator.Send(command);

            return Ok(response);
        }
        [HttpDelete("type/{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            var command = new DeleteStateCommand()
            {
                Id = id
            };

            var response = await mediator.Send(command);

            return Ok(response);
        }
        
        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var request = new GetAllUsersQuery();

            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("user/update")]
        public async Task<ActionResult<UserDto>> UpdateUsers([FromBody] UserDto user)
        {
            var command = mapper.Map<UpdateUserCommand>(user);

            var response = await mediator.Send(command);

            return Ok(response); 
        }

        [HttpGet("user/{id}")]

        public async Task<ActionResult<UserDto>> GetUserById(int id )
        {
            var request = new GetUserByIdQuery()
            {
                Id = id
            };
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("user")]
        public async Task<IActionResult> AddUser([FromBody]UserDto user)
        {
            var command = mapper.Map<CreateUserCommand>(user);

            var response = await mediator.Send(command);

            return Ok(response);
        }
        
          
        [HttpDelete("user/{id}")]
        public async Task<ActionResult<IEnumerable<ComputerDto>>> DeleteUser(int id)
        {
            var command = new DeleteUserCommand()
            {
                Id = id
            };

            var response = await mediator.Send(command);    

            return Ok(response);
        }
        
        
    }
}
