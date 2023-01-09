using AutoMapper;
using ComputerStockApi.Daos;
using ComputerStockApi.Dtos;

namespace ComputerStockApi.Quer 
{ 
    public class ComputerProfile : Profile
    {
        public ComputerProfile()
        {
            CreateMap<ComputerDao, ComputerDto>();
            CreateMap<ComputerDto, ComputerDao>();
        }
    }
}
