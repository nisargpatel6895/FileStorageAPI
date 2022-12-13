using FileStorageAPI.Entities;
using FileStorageAPI.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var cnn = new SqliteConnection("Filename=:fileStorage.db:");
//cnn.Open();
//builder.Services.AddDbContext<FileStorageDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDbContext<FileStorageDbContext>(options => options.UseSqlite("Data Source=" + Path.Combine(ApplicationData.Current.LocalFolder.Path, "fileStorage.db")));
builder.Services.AddDbContext<FileStorageDbContext>();

builder.Services.AddTransient<IFileDataService, FileDataService>();

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

app.Run();

