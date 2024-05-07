﻿using System;
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
    }
}

