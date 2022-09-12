using FluentValidation;
using PedroFarah.Web.Api.Domain.Commands;

namespace PedroFarah.Web.Api.Domain.Validators
{
    public class DeleteOrderItemValidator : AbstractValidator<DeleteOrderItemCommand>
    {
        public DeleteOrderItemValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1).WithMessage("Código do item de venda inválido. O valor deve ser maior do que zero.");
        }
    }
}
