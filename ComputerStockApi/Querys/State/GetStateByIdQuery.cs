using AutoMapper;
using ComputerStockApi.Data;
using ComputerStockApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ComputerStockApi.Querys.State
{
    public class GetStateByIdQuery : IRequest<StateDto>
    {
        public int Id { get; set; }
    }

    public class GetStateByIdQueryHandler : IRequestHandler<GetStateByIdQuery, StateDto>
    {
        private readonly IMapper mapper;
        private readonly ComputerStockContext _context; 

        public GetStateByIdQueryHandler(IMapper map, IConfiguration conf)
        {
            mapper = map;
            _context = new ComputerStockContext(conf);
        }

        public async Task<StateDto> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
        {
            var stateDao = _context.State.Where(c => c.Id == request.Id).AsNoTracking().SingleOrDefault();

            if (stateDao == null)
                throw new Exception();
            else
            {
                var dto = mapper.Map<StateDto>(stateDao);

                return dto;
            }
        }
    }
}
