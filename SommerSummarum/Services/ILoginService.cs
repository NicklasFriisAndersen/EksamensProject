using Core.Models;

namespace SommerSummarum.Services;

public interface ILoginService
{ 
    Task HandleLogin(string username, string password);
}