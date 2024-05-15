using Core.Models;

namespace ServerAPI.Repositories;

public interface IEmailRepository
{
    public Task UpdateEmail(Email email);

    public Task SendEmails(List<RegisteredChild> children);
}