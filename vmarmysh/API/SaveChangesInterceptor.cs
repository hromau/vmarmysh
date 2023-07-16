using vmarmysh.Store;

namespace vmarmysh.API;

public class SaveChangesIntercept : IMiddleware
{
    private readonly ApplicationDbContext _applicationDbContext;

    public SaveChangesIntercept(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await next.Invoke(context);
        if (_applicationDbContext.ChangeTracker.HasChanges())
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}