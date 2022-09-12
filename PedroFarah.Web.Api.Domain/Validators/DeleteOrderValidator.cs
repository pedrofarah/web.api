using FluentValidation;
using PedroFarah.Web.Api.Domain.Commands;

namespace PedroFarah.Web.Api.Domain.Validators
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1).WithMessage("Código da venda inválido. O valor deve ser maior do que zero.");
        }
    }
}
