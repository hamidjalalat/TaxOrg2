using FluentValidation;

namespace ViewModels.STATUS_COUNTs
{
    public class STATUS_COUNTInputParamsViewModelValidator : AbstractValidator<STATUS_COUNTInputParamsViewModel>
    {
        public STATUS_COUNTInputParamsViewModelValidator()
        {
            RuleFor(I => I.YEAR)
               .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
               .GreaterThanOrEqualTo(1402).WithMessage(string.Format(Resources.Messages.Validations.GreaterThanOrEqualTo_FieldValue, ConstClass.PropertyName, 1402))
               .WithName(Resources.DataDictionary.Year);
        }
    }
}
