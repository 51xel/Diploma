using Diploma.Application;
using Diploma.Dal.EntityFramework;
using Diploma.Dal.MemoryCache;
using Diploma.Dal.PythonRunTime;
using Diploma.Dal.PythonRunTime.Common;
using Diploma.Dal.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddDalEntityFramework(builder.Configuration)
    .AddDalStorage(builder.Configuration)
    .AddDalPythonRunTime()
    .AddDalMemoryCache();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();

lifetime.ApplicationStopping.Register(() =>
{
    PythonEngineControl.Shutdown();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
