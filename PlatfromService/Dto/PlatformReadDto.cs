using System.ComponentModel.DataAnnotations;

namespace PlatfromService.Dto
{
    public class PlatformReadDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Publisher { get; set; }
        public string? Cost { get; set; }
    }
}
