using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using ComputerStockApi.Models;
using MediatR;

namespace ComputerStockApi.Commands.Type
{
    public class CreateTypeCommand : ComputerTypeDto, IRequest
    {
    }
    public class CreateTypeCommandHandler : IRequestHandler<CreateTypeCommand>
    {
        private readonly IMapper mapper;
        private readonly ComputerStockContext _context;

        public CreateTypeCommandHandler(IMapper mapper, IConfiguration config)
        {
            this.mapper = mapper;
            _context = new ComputerStockContext(config);
        }

        public async Task<Unit> Handle(CreateTypeCommand command, CancellationToken cancellationToken)
        {
            var dao = mapper.Map<ComputerTypeDao>(command);

            await _context.ComputerType.AddAsync(dao);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }

    }
}
