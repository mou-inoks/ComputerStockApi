using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ComputerStockApi.Query
{
    public class GetAllComputersQuery : IRequest<IEnumerable<ComputerDto>>
    { 
    }

    public class GetAllComputersQueryHandler : IRequestHandler<GetAllComputersQuery, IEnumerable<ComputerDto>>
    {
        private readonly IMapper mapper;
        private readonly ComputerStockContext _context; 

        public GetAllComputersQueryHandler(IMapper mapper, IConfiguration conf)
        {
            _context = new ComputerStockContext(conf);
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ComputerDto>> Handle(GetAllComputersQuery request, CancellationToken cancellationToken)
        {
            var daos = await _context.Computers
                .Include(c => c.Processor)
                .Include(c => c.State)
                .Include(c => c.Type)
                .ToListAsync();

            var dto = mapper.Map<IEnumerable<ComputerDto>>(daos);

            return dto;
        }
    }
}
