using FluentValidation;

namespace ViewModels.TaxOrganizationSales
{
    public class TaxOrganizationSaleCreateViewModelValidator : AbstractValidator<TaxOrganizationSaleCreateViewModel>
    {
        public TaxOrganizationSaleCreateViewModelValidator()
        {
            RuleFor(I => I.INDATIM.ToString())
                  .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
                  .MaximumLength(23).WithMessage(string.Format(Resources.Messages.Validations.MaxLength, ConstClass.PropertyName, 23))
                  .WithName(Resources.DataDictionary.indatim);

            RuleFor(I => I.INNO)
                   .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
                   .WithName(Resources.DataDictionary.INNO);

            RuleFor(I => I.FEE)
                   .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
                   .GreaterThanOrEqualTo(0).WithMessage(string.Format(Resources.Messages.Validations.GreaterThanOrEqualTo_FieldValue, ConstClass.PropertyName, 0))
                   .WithName(Resources.DataDictionary.FEE);

            RuleFor(I => I.VRA)
                   .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
                   .GreaterThanOrEqualTo(0).WithMessage(string.Format(Resources.Messages.Validations.GreaterThanOrEqualTo_FieldValue, ConstClass.PropertyName, 0))
                   .LessThanOrEqualTo(100).WithMessage(string.Format(Resources.Messages.Validations.GreaterThanOrEqualTo_FieldValue, ConstClass.PropertyName, 100))
                   .WithName(Resources.Messages.Validations.Vra);

            RuleFor(I => I.TINS)
                   .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
                   .WithName(Resources.Messages.Validations.Tins);

            RuleFor(I => I.SSTT)
                   .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
                   .MaximumLength(400).WithMessage(string.Format(Resources.Messages.Validations.MaxLength, ConstClass.PropertyName, 400))
                   .WithName(Resources.Messages.Validations.Sstt);

            RuleFor(I => I.SSTID)
                   .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
                   .MaximumLength(13).WithMessage(string.Format(Resources.Messages.Validations.MaxLength, ConstClass.PropertyName, 13))
                   .WithName(Resources.Messages.Validations.Sstid);

            RuleFor(I => I.BID)
                   .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
                   .WithName(Resources.Messages.Validations.Bid);

            RuleFor(I => I.BPC)
                  .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
                  .MaximumLength(10).WithMessage(string.Format(Resources.Messages.Validations.MaxLength, ConstClass.PropertyName, 10))
                  .WithName(Resources.Messages.Validations.Bpc);

            RuleFor(I => I.POLICY_NO)
                  .MaximumLength(100).WithMessage(string.Format(Resources.Messages.Validations.MaxLength, ConstClass.PropertyName, 100))
                  .WithName(Resources.Messages.Validations.Address);

            RuleFor(I => I.YEAR)
                   .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
                   .GreaterThanOrEqualTo(1402).WithMessage(string.Format(Resources.Messages.Validations.GreaterThanOrEqualTo_FieldValue, ConstClass.PropertyName, 1402))
                   .LessThanOrEqualTo(1500).WithMessage(string.Format(Resources.Messages.Validations.GreaterThanOrEqualTo_FieldValue, ConstClass.PropertyName, 1500))
                   .WithName(Resources.DataDictionary.Year);

            RuleFor(I => I.DIS)
                   .GreaterThanOrEqualTo(0).WithMessage(string.Format(Resources.Messages.Validations.GreaterThanOrEqualTo_FieldValue, ConstClass.PropertyName, 0))
                   .WithName(Resources.DataDictionary.FEE);
        }
    }
}
