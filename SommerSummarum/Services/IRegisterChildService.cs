using System;
using Core.Models;

namespace SommerSummarum.Services
{
	public interface IRegisterChildService
	{
        Task AddChildItem(RegisteredChild registeredChild);

        Task<RegisteredChild[]?> FilterByNewsletter();
        
        Task EditChildItem(RegisteredChild registeredChild);

        Task<RegisteredChild[]?> GetAllChildren();

    }
}

