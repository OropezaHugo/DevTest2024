using backend.data;
using backend.Profiles;
using backend.services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BackendDbContext>(optionsBuilder =>
    optionsBuilder.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
    );

});
builder.Services.AddAutoMapper(typeof(PollProfile));

builder.Services.Scan(scan => scan
    .FromAssemblyOf<PollService>()
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")  && type.Namespace == "backend.services"))
    .AsImplementedInterfaces()
    .WithScopedLifetime());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar Swagger y su interfaz
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Prueba v1");
        options.RoutePrefix = string.Empty;
    });
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BackendDbContext>();
    context.Database.Migrate();
}
app.UseRouting();
app.UseCors("AllowLocalhost");
app.UseAuthorization();
app.MapControllers();

app.Run();