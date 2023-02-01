using AutoMapper;
using ComputerStockApi.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerStockApi.Commands.Borrow
{
    public class DeleteBorrowCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteBorrowCommandHandler : IRequestHandler<DeleteBorrowCommand>
    {
        public readonly ComputerStockContext _context;
        public readonly IMapper mapper;

        public DeleteBorrowCommandHandler(ComputerStockContext context, IMapper map)
        {
            _context = context;
            mapper = map;
        }

        public async Task<Unit> Handle(DeleteBorrowCommand command, CancellationToken cancellation)
        {
            var borrowDao = _context.BorrowComputer.Where(b => b.Id == command.Id).AsNoTracking().SingleOrDefault();

            if (borrowDao == null)
                throw new Exception();
            else
            {
                _context.BorrowComputer.Remove(borrowDao);

                await _context.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
