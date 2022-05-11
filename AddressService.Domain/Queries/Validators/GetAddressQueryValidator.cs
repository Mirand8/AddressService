using AddressService.Domain.Queries.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressService.Domain.Queries.Validators
{
    public class GetAddressQueryValidator : AbstractValidator<GetAddressQuery>
    {
        public GetAddressQueryValidator()
        {
            RuleFor(x => x.Cep).NotNull().WithMessage("Cep field is required!").
                                Must(pass => Regex.IsMatch(pass, @"^\d{5}-\d{3}$") ||
                                             Regex.IsMatch(pass, @"^\d{8}$"))
                                    .WithMessage("Invalid CEP!");
        }
    }
}
