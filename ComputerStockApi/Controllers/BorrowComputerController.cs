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
    public class BorrowComputerController : ControllerBase 
    {
        private readonly ComputerStockContext _context;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public BorrowComputerController(ComputerStockContext context, IMediator mediator, IMapper map)
        {
            _context = context;
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

            var computer = new ComputerDto()
            {
                Id = borrow.Computer.Id,
                State = new StateDto() { Id = 4, State = "Office" },
                Ram = borrow.Computer.Ram,
                Comment = borrow.Computer.Comment,
                Processor = borrow.Computer.Processor,
                Brand = borrow.Computer.Brand,
                Type = borrow.Computer.Type,
                Name = borrow.Computer.Name
            };

            var updateComputer = mapper.Map<UpdateComputerCommand>(computer);

            await mediator.Send(updateComputer);

            return Ok(response);
        }
    }
}
