using AutoMapper;
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
        }
    }
}
