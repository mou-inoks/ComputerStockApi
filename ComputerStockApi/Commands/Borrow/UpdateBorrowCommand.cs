using AutoMapper;
using ComputerStockApi.Commands.Computers;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using ComputerStockApi.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerStockApi.Commands.Borrow
{
    public class UpdateBorrowCommand : BorrowComputerDto, IRequest
    {
    }
    public class UpdateBorrowCommandHandler : IRequestHandler<UpdateBorrowCommand>
    {
        public readonly IMapper mapper;
        public readonly ComputerStockContext _context;
        public readonly IMediator mediator;

        public UpdateBorrowCommandHandler(IMapper map, IConfiguration config, IMediator med)
        {
            _context = new ComputerStockContext(config);
            mapper = map;
            mediator = med;
        }

        public async Task<Unit> Handle(UpdateBorrowCommand command, CancellationToken cancellationToken)
        {
            var borrowComputerDao = _context.BorrowComputer.Where(b => b.Id == command.Id).AsNoTracking().SingleOrDefault();

            mapper.Map(command, borrowComputerDao);

            var computer = new ComputerDto()
            {
                Id = command.Computer.Id,
                Name = command.Computer.Name,
                Type = command.Computer.Type,
                Brand = command.Computer.Brand,
                Processor = command.Computer.Processor,
                Ram = command.Computer.Ram,
                State = new StateDto() { Id = (int)ComputerStateEnum.InStock, State = "In Stock" },
            };


            // update the computer for the In Stock status 
            var cd = mapper.Map<UpdateComputerCommand>(computer);

            await mediator.Send(cd);

            var entry = _context.BorrowComputer.Entry(borrowComputerDao);

            entry.State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
