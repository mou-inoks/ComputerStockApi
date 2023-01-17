using AutoMapper;
using ComputerStockApi.Dtos;
using ComputerStockApi.Models;

namespace ComputerStockApi.Querys.Type
{
    public class TypeProfile : Profile
    {
        public TypeProfile()
        {
            CreateMap<ComputerTypeDao, ComputerTypeDto>();
            CreateMap<ComputerTypeDto, ComputerTypeDao>();
        }
    }
}
