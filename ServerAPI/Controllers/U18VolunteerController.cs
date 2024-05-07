using System;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Controllers;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/u18volunteer")]

public class U18VolunteerController : ControllerBase
{
    private IU18VolunteerRepository u18repo;
    
    
    public U18VolunteerController(IU18VolunteerRepository repo)
    {
        u18repo = repo;
    }

    [HttpPost]
    [Route("add")]
    public void insertOneU18Volunteer(U18Volunteer u18Volunteer)
    {
        u18repo.insertOneU18Volunteer(u18Volunteer);
    }
}