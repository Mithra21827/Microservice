using PlatfromService.Models;

namespace PlatfromService.Data
{
    public interface IPlatformRepo
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatfroms();
        Platform GetPlatformById(int platId);
        void CreatePlatform(Platform platfrom);
    }
}
