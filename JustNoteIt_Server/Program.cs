using JustNoteIt_Server.DBContext;
using JustNoteIt_Server.Interfaces;
using JustNoteIt_Server.Repositories;
using JustNoteIt_Server.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(24);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Dependency Injection
builder.Services.AddScoped<INoteRepo, NoteRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ISessionService, SessionService>();

//Connection to Database using DB Connection String
var connectionString = builder.Configuration.GetConnectionString("JustNoteItConnection");
builder.Services.AddDbContext<JustNoteItContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSession();

app.UseAuthorization();

app.MapControllers();

app.Run();
