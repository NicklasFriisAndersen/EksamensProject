using Core.Models;

namespace SommerSummarum.Services;

public interface ILoginService
{
    public Task<User?> LoginAsync(string username, string password);
}