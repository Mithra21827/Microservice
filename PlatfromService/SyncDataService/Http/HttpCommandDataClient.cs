using PlatfromService.Dto;
using System.Text;
using System.Text.Json;

namespace PlatfromService.SyncDataService.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendPlatformCommand(PlatformReadDto plat)
        {

            var httpContet = new StringContent(
                JsonSerializer.Serialize(plat),
                UTF8Encoding.UTF8,
                "application/json"
                );

            var response = await _httpClient.PostAsync(_configuration["CommandService"], httpContet);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sync Post to CommandService was Ok");
            }
            else
            {
                Console.WriteLine("Sync Post to CommandService was not Ok");
            }
            
        }
    }
}
