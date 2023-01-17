using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ComputerStockApi.Querys.Processor
{
    public class GetProcessorByIdQuery : IRequest<ProcessorDto>
    {
        public int Id { get; set; }
    }
    public class GetProcessorByIdQueryHandler : IRequestHandler<GetProcessorByIdQuery, ProcessorDto>
    {
        private readonly IMapper mapper;
        private readonly ComputerStockContext _context;

        public GetProcessorByIdQueryHandler(IMapper map, IConfiguration conf)
        {
            mapper = map;
            _context = new ComputerStockContext(conf);
        }

        public async Task<ProcessorDto> Handle(GetProcessorByIdQuery request, CancellationToken cancellationToken)
        {
            var dao =  _context.Processor.Where(pro => pro.Id == request.Id).AsNoTracking().SingleOrDefault();

            if (dao == null)
                throw new Exception();
            else
            {
                var dto = mapper.Map<ProcessorDto>(dao);

                return dto;
            }
        }
    }
}
