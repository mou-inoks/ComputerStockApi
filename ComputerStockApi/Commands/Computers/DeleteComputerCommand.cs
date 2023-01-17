using ComputerStockApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Daos;

namespace ComputerStockApi.Commands.Computers
{
    public class DeleteComputerCommand : IRequest
    {
        public int Id { get; set; }
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
            var computer = _context.Computers.FirstOrDefault(x => x.Id == request.Id);

            if (computer == null)
                throw new Exception();
            else
            {
                _context.Computers.Remove(computer);
                await _context.SaveChangesAsync();

            }

            return Unit.Value;
        }
    }
}
