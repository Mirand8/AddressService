using AddressService.Shared.Entities;
using AddressService.Shared.Services;

namespace AddressService.Domain.Queries.Responses
{
    public class GetAddressResponse
    {
        public GetAddressResponse()
        {

        }

        public GetAddressResponse(ViaCepResponse response)
        {
            Cep = response.Cep;
            Street = response.Street;
            Complement = response.Complement;
            District = response.District;
            City = response.City;
            UF = response.UF;
        }

        public string Cep { get; set; }
        public string Street { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
    }
}