using Cinema.Domains.Models;

namespace Cinema.Service.Contracts.Services
{
    public interface IDataTableFilterService
    {
        Task<Dictionary<string, List<LookUpModel>>> GetEntities(IServiceProvider serviceProvider, string[] entities);
    }
}