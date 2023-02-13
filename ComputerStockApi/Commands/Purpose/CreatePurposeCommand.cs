using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using ComputerStockApi.Models;
using MediatR;

namespace MediatRApi.Commands.Purpose;

public class CreatePurposeCommand : PurposeDto, IRequest
{
}

public class CreatePurposeComandHandler : IRequestHandler<CreatePurposeCommand>
{
    private readonly IMapper mapper;
    private readonly ComputerStockContext _context;

    public CreatePurposeComandHandler(IMapper map, IConfiguration conf)
    {
        _context = new ComputerStockContext(conf);
        mapper = map; 
    }

    public async Task<Unit> Handle(CreatePurposeCommand command, CancellationToken cancellationToken)
    {
        var dao = new PurposeDao()
        {
            Purpose = command.Purpose
        };
        await _context.Purpose.AddAsync(dao);

        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}