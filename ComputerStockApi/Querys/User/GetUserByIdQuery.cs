using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace MediatRApi.Querys.User;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public int Id { get; set; }
}

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IMapper mapper;
    private readonly ComputerStockContext _context;

    public GetUserByIdQueryHandler(IMapper map, IConfiguration conf)
    {
        mapper = map;
        _context = new ComputerStockContext(conf);
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var userDao = _context.Users.Where(c => c.Id == request.Id).AsNoTracking().SingleOrDefault();

        if (userDao == null)
            throw new Exception();
        else
        {
            var dto = mapper.Map<UserDto>(userDao);

            return dto;
        }
    }
}