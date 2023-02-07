using System.Collections;
using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatRApi.Querys.Purpose;

public class GetAllPurposeQuery : IRequest<IEnumerable<PurposeDto>>
{
}

public class GetAllPurposeQueryHandler : IRequestHandler<GetAllPurposeQuery, IEnumerable<PurposeDto>>
{
    private readonly IMapper mapper;
    private readonly ComputerStockContext _context;

    public GetAllPurposeQueryHandler(IMapper mapper, IConfiguration conf)
    {
        _context = new ComputerStockContext(conf);
        this.mapper = mapper;
    }
    public async Task<IEnumerable<PurposeDto>> Handle(GetAllPurposeQuery request, CancellationToken cancellationToken)
    {
        var daos = await _context.Purpose.ToListAsync();

        var dto = mapper.Map<IEnumerable<PurposeDto>>(daos);

        return dto;
    }
}