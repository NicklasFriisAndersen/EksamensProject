using System;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ServerAPI.Controllers;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/login")]
public class LoginController : ControllerBase
{
    private readonly ILoginRepository _loginRepository;

    public LoginController(ILoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
    }

    [HttpGet("signin")]
    public IActionResult Login([FromQuery] string username, [FromQuery] string password)
    {
        if (_loginRepository.Verify(username, password))
        {
            var user = _loginRepository.GetUserByUserName(username);
            return Ok(user.ToJson());
        }
        else
        {
            return Unauthorized(new { Message = "Incorrect login" });
        }
    }
}