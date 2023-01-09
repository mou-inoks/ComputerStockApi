using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ComputerStockApi.Quer
{
    public class GetAllComputersQuery : IRequest<IEnumerable<ComputerDto>>
    {
    }

    public class GetAllComputersQueryHandler : IRequestHandler<GetAllComputersQuery, IEnumerable<ComputerDto>>
    {
        private readonly IMapper mapper;
        private readonly ComputerStockContext _context; 

        public GetAllComputersQueryHandler(IMapper mapper)
        {
            _context = new ComputerStockContext();
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ComputerDto>> Handle(GetAllComputersQuery request, CancellationToken cancellationToken)
        {
            var daos = await _context.Computers.ToListAsync();

            var dto = mapper.Map<IEnumerable<ComputerDto>>(daos);

            return dto;
        }
    }
}
