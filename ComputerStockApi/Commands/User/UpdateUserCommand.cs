using AutoMapper;
using ComputerStockApi.Daos;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using ComputerStockApi.Querys.Computers;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace MediatRApi.Commands.User;

public class UpdateUserCommand : UserDto, IRequest
{
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    public readonly IMapper mapper;
    public readonly ComputerStockContext _context;
    
    public UpdateUserCommandHandler(IMapper map, IConfiguration config )
    {
        _context = new ComputerStockContext(config);
        mapper = map;
    }

    public async Task<Unit> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var userDao =  _context.Users.Where(pro => pro.Id == command.Id).AsNoTracking().SingleOrDefault();

        mapper.Map(command, userDao);

        var entry = _context.Users.Entry(userDao);

        entry.State = EntityState.Modified;

        await _context.SaveChangesAsync();
        
        return Unit.Value;
    }
}