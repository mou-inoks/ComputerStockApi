using AutoMapper;
using ComputerStockApi.Daos;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using ComputerStockApi.Querys.Computers;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace ComputerStockApi.Commands.Computers;

public class UpdateComputerCommand : ComputerDto, IRequest
{
}

public class UpdateComputerCommandHandler : IRequestHandler<UpdateComputerCommand>
{
    public readonly IMapper mapper;
    public readonly ComputerStockContext _context;
    
    public UpdateComputerCommandHandler(IMapper map, IConfiguration config )
    {
        _context = new ComputerStockContext(config);
        mapper = map;
    }

    public async Task<Unit> Handle(UpdateComputerCommand command, CancellationToken cancellationToken)
    {
        var computerDao =  _context.Computers.Where(pro => pro.Id == command.Id).AsNoTracking().SingleOrDefault();

        mapper.Map(command, computerDao);

        var entry = _context.Computers.Entry(computerDao);

        entry.State = EntityState.Modified;

        await _context.SaveChangesAsync();
        
        return Unit.Value;
    }
}