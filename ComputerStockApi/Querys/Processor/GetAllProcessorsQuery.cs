using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ComputerStockApi.Querys
{
    public class GetAllProcessorsQuery : IRequest<IEnumerable<ProcessorDto>>
    {
    }

    public class GetAllProcessorsQueryHandler : IRequestHandler<GetAllProcessorsQuery, IEnumerable<ProcessorDto>>
    {
        private readonly IMapper mapper;
        private readonly ComputerStockContext _context;

        public GetAllProcessorsQueryHandler(IMapper mapper, IConfiguration conf)
        {
            _context = new ComputerStockContext(conf);
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProcessorDto>> Handle(GetAllProcessorsQuery request, CancellationToken cancellationToken)
        {
            var daos = await _context.Processor.ToListAsync();

            var dto = mapper.Map<IEnumerable<ProcessorDto>>(daos);

            return dto;
        }
    }
}
