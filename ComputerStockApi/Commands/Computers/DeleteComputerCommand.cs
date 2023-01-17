using ComputerStockApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Daos;

namespace ComputerStockApi.Commands.Computers
{
    public class DeleteComputerCommand : ComputerDto, IRequest
    {
    }
    public class DeleteComputerCommandHandler : IRequestHandler<DeleteComputerCommand>
    {
        private readonly IMapper mapper;
        private readonly ComputerStockContext _context;

        public DeleteComputerCommandHandler(IMapper map, IConfiguration config)
        {
            _context = new ComputerStockContext(config);
            mapper = map;
        }

        public async Task<Unit> Handle(DeleteComputerCommand request, CancellationToken cancellationToken)
        {
            var t = await _context.Computers.FindAsync(request.Id);

            _context.Computers.Remove(t);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
