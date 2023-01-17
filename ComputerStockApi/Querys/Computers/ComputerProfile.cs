using AutoMapper;
using ComputerStockApi.Commands.Computers;
using ComputerStockApi.Daos;
using ComputerStockApi.Dtos;
using ComputerStockApi.Models;

namespace ComputerStockApi.Query
{ 
    public class ComputerProfile : Profile
    {
        public ComputerProfile()
        {
            CreateMap<ComputerDao, ComputerDto>();
            CreateMap<ComputerTypeDao, ComputerTypeDto>();
            CreateMap<ProcessorDao, ProcessorDto>();
            CreateMap<StateDao, StateDto>();
            CreateMap<CreateComputersCommand, ComputerDao>();
            CreateMap<CreateComputersCommand, ComputerDto>();

        }
    }
}
