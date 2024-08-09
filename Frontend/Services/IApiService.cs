

using Frontend.Models;

namespace Frontend.Services
{
    public interface IApiService
    {
        Task<List<MsStorageLocation>> GetLocationsAsync();
        Task<bool> CreateBpkbAsync(TrBpkb bpkb);
        Task<bool> LoginAsync(Login login);
    }
}
