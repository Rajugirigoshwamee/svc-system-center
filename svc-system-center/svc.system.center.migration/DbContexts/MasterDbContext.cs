using Microsoft.EntityFrameworkCore;
using svc.birdcage.parrot.Authorization;
using svc.birdcage.parrot.Masters;

namespace svc.system.center.migration.DbContexts;

public class MasterDbContext : DbContext
{
    public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Tenant> Tenant { get; set; }
    public virtual DbSet<Languages> Languages { get; set; }
    public virtual DbSet<Countries> Countries { get; set; }
    public virtual DbSet<States> States { get; set; }
    public virtual DbSet<Cities> Cities { get; set; }
    public virtual DbSet<Areas> Areas { get; set; }
    public virtual DbSet<Users> Users { get; set; }
    public virtual DbSet<Roles> Roles { get; set; }
    public virtual DbSet<UsersRoles> UsersRoles { get; set; }
    public virtual DbSet<Permission> Permission { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
