using ComputerStockApi.Data;
using MediatR;

namespace ComputerStockApi.Commands.Type
{
    public class DeleteTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteTypeCommandHandler : IRequestHandler<DeleteTypeCommand>
    {
        private readonly ComputerStockContext _context;
        public DeleteTypeCommandHandler(IConfiguration config)
        {
            _context = new ComputerStockContext(config);
        }

        public async Task<Unit> Handle(DeleteTypeCommand command, CancellationToken cancellationToken)
        {
            var type = _context.ComputerType.FirstOrDefault(c => c.Id == command.Id);

            if (type == null)
                throw new Exception();
            else
            {

                _context.ComputerType.Remove(type);
                await _context.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
