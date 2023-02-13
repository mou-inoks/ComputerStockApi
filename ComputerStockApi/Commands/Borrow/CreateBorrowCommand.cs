using AutoMapper;
using ComputerStockApi.Commands.Computers;
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
            var dao = new BorrowComputerDao();
            if (command.ToDate == null)
            {
                dao = new BorrowComputerDao()
                {
                    FromDate = command.FromDate,
                    ToDate = command.ToDate,
                    UserId = command.User.Id,
                    ComputerId = command.Computer.Id,
                    Comment = command.Comment,
                };

                var computer = new ComputerDto()
                {
                    Id = command.Computer.Id,
                    Name = command.Computer.Name,
                    Type = command.Computer.Type,
                    Brand = command.Computer.Brand,
                    Processor = command.Computer.Processor,
                    Ram = command.Computer.Ram,
                    State = new StateDto(){ Id = }

                }

                var cd = mapper.Map<UpdateComputerCommand>(computer);
            }
            

            await _context.BorrowComputer.AddAsync(dao);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
