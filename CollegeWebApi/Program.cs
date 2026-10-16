using CollegeConsole.Data;
using CollegeConsole.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/groups", () =>
{
    string connectionString = @"Server=localhost\SQLEXPRESS;Database=CollegeDB;Trusted_Connection=True;TrustServerCertificate=True;";
    var repo = new GroupRepository(connectionString);
    var groups = repo.GetAll();

    var result = string.Join("\n", groups.Select(g => $"{g.Id}. {g.Name}"));
    return result;
});
app.UseStaticFiles();
app.MapGet("/", () => Results.Redirect("/index.html"));

app.Run();
