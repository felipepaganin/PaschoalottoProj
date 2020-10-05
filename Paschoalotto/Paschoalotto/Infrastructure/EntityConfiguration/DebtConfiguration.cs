using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paschoalotto.Model;


namespace Paschoalotto.Infrastructure.EntityConfiguration
{
    public class DebtConfiguration : IEntityTypeConfiguration<Debt>
    {
        public void Configure(EntityTypeBuilder<Debt> entity)
        {
            entity.ToTable("Debt", ApplicationDataContext.DEFAULT_SCHEMA);

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
                

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.CPF)
                .IsRequired()
                .HasMaxLength(17);

            entity.Property(e => e.Interest)
                .IsRequired()
                .IsUnicode(false);

            entity.Property(e => e.FineFee)
                .IsRequired()
                .IsUnicode(false);

        }
    }
}
