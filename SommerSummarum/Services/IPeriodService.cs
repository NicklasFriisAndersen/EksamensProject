using Core.Models;

namespace SommerSummarum.Services
{
    public interface IPeriodService 
    {
        Task <List<Period>> GetAllPeriod();
    }
}
