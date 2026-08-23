using EmergencyCart.Domain.AccountContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencyCart.Infrastructure.SharedContext.Data.Mappings;

public class EmergencyCartMapping : IEntityTypeConfiguration<EmergencyCart.Domain.AccountContext.Entities.EmergencyCart>
{
    public void Configure(EntityTypeBuilder<Domain.AccountContext.Entities.EmergencyCart> builder)
    {
        #region Table
        builder.ToTable("EmergencyCart");
        builder.HasKey(cart => cart.Id)
            .HasName("PK_EmergencyCart");
        #endregion

        #region Column
        builder.Property(cart => cart.Code)
            .HasColumnName("Code")
            .HasColumnType("VARCHAR")
            .HasMaxLength(25)
            .IsRequired(true);

        builder.Property(cart => cart.Location)
            .HasColumnName("Location")
            .HasColumnType("VARCHAR")
            .HasMaxLength(25)
            .IsRequired(true);

        builder.Property(cart => cart.IsActive)
           .HasColumnName("IsActive")
           .HasColumnType("BIT")
           .IsRequired(true);
        #endregion
    }
}
