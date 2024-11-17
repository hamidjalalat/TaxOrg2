using Domain.Anemic.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NazmMapping.Mappings;
using System;


namespace ViewModels.Nazm_tspagents
{
    public class Nazm_tspagentCancelViewModelValidator : AbstractValidator<Nazm_tspagentEditForSendViewModel>
    {
        public Nazm_tspagentCancelViewModelValidator()
        {
            RuleFor(I => I.id)

            .GreaterThan(0)
            .WithName(Resources.DataDictionary.Id)
            .WithMessage(string.Format(Resources.Messages.Validations.Required, ConstClass.PropertyName));
        }
    }
}
