using System;
using Core.Models;
using MongoDB.Driver;

namespace ServerAPI.Repositories
{
	public interface IRegisteredChildRepository
	{
        public List<RegisteredChild> getAllItems();

        public List<RegisteredChild> getAllItemsByPriority();

        public void insertOneItem(RegisteredChild item);
        
        public List<RegisteredChild> FilterChildByKraevNummer(string kraevnr);

        public List<RegisteredChild> FilterByNewsletter();

        public void UpdateAssignedPeriod(RegisteredChild registeredChild);


    }
}

