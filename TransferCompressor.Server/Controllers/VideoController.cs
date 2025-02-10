using TransferCompressor.Server.Services;
using Microsoft.AspNetCore.Mvc;
using TransferCompressor.Server.Models;
using TransferCompressor.Server.DTO;
using TransferCompressor.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TransferCompressor.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
   
    public class VideoController : ControllerBase
    {
        public readonly VideoService _videoService;


        public VideoController(VideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPost]
        public async Task<ActionResult<Video>> AddVideo([FromBody] VideoDTO videoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _videoService.AddVideoAsync(videoDTO.fileNaam, videoDTO.OriginalFilePad, videoDTO.OriginalFileSize, videoDTO.userId);
            return CreatedAtAction(nameof(GetAllVideos), new { id = videoDTO.Id }, videoDTO);
        }


        [HttpGet]
            public async Task<ActionResult<IEnumerable<Video>>> GetAllVideos()
        {
            var videos = await _videoService.GetAllVideosAsync();
            if (videos == null)
            {
                return NotFound();
            }
            return Ok(videos);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideoById(Guid id)
        {
            var video = await _videoService.GetVideoByIdAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            return Ok(video);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVideoById(Guid id)
        {
            var video = await _videoService.GetVideoByIdAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            await _videoService.DeleteVideoAsync(id);
            return NoContent();
        }
    }
}