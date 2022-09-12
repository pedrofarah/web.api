using FluentValidation;
using PedroFarah.Web.Api.Domain.Commands;

namespace PedroFarah.Web.Api.Domain.Validators
{
    public class AddOrderItemValidator : AbstractValidator<AddOrderItemCommand>
    {
        public AddOrderItemValidator()
        {
            string msgZero = "O valor deve ser maior do que zero.";
            RuleFor(x => x.OrderId).GreaterThanOrEqualTo(1).WithMessage($"Código da venda inválido. {msgZero}");
            RuleFor(x => x.ProductId).GreaterThanOrEqualTo(1).WithMessage($"Código do produto inválido. {msgZero}");
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(1).WithMessage($"Quantidade inválida. {msgZero}");
            RuleFor(x => x.UnitValue).GreaterThanOrEqualTo(1).WithMessage($"Valor unitário inválido. {msgZero}");
        }
    }
}
