using System;
using ServerAPI.Repositories;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ServerAPI.Controllers
{
    [ApiController]
    [Route("api/registeredchildren")]
    public class RegisteredChildController : ControllerBase
    {
        private IRegisteredChildRepository rRepo;

        public RegisteredChildController(IRegisteredChildRepository repo)
		{
            rRepo = repo;
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<RegisteredChild> GetAll()
        {
            return rRepo.getAllItems();
        }

        [HttpPost]
        [Route("add")]
        public void insertOneItem(RegisteredChild registeredChild)
        {
            rRepo.insertOneItem(registeredChild);
        }
        
        [HttpGet]
        [Route("getbykraevnr")]
        public IEnumerable<RegisteredChild> GetAllByKraevnr([FromQuery] string kraevnr)
        {
            return rRepo.FilterChildByKraevNummer(kraevnr);
        }

        [HttpPost]
        [Route("edit")]
        public void editOneItem(RegisteredChild registeredChild)
        {
            rRepo.UpdateAssignedPeriod(registeredChild);
        }
    }
}

