using Domain.Anemic.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NazmMapping.Mappings;
using System;


namespace ViewModels.Nazm_tspagents
{
    public class Nazm_tspagentEditForSendViewModelValidator : AbstractValidator<Nazm_tspagentEditForSendViewModel>
    {
        public Nazm_tspagentEditForSendViewModelValidator()
        {
            RuleFor(I => I.indatim.ToString())
            .NotEmpty().WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName))
            .MaximumLength(23).WithMessage(string.Format(Resources.Messages.Validations.MaxLength, ConstClass.PropertyName, 23))
            .WithName(Resources.DataDictionary.indatim);
        }
    }
}
