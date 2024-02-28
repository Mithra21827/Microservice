using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatfromService.Data;
using PlatfromService.Dto;
using PlatfromService.Models;
using PlatfromService.SyncDataService.Http;

namespace PlatfromService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformController(IPlatformRepo repository, IMapper mapper,
            ICommandDataClient commandDataClient)
        {
            _mapper = mapper;
            _repository = repository;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]

        public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms()
        {
            Console.WriteLine("Getting Platforms...");
            var platformItems = _repository.GetAllPlatfroms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }

        [HttpGet("{Id}", Name = "GetElementByID")]

        public ActionResult<PlatformReadDto> GetElementByID(int id)
        {
            var platformItem = _repository.GetPlatformById(id);

            if (platformItem != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDto);

            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();
            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

            try
            {
                await _commandDataClient.SendPlatformCommand(platformReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send Synchronously: {ex.Message}");
            }
            return CreatedAtRoute(nameof(GetElementByID), new { Id = platformModel.Id }, platformModel);
        }

    }
}
