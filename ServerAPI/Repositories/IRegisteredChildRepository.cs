using System;
using Core.Models;

namespace ServerAPI.Repositories
{
	public interface IRegisteredChildRepository
	{
        public List<RegisteredChild> getAllItems();

        public void insertOneItem(RegisteredChild item);
        
        public List<RegisteredChild> FilterChildByKraevNummer(string kraevnr);


        public List<RegisteredChild> FilterByNewsletter();
    }
}

