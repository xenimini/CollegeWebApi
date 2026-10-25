using CollegeWebApi.Data;
using CollegeWebApi.Data;
using Microsoft.EntityFrameworkCore;
using CollegeWebApi.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CollegeDbContext>(options =>
    options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=CollegeDB;Trusted_Connection=True;TrustServerCertificate=True;"));
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
app.MapGet("/students/all", async (CollegeDbContext db) =>
    await db.Students.ToListAsync());

app.MapGet("/groups/all", async (CollegeDbContext db) =>
    await db.Groups.ToListAsync());

app.MapPost("/students/add", async (Student student, CollegeDbContext db) =>
{
    db.Students.Add(student);
    await db.SaveChangesAsync();
    return Results.Ok(student);
});

app.MapPost("/groups/add", async (Group group, CollegeDbContext db) =>
{
    db.Groups.Add(group);
    await db.SaveChangesAsync();
    return Results.Ok(group);
});

app.MapPut("/students/{id}", async (int id, Student student, CollegeDbContext db) =>
{
    var existing = await db.Students.FindAsync(id);
    if (existing == null) return Results.NotFound();

    existing.FirstName = student.FirstName;
    existing.LastName = student.LastName;
    existing.Age = student.Age;
    existing.GroupId = student.GroupId;

    await db.SaveChangesAsync();
    return Results.Ok(existing);
});

app.MapDelete("/students/{id}", async (int id, CollegeDbContext db) =>
{
    var student = await db.Students.FindAsync(id);
    if (student == null) return Results.NotFound();

    db.Students.Remove(student);
    await db.SaveChangesAsync();
    return Results.Ok();
});
app.Run();
