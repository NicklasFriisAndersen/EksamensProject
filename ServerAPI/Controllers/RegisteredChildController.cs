﻿using System;
using ServerAPI.Repositories;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text;

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


        [HttpGet]
        [Route("getbynewsletter")]
        public IEnumerable<RegisteredChild> FilterByNewsletter()
        {
            return rRepo.FilterByNewsletter();
        }

        [HttpPost]
        [Route("edit")]
        public void editOneItem(RegisteredChild registeredChild)
        {
            rRepo.UpdateAssignedPeriod(registeredChild);
        }

        [HttpGet]
        [Route("allcsv")]
        public ActionResult DownloadAll()
        {
            var allChildren = rRepo.getAllItems();
            string csv =
                "Navn;Alder;Værge Navn;Værge Email;Værge TLF;Kommentar;Hobbier;Krævnr;Andelt Uge;Andelte Dage;Deltaget Før;Tøj Str;DatoTilføjet" + "\n";
            foreach (var child in allChildren)
            {
                csv += child.Name + ";" + child.Age + ";" + child.ParentName + ";" + child.ParentEmail + ";" +
                       child.ParentPhoneNumber + ";" + child.Comment + ";" + child.Hobbies + ";" + child.Krævnr + ";" +
                       child.AssignedPeriod.Week + ";" + child.AssignedPeriod.Days + ";" + child.BeenBefore + ";" +
                       child.ClothingSize + ";" + child.DateAdded + "\n";
            }
            //bliver lavet fra string til UTF-8 encodede bytes
            var csvBytes = Encoding.UTF8.GetBytes(csv);
            //en stream er en måde at håndtere bytes, og her ligger vi det i serveren
            var stream = new MemoryStream(csvBytes);
            var result = new FileStreamResult(stream, "text/csv");
            result.FileDownloadName = "Børneregistreringer.csv";
            return result;
        }
    }
}

