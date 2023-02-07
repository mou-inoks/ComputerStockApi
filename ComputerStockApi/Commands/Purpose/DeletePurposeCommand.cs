using ComputerStockApi.Data;
using MediatR;

namespace MediatRApi.Commands.Purpose;

public class DeletePurposeCommand : IRequest
{
    public int Id { get; set; }
}

public class DeletePurposeCommandHandler : IRequestHandler<DeletePurposeCommand>
{
    private readonly ComputerStockContext _context;

    public DeletePurposeCommandHandler(IConfiguration config)
    {
        _context = new ComputerStockContext(config);
    }

    public async Task<Unit> Handle(DeletePurposeCommand command, CancellationToken cancellationToken)
    {
        var purpose = _context.Purpose.FirstOrDefault(pur => pur.Id == command.Id);

        if (purpose == null)
            throw new Exception();
        else
        {
            _context.Purpose.Remove(purpose);
            await _context.SaveChangesAsync();
        }

        return Unit.Value;
    }
}