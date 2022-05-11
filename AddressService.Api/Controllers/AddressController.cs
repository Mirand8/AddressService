
using AddressService.Domain.Queries.Requests;
using AddressService.Domain.Queries.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AddressService.Api.Controllers
{
    [Route("api/address/")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        [HttpGet("{cep}")]
        public async Task<ActionResult<GetAddressResponse>> Get(
            [FromServices] IMediator mediator,
            string cep)
        {
            CancellationToken cancellationToken = new();
            return await mediator.Send(new GetAddressQuery(cep), cancellationToken); ;
        }
    }
}
