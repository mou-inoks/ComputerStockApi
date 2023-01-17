using ComputerStockApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Daos;

namespace ComputerStockApi.Commands.Computers
{
    public class CreateComputersCommand : ComputerDto,IRequest
    {
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
            var dao = new ComputerDao()
            {
                Name = command.Name,
                StateId = command.State.Id,
                ProcessorId = command.Processor.Id,
                TypeId = command.Type.Id,
                Brand = command.Brand,
                Comment = command.Comment,
                Ram = command.Ram,
            };

            await _context.Computers.AddAsync(dao);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
