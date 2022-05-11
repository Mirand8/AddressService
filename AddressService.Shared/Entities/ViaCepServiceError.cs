using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AddressService.Shared.Services
{
    public class ViaCepServiceError
    {
        public ViaCepServiceError()
        {

        }

        public ViaCepServiceError(string message, HttpStatusCode? httpStatusCode)
        {
            Message = message;
            HttpStatusCode = httpStatusCode;
        }

        public string Message { get; set; }
        public HttpStatusCode? HttpStatusCode { get; set; }
    }
}
