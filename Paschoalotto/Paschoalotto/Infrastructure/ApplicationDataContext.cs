using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Paschoalotto.Infrastructure.EntityConfiguration;
using Paschoalotto.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Paschoalotto.Infrastructure
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
        }

        public const string DEFAULT_SCHEMA = "paschoalotto";

        public virtual DbSet<Debt> Debts { get; set; }
        public virtual DbSet<DebtInstallments> DebtInstallments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DebtConfiguration());
            modelBuilder.ApplyConfiguration(new DebtInstallmentsConfiguration());
        }
    }
}