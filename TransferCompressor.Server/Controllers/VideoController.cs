using TransferCompressor.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace TransferCompressor.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly VideoService _videoService;

        public VideoController(VideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPost]



        [HttpGet]



        [HttpGet("{id}")]



        [HttpPut]



        [HttpDelete]


    }
}
