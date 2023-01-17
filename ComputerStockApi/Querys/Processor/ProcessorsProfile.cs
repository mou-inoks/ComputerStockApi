using AutoMapper;
using ComputerStockApi.Commands.Computers;
using ComputerStockApi.Daos;
using ComputerStockApi.Dtos;
using ComputerStockApi.Models;


namespace ComputerStockApi.Querys.Processor
{
    public class ProcessorsProfile : Profile
    {
        public ProcessorsProfile()
        {
            CreateMap<ProcessorDao, ProcessorDto>();
            CreateMap<ProcessorDto, ProcessorDao>();
        }

    }
}
