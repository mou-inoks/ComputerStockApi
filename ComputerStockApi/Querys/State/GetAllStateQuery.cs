using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using ComputerStockApi.Models;
using MediatR;

namespace ComputerStockApi.Querys.State
{
    public class GetAllStateQuery : IRequest<IEnumerable<StateDto>>
    {
    }

    public class GetAllStateQueryHandler : IRequestHandler<GetAllStateQuery, IEnumerable<StateDto>>
    {
        private readonly IMapper mapper;
        private readonly ComputerStockContext _context;

        public GetAllStateQueryHandler(IMapper mapper, IConfiguration conf)
        {
            _context = new ComputerStockContext(conf);
            this.mapper = mapper;
        }

        public async Task<IEnumerable<StateDto>> Handle(GetAllStateQuery request, CancellationToken cancellationToken)
        {
            var daos = _context.Set<StateDao>().ToList();

            var dto = mapper.Map<IEnumerable<StateDto>>(daos);

            return dto;
        }
    }
}
