using AddressService.Domain.Queries.Responses;
using MediatR;

namespace AddressService.Domain.Queries.Requests
{
    public class GetAddressQuery : IRequest<GetAddressResponse>
    {
        public GetAddressQuery(string cep)
        {
            Cep = cep;
        }

        public string Cep { get; set; }
    }
}