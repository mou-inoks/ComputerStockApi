using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using ComputerStockApi.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ComputerStockApi.Querys.Borrow
{
    public class GetAllBorrowQuery : IRequest<IEnumerable<BorrowComputerDto>>
    {
    }

    public class GetAllBorrowQueryHandler : IRequestHandler<GetAllBorrowQuery, IEnumerable<BorrowComputerDto>>
    {
        private readonly IMapper mapper;
        private readonly ComputerStockContext _context;

        public GetAllBorrowQueryHandler(IMapper mapper, IConfiguration conf)
        {
            _context = new ComputerStockContext(conf);
            this.mapper = mapper;   
        }

        public async Task<IEnumerable<BorrowComputerDto>> Handle(GetAllBorrowQuery request, CancellationToken cancellationToken)
        {
            var daos = await _context.BorrowComputer
                .Include(c => c.Computer).ThenInclude(c => c.Type)
                .Include(c => c.Computer).ThenInclude(c => c.State)
                .Include(c => c.Computer).ThenInclude(c => c.Processor)
                .Include(c => c.User)
                .ToListAsync();

            var dto = mapper.Map<IEnumerable<BorrowComputerDto>>(daos);

            return dto;
        }
    }
}
