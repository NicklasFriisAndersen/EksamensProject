using System;
using Core.Models;

namespace SommerSummarum.Services
{
	public interface IRegisterChildService
	{
        Task<HttpResponseMessage> AddChildItem(RegisteredChild registeredChild);

        Task<RegisteredChild[]?> FilterByNewsletter();
        
        Task EditChildItem(RegisteredChild registeredChild);

        Task<RegisteredChild[]?> GetAllChildren();

        Task<RegisteredChild[]?> GetAllChildrenPrioSort();
        
        public Task<RegisteredChild[]> FilterByKraew(string kraewnummer);

    }
}

