using AddressService.Domain.Queries.Responses;
using AddressService.Domain.Queries.Validators;
using AddressService.Shared.Services;
using MediatR;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AddressService.Domain.Queries.Requests
{
    public class GetAddressHandler : IRequestHandler<GetAddressQuery, GetAddressResponse>
    {
        public async Task<GetAddressResponse> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var requestValidation = new GetAddressQueryValidator();
            var addressResponse = new GetAddressResponse();

            if (requestValidation.Validate(request).IsValid)
            {
                // Gets Via Cep Service Response
                var viaCepService = new ViaCepService();
                var serviceResponse = await viaCepService.GetAddressAsync(request.Cep);

                // Map service response to an Address response 
                addressResponse = new GetAddressResponse(serviceResponse);
            }

            return addressResponse;
        }
    }
}
