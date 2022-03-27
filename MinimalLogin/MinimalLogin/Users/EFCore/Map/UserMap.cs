using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MinimalLogin.Users.EFCore.Map;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(prop => prop.Id);

        builder.Property(prop => prop.Id).ValueGeneratedOnAdd().HasDefaultValueSql("gen_random_uuid()") ;
        builder.Property(prop => prop.Name).HasColumnType("varchar(60)");
        builder.Property(prop => prop.Birthday).HasColumnType("date");
        builder.Property(prop => prop.Gender).HasColumnType("varchar(1)");
        builder.Property(prop => prop.PreferedProgramingLanguage).HasColumnType("varchar(30)");

        builder.Property(prop => prop.UserName).HasColumnType("varchar(30)");
        builder.Property(prop => prop.Password).HasColumnType("varchar(30)");

        builder.Property<DateTime>("CreatedAt").ValueGeneratedOnAdd().HasDefaultValueSql("now()");
        builder.Property<DateTime>("UpdatedAt").ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");
    }
}

