using Microsoft.EntityFrameworkCore;
using MinimalLogin.Users.EFCore.Map;

namespace MinimalLogin.Users.EFCore;

public class UsersContext : DbContext
{
    public UsersContext()
    { }

    public UsersContext(DbContextOptions options) : base(options)
    { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
    }
}

