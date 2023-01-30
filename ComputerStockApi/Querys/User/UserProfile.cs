using AutoMapper;
using ComputerStockApi.Dtos;
using ComputerStockApi.Models;
using MediatRApi.Commands.User;

namespace MediatRApi.Querys.User;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDao, UserDto>();
        CreateMap<UserDto, UserDao>();
        CreateMap<CreateUserCommand, UserDto>();
        CreateMap<UserDto, CreateUserCommand>();
        CreateMap<UserDto, DeleteUserCommand>();
        CreateMap<DeleteUserCommand, UserDto>();
        CreateMap<UpdateUserCommand, UserDto>();
        CreateMap<UserDto, UpdateUserCommand>();
    }
    
}