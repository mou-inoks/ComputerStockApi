using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ComputerStockApi.Querys.Computers
{
    public class GetComputerByIdQuery : IRequest<ComputerDto>
    {
        public int Id { get; set; }
    }

    public class GetComputerByIdQueryHandler : IRequestHandler<GetComputerByIdQuery ,ComputerDto>
    {
        private readonly IMapper mapper;
        private readonly ComputerStockContext _context;

        public GetComputerByIdQueryHandler(IMapper map, IConfiguration conf)
        {
            mapper = map;
            _context = new ComputerStockContext(conf);
        }

        public async Task<ComputerDto> Handle(GetComputerByIdQuery request, CancellationToken cancellationToken)
        {
            var computerDao = _context.Computers
                .Include(c => c.Processor)
                .Include(c => c.State)
                .Include(c => c.Type)
                .Where(c => c.Id == request.Id).AsNoTracking().SingleOrDefault();

            if (computerDao == null)
                throw new Exception();
            else
            {
                var dto = mapper.Map<ComputerDto>(computerDao);

                return dto;
            }
        }
    }
}
