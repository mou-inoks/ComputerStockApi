using ComputerStockApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Daos;

namespace MediatRApi.Commands.User;

public class DeleteUserCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IMapper mapper;
    private readonly ComputerStockContext _context;

    public DeleteUserCommandHandler(IMapper map, IConfiguration config)
    {
        _context = new ComputerStockContext(config);
        mapper = map;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userDao = _context.Users.FirstOrDefault(x => x.Id == request.Id);

        if (userDao == null)
            throw new Exception();
        else
        {
            _context.Users.Remove(userDao);
            await _context.SaveChangesAsync();

        }

        return Unit.Value;
    }
}