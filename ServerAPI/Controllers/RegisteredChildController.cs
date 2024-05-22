using System;
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

        [HttpGet]
        [Route("getallprio")]
        public IEnumerable<RegisteredChild> GetAllByPrio()
        {
            return rRepo.getAllItemsByPriority();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult insertOneItem(RegisteredChild registeredChild)
        {
            int count = rRepo.CountChildrenByKrævnr(registeredChild.Krævnr.Value);
            if (count >= 2)
            {
                return BadRequest("Du kan ikke registrere mere end 2 børn til børneklubben med samme Krævnr.");
            }

            rRepo.insertOneItem(registeredChild);
            return Ok("Barnet er registreret med succes.");        }
        
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
        [Route("csv")]
        public ActionResult DownloadByWeek(string assignedWeek)
        {
            var getByWeek = rRepo.FilterByAssignedWeek(assignedWeek);
            Console.WriteLine(assignedWeek);
            string csv =
                "Navn;Alder;Værge Navn;Værge Email;Værge TLF;Kommentar;Hobbier;Krævnr;Andelt Uge;Andelte Dage;Deltaget Før;Tøj Str;DatoTilføjet" + "\n";
            foreach (var child in getByWeek)
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

