using FluentValidation;
using PedroFarah.Web.Api.Domain.Queries;

namespace PedroFarah.Web.Api.Domain.Validators
{
    public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1).WithMessage("Código do produto inválido. O valor deve ser maior do que zero.");
        }
    }
}
