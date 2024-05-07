using System;
using Core.Models;

namespace ServerAPI.Repositories;

public interface IUserrepository
{
    public void insertOneUser(User user);
}