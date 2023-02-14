using AutoMapper;
using ComputerStockApi.Commands.Borrow;
using ComputerStockApi.Commands.Computers;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using ComputerStockApi.Querys.Borrow;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStockApi.Controllers
{
    [Route("api/borrow")]
    [ApiController]
    public class BorrowComputerController : ControllerBase 
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public BorrowComputerController(IMediator mediator, IMapper map)
        {
            this.mediator = mediator;
            mapper = map;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetBorrow()
        {
            var request = new GetAllBorrowQuery();

            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddBorrow([FromBody] BorrowComputerDto borrow)
        {
            var command = mapper.Map<CreateBorrowCommand>(borrow);

            var response = await mediator.Send(command);
            
            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<ActionResult<BorrowComputerDto>> UpdateComputer([FromBody] BorrowComputerDto borrowComputer)
        {
            var command = mapper.Map<UpdateBorrowCommand>(borrowComputer);

            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpPost("return")]
        public async Task<ActionResult<BorrowComputerDto>> ReturnComputer([FromBody] BorrowComputerDto borrowComputer)
        {
            var command = mapper.Map<UpdateBorrowCommand>(borrowComputer);

            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<BorrowComputerDto>>> DeleteComputer(int id)
        {
            var command = new DeleteBorrowCommand()
            {
                Id = id
            };

            var response = await mediator.Send(command);

            return Ok(response);
        }
    }
}
