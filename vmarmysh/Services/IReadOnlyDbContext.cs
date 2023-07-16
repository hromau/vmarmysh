using vmarmysh.Store;

namespace vmarmysh.Services;

public interface IReadOnlyDbContext
{
    public IQueryable<Tree> Trees { get; }
    public IQueryable<Node> Nodes { get; }
    public IQueryable<ExceptionLog> ExceptionLogs { get; }
}