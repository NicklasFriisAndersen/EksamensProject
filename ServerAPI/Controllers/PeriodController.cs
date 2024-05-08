using System;
using ServerAPI.Repositories;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ServerAPI.Controllers
{
    [ApiController]
    [Route("api/period")]
    public class PeriodController : ControllerBase
	{
        private IPeriodRepository pRepo;

        public PeriodController(IPeriodRepository repo)
		{
            pRepo = repo;
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<Period> GetAll()
        {
            return pRepo.getAllItems();
        }
    }
}

