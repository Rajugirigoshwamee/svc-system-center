using FluentValidation;
using svc.system.center.domain.Models.Dtos.V1.Public.Country;

namespace svc.system.center.domain.Validator.Country;

public class AddCountryDtoValidator : AbstractValidator<AddCountryDto>
{
    public AddCountryDtoValidator()
    {
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Code).NotNull();
    }
}
