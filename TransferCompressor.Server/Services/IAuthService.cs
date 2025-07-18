namespace TransferCompressor.Server.Services;

using TransferCompressor.Server.Models;
using TransferCompressor.Server.DTO;

public interface IAuthService
{
    Task<User?> RegisterAsync(UserCreateDto request);
    Task<string?> LoginAsync(UserCreateDto request);
}