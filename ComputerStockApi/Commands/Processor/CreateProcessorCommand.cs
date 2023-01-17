using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using ComputerStockApi.Models;
using MediatR;

namespace ComputerStockApi.Commands.Processor
{
    public class CreateProcessorCommand : ProcessorDto, IRequest
    {
    }
    public class CreateProcessorCommandHandler : IRequestHandler<CreateProcessorCommand>
    {
        private readonly IMapper mapper;
        private readonly ComputerStockContext _context;

        public CreateProcessorCommandHandler(IMapper map, IConfiguration config)
        {
            _context = new ComputerStockContext(config);
            mapper = map;
        }

        public async Task<Unit> Handle(CreateProcessorCommand command, CancellationToken cancellationToken)
        {
            var dao = mapper.Map<ProcessorDao>(command);

            await _context.Processor.AddAsync(dao);
            
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
