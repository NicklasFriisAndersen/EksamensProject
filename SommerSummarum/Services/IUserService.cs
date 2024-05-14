
using Core.Models;

namespace SommerSummarum.Services
{
public interface IUserService
    {
        Task AddUser(User userItem);
    }
}
