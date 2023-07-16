using Microsoft.EntityFrameworkCore;

namespace vmarmysh.Store;

public static class DaModule
{
    public static void RegisterDaModule(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(options => { options.UseNpgsql(connectionString); });
    }
}