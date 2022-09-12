using FluentValidation;
using PedroFarah.Web.Api.Domain.Queries;

namespace PedroFarah.Web.Api.Domain.Validators
{
    public class OrderListQueryValidator : AbstractValidator<OrderListQuery>
    {
        public OrderListQueryValidator()
        {
            string msgZero = "O valor deve ser maior do que zero.";
            RuleFor(x => x.OffSet).GreaterThanOrEqualTo(1).WithMessage($"Deslocamento inválido. {msgZero}");
            RuleFor(x => x.Records).GreaterThanOrEqualTo(1).WithMessage($"Total de registros inválido. {msgZero}");
            RuleFor(x => x.PersonDocument).Empty().WithMessage("Informe o documento do cliente.");
            RuleFor(x => x.StartDate).NotNull().WithMessage("Informe a data inicial.");
            RuleFor(x => x.EndDate).NotNull().WithMessage("Informe a data final.");
        }
    }
}
