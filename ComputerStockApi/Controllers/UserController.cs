using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using MediatR;
using MediatRApi.Commands.User;
using MediatRApi.Querys.User;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStockApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ComputerStockContext _context;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public UserController(ComputerStockContext context, IMediator mediator, IMapper map)
        {
            _context = context; 
            this.mediator = mediator;
            mapper = map; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var request = new GetAllUsersQuery();

            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<ActionResult<UserDto>> UpdateUsers([FromBody] UserDto user)
        {
            var command = mapper.Map<UpdateUserCommand>(user);

            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var request = new GetUserByIdQuery()
            {
                Id = id
            };
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDto user)
        {
            var command = mapper.Map<CreateUserCommand>(user);

            var response = await mediator.Send(command);

            return Ok(response);
        }


        [HttpDelete("{id}")]
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
