using PlatfromService.Models;

namespace PlatfromService.Data
{
    public class PlatfromRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatfromRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreatePlatform(Platform platfrom)
        {
            if (platfrom != null)
            {
                var model = _context.platforms.Add(platfrom);
            }
            else {
                throw new ArgumentNullException();
            }
        }

        public IEnumerable<Platform> GetAllPlatfroms()
        {
            return _context.platforms.ToList();
        }

        public Platform GetPlatformById(int platId)
        {
            return _context.platforms.FirstOrDefault(p => p.Id == platId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
