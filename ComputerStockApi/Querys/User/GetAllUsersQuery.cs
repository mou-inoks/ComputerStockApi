using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatRApi.Querys.User;

public class GetAllUsersQuery: IRequest<IEnumerable<UserDto>>
{
}

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    private readonly IMapper mapper;
    private readonly ComputerStockContext _context; 

    public GetAllUsersQueryHandler(IMapper mapper, IConfiguration conf)
    {
        _context = new ComputerStockContext(conf);
        this.mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var daos = await _context.Users.ToListAsync();

        var dto = mapper.Map<IEnumerable<UserDto>>(daos);

        return dto;
    }
}