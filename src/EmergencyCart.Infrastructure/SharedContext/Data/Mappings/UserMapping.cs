using EmergencyCart.Domain.AccountContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencyCart.Infrastructure.SharedContext.Data.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        #region Table
        builder.ToTable("User");
        builder.HasKey(user => user.Id)
            .HasName("PK_User");
        #endregion

        #region Column
        builder.OwnsOne(user => user.Name, config =>
        {
            config.Property(user => user.FirstName)
            .HasColumnName("FirstName")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20)
            .IsRequired(true);

            config.Property(user => user.LastName)
            .HasColumnName("LastName")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20)
            .IsRequired(true);
        });


        builder.OwnsOne(user => user.Email, config =>
        {
            config.HasIndex(user => user.Address)
            .HasDatabaseName("I_User_Email_Address")
            .IsUnique(true);

            config.Property(user => user.Address)
            .HasColumnName("Email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(70)
            .IsRequired(true);
        });

    
        builder.OwnsOne(user => user.Password, config =>
        {
            config.Property(user => user.Hash)
            .HasColumnName("Hash")
            .HasColumnType("VARCHAR")
            .HasMaxLength(70)
            .IsRequired(true);
        });

        builder.Property(user => user.Roles)
            .HasColumnName("Role")
            .HasColumnType("INT")
            .IsRequired(true);


        builder.Property(user => user.IsActive)
            .HasColumnName("IsActive")
            .HasColumnType("BIT")
            .IsRequired(true);
        #endregion
    }
}
