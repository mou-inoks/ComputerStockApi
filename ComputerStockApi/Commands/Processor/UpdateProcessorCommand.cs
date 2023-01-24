using ComputerStockApi.Dtos;
using MediatR;
using AutoMapper;
using ComputerStockApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ComputerStockApi.Commands.Processor;

public class UpdateProcessorCommand : ProcessorDto, IRequest
{
}

public class UpdateProcessorCommandHandler : IRequestHandler<UpdateProcessorCommand>
{
    public readonly IMapper mapper;
    public readonly ComputerStockContext _context;
    
    public UpdateProcessorCommandHandler(IMapper map, IConfiguration config )
    {
        _context = new ComputerStockContext(config);
        mapper = map;
    }

    public async Task<Unit> Handle(UpdateProcessorCommand command, CancellationToken cancellationToken)
    {
        var processorDao =  _context.Processor.Where(pro => pro.Id == command.Id).AsNoTracking().SingleOrDefault();

        mapper.Map(command, processorDao);

        var entry = _context.Processor.Entry(processorDao);

        entry.State = EntityState.Modified;

        await _context.SaveChangesAsync();
        
        return Unit.Value;
    }
}