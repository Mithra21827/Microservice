using AutoMapper;
using PlatfromService.Dto;
using PlatfromService.Models;
namespace PlatfromService.Profiles
{
    public class PlatformProfiles: Profile
    {
        public PlatformProfiles() {
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
        }
    }
}
