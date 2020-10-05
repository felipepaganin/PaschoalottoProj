using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paschoalotto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paschoalotto.Infrastructure.EntityConfiguration
{
    public class DebtInstallmentsConfiguration : IEntityTypeConfiguration<DebtInstallments>
    {
        public void Configure(EntityTypeBuilder<DebtInstallments> entity)
        {
            entity.ToTable("DebtInstallments", ApplicationDataContext.DEFAULT_SCHEMA);

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.DueDate).HasColumnType("datetime");

            entity.Property(e => e.Price)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
        }
    }
}