using AutoMapper;
using OnePieceApi.Entities;
using OnePieceApi.Models.Dtos;

namespace OnePieceApi.Models.Mappers;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserRegisterDto, User>();
    }
}