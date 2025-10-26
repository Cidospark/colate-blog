using CorlateBlog.Application;
using CorlateBlog.Infrastructure.Data;
using EmployeeManagmeentSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
<<<<<<< HEAD
builder.Services.AddCors(options => 
    options.AddPolicy("MyCorsPolicy", policy => 
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
=======
builder.Services.AddCors();
>>>>>>> develop


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

<<<<<<< HEAD
app.UseCors("MyCorsPolicy");
=======
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

>>>>>>> develop
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await Seeder.SeedMe(services);
}

app.Run();
