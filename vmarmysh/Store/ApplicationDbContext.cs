using Microsoft.EntityFrameworkCore;

namespace vmarmysh.Store;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Tree> Trees { get; set; }
    public DbSet<Node> Nodes { get; set; }
    public DbSet<ExceptionLog> ExceptionLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Node>()
            .HasOne<Tree>(x => x.Tree)
            .WithMany(x => x.Nodes)
            .HasForeignKey(x => x.TreeId);
    }
}