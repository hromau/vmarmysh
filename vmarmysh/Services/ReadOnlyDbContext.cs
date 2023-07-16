using Microsoft.EntityFrameworkCore;
using vmarmysh.Store;

namespace vmarmysh.Services;

public class ReadOnlyDbContext : IReadOnlyDbContext
{
    private readonly ApplicationDbContext _dbContext;

    public ReadOnlyDbContext(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<Tree> Trees => _dbContext.Trees.AsNoTracking();
    public IQueryable<Node> Nodes => _dbContext.Nodes.AsNoTracking();
    public IQueryable<ExceptionLog> ExceptionLogs => _dbContext.ExceptionLogs.AsNoTracking();
}