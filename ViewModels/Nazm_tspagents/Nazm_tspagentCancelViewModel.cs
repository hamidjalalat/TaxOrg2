using Domain.Anemic.Entities;
using Microsoft.EntityFrameworkCore;
using NazmMapping.Mappings;
using System;


namespace ViewModels.Nazm_tspagents
{
    public class Nazm_tspagentCancelViewModel : IMapFrom<Nazm_tspagent>
    {
        public int Id { get; set; }
     
    }
}
