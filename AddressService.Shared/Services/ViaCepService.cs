using AddressService.Shared.Entities;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AddressService.Shared.Services
{
    public class ViaCepService
    {
        readonly HttpClient _httpClient;

        public ViaCepService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ViaCepResponse> GetAddressAsync(string cep)
        {
            var addressResponse = new ViaCepResponse();
            try
            {
                var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json");
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                addressResponse = DeserializeJsonAddress(responseBody);
            }
            catch (HttpRequestException exception)
            {
                addressResponse.ServiceError = new ();
                addressResponse.ServiceError.HttpStatusCode = (HttpStatusCode) exception.StatusCode;
                if (addressResponse.ServiceError.HttpStatusCode is not null)
                {
                    if (addressResponse.ServiceError.HttpStatusCode == HttpStatusCode.NotFound)
                        addressResponse.ServiceError.Message = "No Address was found in this CEP!";

                    else if (addressResponse.ServiceError.HttpStatusCode == HttpStatusCode.InternalServerError)
                        addressResponse.ServiceError.Message = "Internal Error for ViaCEP Api!";
                }
            }
            _httpClient.Dispose();

            return addressResponse;
        }

        static ViaCepResponse DeserializeJsonAddress(string json) => JsonConvert.DeserializeObject<ViaCepResponse>(json);
    }
}
