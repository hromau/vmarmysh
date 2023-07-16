using vmarmysh.Store;

namespace vmarmysh.Services;

public static class BlModule
{
    public static void RegisterBlModule(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddScoped<IReadOnlyDbContext, ReadOnlyDbContext>();
        serviceCollection.RegisterDaModule(connectionString);
    }
}