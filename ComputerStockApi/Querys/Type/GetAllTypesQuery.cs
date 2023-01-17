using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using ComputerStockApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerStockApi.Querys.Type
{
    public class GetAllTypesQuery : IRequest<IEnumerable<ComputerTypeDto>>
    {
    }

    public class GetAllTypesQueryHandler : IRequestHandler<GetAllTypesQuery, IEnumerable<ComputerTypeDto>>
    {
        private readonly IMapper mapper;
        private readonly ComputerStockContext _context;

        public GetAllTypesQueryHandler(IMapper map, IConfiguration config)
        {
            mapper = map;
            _context = new ComputerStockContext(config);
        }

        public async Task<IEnumerable<ComputerTypeDto>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var daos =  _context.Set<ComputerTypeDao>().ToList();

            var dtos = mapper.Map<IEnumerable<ComputerTypeDto>>(daos);

            return dtos;
        } 
    }
}
