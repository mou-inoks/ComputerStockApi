using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using ComputerStockApi.Models;
using MediatR;

namespace ComputerStockApi.Commands.State
{
    public class CreateStateCommand : StateDto, IRequest
    {
    }
    public class CreateStateCommandHandler : IRequestHandler<CreateStateCommand>
    {
        private readonly IMapper mapper;
        private readonly ComputerStockContext _context;

        public CreateStateCommandHandler(IMapper mapper, IConfiguration config)
        {
            this.mapper = mapper;
            _context = new ComputerStockContext(config);
        }

        public async Task<Unit> Handle(CreateStateCommand command, CancellationToken cancellationToken)
        {
            var dao = mapper.Map<StateDao>(command);

            await _context.State.AddAsync(dao);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }

     }
}
