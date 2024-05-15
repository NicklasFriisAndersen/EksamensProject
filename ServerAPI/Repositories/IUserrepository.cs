using System;
using Core.Models;

namespace ServerAPI.Repositories;

public interface IUserrepository
{
    public void insertOneUser(User user);

    public List<User> GetAllUsers();

    public Task EditUserRole(User user);
}