using FluentValidation;

namespace ViewModels.SERVICE_TYPEs
{
    public class SERVICE_TYPEViewModelValidator : AbstractValidator<SERVICE_TYPEViewModel>
    {
        public SERVICE_TYPEViewModelValidator()
        {
            RuleFor(I => I.SSTID)
               .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
               .GreaterThan(0).WithMessage(string.Format(Resources.Messages.Validations.GreaterThan_FieldValue, ConstClass.PropertyName, 1402))
               .WithName(Resources.DataDictionary.SSTT);

            RuleFor(I => I.SSTID)
               .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
               .WithName(Resources.DataDictionary.SSTID);

            RuleFor(I => I.VRA)
               .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
               .GreaterThanOrEqualTo(0).WithMessage(string.Format(Resources.Messages.Validations.GreaterThanOrEqualTo_FieldValue, ConstClass.PropertyName, 0))
               .WithName(Resources.DataDictionary.VRA);

            RuleFor(I => I.FIELDCODE)
               .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
               .GreaterThanOrEqualTo(0).WithMessage(string.Format(Resources.Messages.Validations.GreaterThanOrEqualTo_FieldValue, ConstClass.PropertyName, 0))
               .WithName(Resources.DataDictionary.FIELDCODE);
        }
    }
}
