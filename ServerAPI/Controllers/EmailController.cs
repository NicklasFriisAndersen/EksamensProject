using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;
using Core.Models;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/email")]
public class EmailController : ControllerBase
{
    private IEmailRepository eRepo;

    public EmailController(IEmailRepository eRepo)
    {
        this.eRepo = eRepo;
    }

    [HttpPost]
    [Route("update")]
    public void UpdateEmail(Email email)
    {
        eRepo.UpdateEmail(email);
    }

    [HttpPost]
    [Route("send")]
    public void SendEmail(List<RegisteredChild> children)
    {
        //noget hvor den sender til registeredchild.parentemail fra selected kolonne
    }
    
}