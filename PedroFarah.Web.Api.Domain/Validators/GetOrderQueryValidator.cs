using FluentValidation;
using PedroFarah.Web.Api.Domain.Queries;

namespace PedroFarah.Web.Api.Domain.Validators
{
    public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
    {
        public GetOrderQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1).WithMessage("Código da venda inválido. O valor deve ser maior que zero.");
        }
    }
}
