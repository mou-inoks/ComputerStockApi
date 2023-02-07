using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
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

        public UpdateBorrowCommandHandler(IMapper map, IConfiguration config)
        {
            _context = new ComputerStockContext(config);
            mapper = map;
        }

        public async Task<Unit> Handle(UpdateBorrowCommand command, CancellationToken cancellationToken)
        {
            var borrowComputerDao = _context.BorrowComputer.Where(b => b.Id == command.Id).AsNoTracking().SingleOrDefault();

            mapper.Map(command, borrowComputerDao);

            var entry = _context.BorrowComputer.Entry(borrowComputerDao);

            entry.State = EntityState.Modified;

            await _context.SaveChangesAsync();


            return Unit.Value;
        }
    }
}
