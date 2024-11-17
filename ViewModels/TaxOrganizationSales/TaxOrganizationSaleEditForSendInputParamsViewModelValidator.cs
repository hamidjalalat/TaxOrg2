using Domain.Anemic.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NazmMapping.Mappings;
using System;


namespace ViewModels.TaxOrganizationSales
{
    public class TaxOrganizationSaleEditForSendInputParamsViewModelValidator : AbstractValidator<TaxOrganizationSaleEditForSendInputParamsViewModel>
    {
        public TaxOrganizationSaleEditForSendInputParamsViewModelValidator()
        {
            RuleFor(I => I.FEE)
                   .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
                   .GreaterThanOrEqualTo(0).WithMessage(string.Format(Resources.Messages.Validations.GreaterThanOrEqualTo_FieldValue, ConstClass.PropertyName, 0))
                   .WithName(Resources.DataDictionary.FEE);
            
            RuleFor(I => I.INDATIM)
                   .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
                   //.MaximumLength(23).WithMessage(string.Format(Resources.Messages.Validations.MaxLength, ConstClass.PropertyName, 23))
                   .WithName(Resources.DataDictionary.indatim);
        }
    }
}
