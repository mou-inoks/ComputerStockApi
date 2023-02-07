using AutoMapper;
using ComputerStockApi.Commands.Borrow;
using ComputerStockApi.Dtos;
using ComputerStockApi.Models;

namespace ComputerStockApi.Querys.Borrow
{
    public class BorrowProfile : Profile
    {
        public BorrowProfile()
        {
            CreateMap<BorrowComputerDao, BorrowComputerDto>();
            CreateMap<BorrowComputerDto, BorrowComputerDao>();
            CreateMap<CreateBorrowCommand, BorrowComputerDao>();
            CreateMap<BorrowComputerDao, CreateBorrowCommand>();
            CreateMap<BorrowComputerDto, CreateBorrowCommand>();
            CreateMap<CreateBorrowCommand, BorrowComputerDto>();
            CreateMap<BorrowComputerDto, UpdateBorrowCommand>();
            CreateMap<UpdateBorrowCommand, BorrowComputerDto>();
            CreateMap<BorrowComputerDao, UpdateBorrowCommand>();
            CreateMap<UpdateBorrowCommand, BorrowComputerDao>();
        }
    }
}
