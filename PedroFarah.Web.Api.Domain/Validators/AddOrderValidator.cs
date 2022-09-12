using FluentValidation;
using PedroFarah.Web.Api.Domain.Commands;

namespace PedroFarah.Web.Api.Domain.Validators
{
    public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
    {
        public AddOrderCommandValidator()
        {
            RuleFor(x => x.DateTime).NotNull().WithMessage("Informe a data da venda.");
            RuleFor(x => x.PersonDocument).NotEmpty().WithMessage("Informe o número do documento.");
        }
    }
}
