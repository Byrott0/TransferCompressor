using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TransferCompressor.Server.DTO;
using TransferCompressor.Server.Models;
using Microsoft.IdentityModel.Tokens;
using TransferCompressor.Server.Services;

namespace TransferCompressor.Server.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuthController(IAuthService authService) : Controller {
   
   [HttpPost("Register")]
   public async Task<ActionResult<User>> Register(UserCreateDto request)
   {
      var user = await authService.RegisterAsync(request);
      if (user is null)
         return BadRequest("username already exists");
      return Ok(user);
   }

   [HttpPost("Login")]
   public async Task <ActionResult<string>> Login(UserCreateDto request)
   {
      var token = await authService.LoginAsync(request);
      if (token is null)
         return BadRequest("username or password is incorrect");
      return Ok(token);
   }
   
   [Authorize]
   [HttpGet]
   public IActionResult AuthenticationOnlyEndpoint()
   {
      return Ok("You are authenticated!");
   }
   
}