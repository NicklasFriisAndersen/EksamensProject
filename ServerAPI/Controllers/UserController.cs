using System;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Controllers;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private IUserrepository uRepo;

    public UserController(IUserrepository repo)
    {
        uRepo = repo;
    }

    [HttpPost]
    [Route("add")]
    public void insertOneUser(User user)
    {
        uRepo.insertOneUser(user);
    }

    [HttpGet]
    [Route("getall")]
    public IEnumerable<User> GetAll()
    {
        return uRepo.GetAllUsers();
    }

    [HttpPost]
    [Route("update")]
    public void UpdateUserRole(User user)
    {
        uRepo.EditUserRole(user);
    }
}