using System.Text.Json.Serialization;
using vmarmysh.API;
using vmarmysh.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterBlModule(builder.Configuration.GetConnectionString("Store"));
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CustomExceptionMiddleware>();
builder.Services.AddScoped<SaveChangesIntercept>();

var app = builder.Build();
app.UseMiddleware<CustomExceptionMiddleware>();
app.UseMiddleware<SaveChangesIntercept>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();