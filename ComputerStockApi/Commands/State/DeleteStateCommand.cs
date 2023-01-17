using ComputerStockApi.Data;
using MediatR;

namespace ComputerStockApi.Commands.State
{
    public class DeleteStateCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteStateCommandHandler : IRequestHandler<DeleteStateCommand>
    {
        private readonly ComputerStockContext _context;
        public DeleteStateCommandHandler(IConfiguration config)
        {
            _context = new ComputerStockContext(config);
        }

        public async Task<Unit> Handle(DeleteStateCommand command, CancellationToken cancellationToken)
        {
            var stateDao = _context.State.FirstOrDefault(c => c.Id == command.Id);

            if (stateDao == null)
                throw new Exception();
            else
            {

                _context.State.Remove(stateDao);
                await _context.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
