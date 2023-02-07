using AutoMapper;
using ComputerStockApi.Dtos;
using ComputerStockApi.Models;
using MediatRApi.Commands.Purpose;

namespace MediatRApi.Querys.Purpose;

public class PurposeProfile : Profile
{
    public PurposeProfile()
    {
        CreateMap<PurposeDto, PurposeDao>();
        CreateMap<PurposeDao, PurposeDto>();
        
        CreateMap<CreatePurposeCommand, PurposeDto>();
        CreateMap<PurposeDto, CreatePurposeCommand>();

    }
}