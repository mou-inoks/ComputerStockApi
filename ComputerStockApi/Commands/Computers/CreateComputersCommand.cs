using ComputerStockApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Daos;

namespace ComputerStockApi.Commands.Computers
{
    public class CreateComputersCommand : IRequest
    {
        public string Name { get; set; }
        public int TypeId{ get; set; }
        public string Brand { get; set; }
        public int ProcessorId { get; set; }
        public int Ram { get; set; }
        public int StateId { get; set; }
        public string Comment { get; set; }
    }
    public class CreateComputersCommandHandler : IRequestHandler<CreateComputersCommand>
    {
        private readonly IMapper mapper;
        private readonly ComputerStockContext _context;

        public CreateComputersCommandHandler(IMapper map, IConfiguration config)
        {
            _context = new ComputerStockContext(config);
            mapper = map;
        }

        public async Task<Unit> Handle(CreateComputersCommand command, CancellationToken cancellationToken)
        {
            var computerDao = mapper.Map<ComputerDao>(command);

            await _context.Computers.AddAsync(computerDao);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
