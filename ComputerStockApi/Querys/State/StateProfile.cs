using AutoMapper;
using ComputerStockApi.Commands.State;
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
            CreateMap<CreateStateCommand, StateDto>();
            CreateMap<StateDto, CreateStateCommand>();
            
        }
    }
}
