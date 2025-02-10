using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace TransferCompressor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompressController: ControllerBase
    {

        private readonly IWebHostEnvironment _env;

        public CompressController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("compress")]
        public async Task<IActionResult> CompressVideo(IFormFile videoFile)
        {
            if (videoFile == null || videoFile.Length == 0)
            {
                return BadRequest("Geen video bestand ontvangen.");
            }

            // Pad voor uploads en output
            var uploadsPath = Path.Combine(_env.WebRootPath, "uploads");
            var compressedPath = Path.Combine(_env.WebRootPath, "compressed");
            Directory.CreateDirectory(uploadsPath);
            Directory.CreateDirectory(compressedPath);

            var inputFilePath = Path.Combine(uploadsPath, videoFile.FileName);
            var outputFilePath = Path.Combine(compressedPath, $"compressed_{videoFile.FileName}");

            // Sla het geüploade bestand op
            using (var stream = new FileStream(inputFilePath, FileMode.Create))
            {
                await videoFile.CopyToAsync(stream);
            }

            // Voer FFmpeg uit om de video te comprimeren
            var ffmpegCommand = $"-i \"{inputFilePath}\" -vcodec libx264 -crf 28 \"{outputFilePath}\"";
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "ffmpeg",
                    Arguments = ffmpegCommand,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            process.Start();
            await process.WaitForExitAsync();

            if (!System.IO.File.Exists(outputFilePath))
            {
                return StatusCode(500, "Compressie mislukt.");
            }

            // Stuur de gecomprimeerde video terug
            var fileBytes = await System.IO.File.ReadAllBytesAsync(outputFilePath);
            return File(fileBytes, "video/mp4", Path.GetFileName(outputFilePath));
        }
    }
}
