using CollegeWebApi.Data;
using CollegeWebApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CollegeDbContext>(options =>
    options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=CollegeDB;Trusted_Connection=True;TrustServerCertificate=True;"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseStaticFiles();

app.MapGet("/", () => Results.Redirect("/index.html"));

// ===== Студенты =====
app.MapGet("/students/all", async (CollegeDbContext db) =>
    await db.Students.ToListAsync());

app.MapPost("/students/add", async (Student student, CollegeDbContext db) =>
{
    db.Students.Add(student);
    await db.SaveChangesAsync();
    return Results.Ok(student);
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

// ===== Группы =====
app.MapGet("/groups/all", async (CollegeDbContext db) =>
    await db.Groups.ToListAsync());

app.MapPost("/groups/add", async (Group group, CollegeDbContext db) =>
{
    db.Groups.Add(group);
    await db.SaveChangesAsync();
    return Results.Ok(group);
});

app.MapDelete("/groups/{id}", async (int id, CollegeDbContext db) =>
{
    var group = await db.Groups.FindAsync(id);
    if (group == null) return Results.NotFound();

    db.Groups.Remove(group);
    await db.SaveChangesAsync();
    return Results.Ok();
});

// ===== Учителя =====
app.MapGet("/teachers/all", async (CollegeDbContext db) =>
    await db.Teachers.ToListAsync());

app.MapPost("/teachers/add", async (Teacher t, CollegeDbContext db) =>
{
    db.Teachers.Add(t);
    await db.SaveChangesAsync();
    return Results.Ok(t);
});

app.MapDelete("/teachers/{id}", async (int id, CollegeDbContext db) =>
{
    var x = await db.Teachers.FindAsync(id);
    if (x == null) return Results.NotFound();

    db.Teachers.Remove(x);
    await db.SaveChangesAsync();
    return Results.Ok();
});

// ===== Предметы =====
app.MapGet("/subjects/all", async (CollegeDbContext db) =>
    await db.Subjects.ToListAsync());

app.MapPost("/subjects/add", async (Subject s, CollegeDbContext db) =>
{
    db.Subjects.Add(s);
    await db.SaveChangesAsync();
    return Results.Ok(s);
});

app.MapDelete("/subjects/{id}", async (int id, CollegeDbContext db) =>
{
    var x = await db.Subjects.FindAsync(id);
    if (x == null) return Results.NotFound();

    db.Subjects.Remove(x);
    await db.SaveChangesAsync();
    return Results.Ok();
});

// ===== Оценки =====
app.MapGet("/grades/all", async (CollegeDbContext db) =>
    await db.Grades.ToListAsync());

app.MapPost("/grades/add", async (Grade g, CollegeDbContext db) =>
{
    db.Grades.Add(g);
    await db.SaveChangesAsync();
    return Results.Ok(g);
});

app.MapDelete("/grades/{id}", async (int id, CollegeDbContext db) =>
{
    var x = await db.Grades.FindAsync(id);
    if (x == null) return Results.NotFound();

    db.Grades.Remove(x);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.Run();