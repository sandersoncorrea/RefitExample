using Refit;
using System.Threading.Tasks;

namespace RefirExample
{
    public interface ICepApiService
    {
        [Get("/ws/{cep}/json")]
        Task<ViaCepResponse> GetAddressAsync(string cep);
    }
}
