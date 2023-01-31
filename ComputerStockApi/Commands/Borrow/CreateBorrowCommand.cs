using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using ComputerStockApi.Models;
using MediatR;

namespace ComputerStockApi.Commands.Borrow
{
    public class CreateBorrowCommand : BorrowComputerDto, IRequest
    {
    }

    public class CreateBorrowCommandHandler : IRequestHandler<CreateBorrowCommand>
    {
        private readonly IMapper mapper;
        private readonly ComputerStockContext _context;

        public CreateBorrowCommandHandler(IMapper map, IConfiguration conf)
        {
            _context = new ComputerStockContext(conf);
            mapper = map;
        }

        public async Task<Unit> Handle(CreateBorrowCommand command, CancellationToken cancellation)
        {
            var dao = new BorrowComputerDao()
            {
                FromDate = command.FromDate,
                ToDate = command.ToDate,
                UsersId = command.Users.Id,
                ComputersId = command.Computers.Id,
            };

            await _context.BorrowComputer.AddAsync(dao);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
