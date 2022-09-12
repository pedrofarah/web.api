using FluentValidation;
using PedroFarah.Web.Api.Domain.Queries;

namespace PedroFarah.Web.Api.Domain.Validators
{
    public class ProductListQueryValidator : AbstractValidator<ProductListQuery>
    {
        public ProductListQueryValidator()
        {
            RuleFor(x => x.OffSet).GreaterThanOrEqualTo(1).WithMessage("Deslocamento inválido. O valor deve ser maior que zero.");
            RuleFor(x => x.Records).GreaterThanOrEqualTo(1).WithMessage("Total de registros inválido. O valor deve ser maior que zero.");
        }
    }
}
