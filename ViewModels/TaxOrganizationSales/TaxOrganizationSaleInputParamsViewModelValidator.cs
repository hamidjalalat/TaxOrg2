using Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Shared;

namespace ViewModels.TaxOrganizationSales
{
    public class TaxOrganizationSaleInputParamsViewModelValidator : AbstractValidator<TaxOrganizationSaleInputParamsViewModel>
    {
        public TaxOrganizationSaleInputParamsViewModelValidator()
        {
            //RuleFor(Y => Y.Inno)
            //          .GreaterThan(0).WithMessage(string.Format(Resources.Messages.Validations.GreaterThan_FieldValue, ConstClass.PropertyName, 0))
            //          .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
            //          .WithName(Resources.DataDictionary.INNO);

            //RuleFor(v => v.Bid)
            //   .Matches(Domain.Constants.ValidationConstant.NationalCodePattern)
            //   .WithName(Resources.DataDictionary.NationalCode)
            //   .WithMessage(string.Format(Resources.Messages.Validations.InvalidValue, ConstClass.PropertyName))
            //   ;
        }

    }
}
