using Microsoft.AspNetCore.Mvc;
using TransferCompressor.Server.Services;
using TransferCompressor.Server.Models;
using TransferCompressor.Server.DTO;
using System;

namespace TransferCompressor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // Maak een nieuwe gebruiker aan
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserCreateDto userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdUser = await _userService.AddUserAsync(userDTO);
                return StatusCode(200, "success!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Interne serverfout: {ex.Message}");
            }
        }


        // Haal een gebruiker op via ID
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("Gebruiker niet gevonden.");
            }
            return Ok(user);
        }

        // Haal alle gebruikers op
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // Haal video's van een gebruiker op (HOTFIX! kijk userService.cs)
        /*[HttpGet("{id}/videos")]
        public async Task<ActionResult<IEnumerable<Video>>> GetVideosByUser(User id)
        {
            var videos = await _userService.GetVideosByUserAsync(id);
            return Ok(videos);
        }*/

        // Werk een gebruiker bij
        //[HttpPut]
        //public async Task<IActionResult> UpdateUser([FromBody] UserCreateDto userDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        await _userService.UpdateUserAsync(userDTO.userId, userDTO.Email, userDTO.Password);
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Interne serverfout: {ex.Message}");
        //    }
        //}

        // Verwijder een gebruiker
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(Guid id)
        //{
        //    var user = await _userService.GetUserByIdAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound("Gebruiker niet gevonden.");
        //    }

        //    await _userService.DeleteUserAsync(id);
        //    return NoContent();
        //}
    }
}