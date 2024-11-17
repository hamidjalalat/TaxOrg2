﻿using Domain.Anemic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations.Anemic.Contexts
{
    public class OracleContext : DbContext
    {
        public OracleContext(DbContextOptions<OracleContext> options) : base(options: options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<TAX_ORGANIZATION_SALE> TAX_ORGANIZATION_SALES { get; set; }
        public DbSet<STATUS_COUNT> STATUS_COUNT { get; set; }
        public DbSet<SERVICE_TYPE> SERVICE_TYPE { get; set; }
    }
}
