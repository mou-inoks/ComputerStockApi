using ComputerStockApi.Data;
using MediatR;

namespace ComputerStockApi.Commands.Processor
{
    public class DeleteProcessorCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteProcessorCommandHandler : IRequestHandler<DeleteProcessorCommand>
    {
        private readonly ComputerStockContext _context;

        public DeleteProcessorCommandHandler( IConfiguration config)
        {
            _context = new ComputerStockContext(config);
        }

        public async Task<Unit> Handle(DeleteProcessorCommand request, CancellationToken cancellationToken)
        {
            var processor = _context.Processor.FirstOrDefault(x => x.Id == request.Id);

            if (processor == null)
                throw new Exception();
            else
            {
                _context.Processor.Remove(processor);
                await _context.SaveChangesAsync();

            }

            return Unit.Value;
        }
    }
}
