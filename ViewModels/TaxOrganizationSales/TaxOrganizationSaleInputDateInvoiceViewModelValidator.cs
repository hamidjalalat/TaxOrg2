using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.TaxOrganizationSales
{
    public class TaxOrganizationSaleInputDateInvoiceViewModelValidator : AbstractValidator<TaxOrganizationSaleInputDateInvoiceViewModel>
    {
        public TaxOrganizationSaleInputDateInvoiceViewModelValidator()
        {
            RuleFor(I => I.Year)
               .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
               .GreaterThanOrEqualTo(1402).WithMessage(string.Format(Resources.Messages.Validations.GreaterThanOrEqualTo_FieldValue, ConstClass.PropertyName, 1402))
               .WithName(Resources.DataDictionary.Year);
        }
    }
}
