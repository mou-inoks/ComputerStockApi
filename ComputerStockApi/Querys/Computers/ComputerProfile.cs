using AutoMapper;
using ComputerStockApi.Commands.Borrow;
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
            CreateMap<ComputerDto, ComputerDao>();
            CreateMap<ComputerTypeDao, ComputerTypeDto>();
            CreateMap<ProcessorDao, ProcessorDto>();
            CreateMap<StateDao, StateDto>();
            CreateMap<CreateComputersCommand, ComputerDao>();
            CreateMap<CreateComputersCommand, ComputerDto>();
            CreateMap<ComputerDto, CreateComputersCommand>();
            CreateMap<ComputerDao, UpdateComputerCommand>();
            CreateMap<UpdateComputerCommand, ComputerDao>();
            CreateMap<UpdateComputerCommand, ComputerDto>();
            CreateMap<ComputerDto, UpdateComputerCommand>();
            CreateMap<UpdateBorrowCommand, ComputerDao>();
            CreateMap<ComputerDao, UpdateBorrowCommand>();


        }
    }
}
