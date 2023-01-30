using ComputerStockApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Daos;
using ComputerStockApi.Models;

namespace MediatRApi.Commands.User;

public class CreateUserCommand : UserDto,IRequest
{
    
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IMapper mapper; 
    private readonly ComputerStockContext _context;

    public CreateUserCommandHandler(IMapper map, IConfiguration config)
    {
        _context = new ComputerStockContext(config);
        mapper = map;
    }

    public async Task<Unit> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var dao = new UserDao()
        {
            Name = command.Name,
        };

        await _context.Users.AddAsync(dao);

        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}