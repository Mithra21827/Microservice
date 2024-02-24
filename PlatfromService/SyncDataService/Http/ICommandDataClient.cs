using PlatfromService.Dto;

namespace PlatfromService.SyncDataService.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformCommand(PlatformReadDto plat);
    }
}
