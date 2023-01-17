using AutoMapper;
using ComputerStockApi.Dtos;
using ComputerStockApi.Models;

namespace ComputerStockApi.Querys.State
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<StateDto, StateDao>();
            CreateMap<StateDao, StateDto>();
        }
    }
}
