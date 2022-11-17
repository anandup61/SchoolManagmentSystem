using Microsoft.EntityFrameworkCore;
using Student.DbConnection;
using Student.Model;
using Student.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRegisterService, RegisterServic>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddDbContext<DbClass>(opps =>
{
    opps.UseSqlServer(builder.Configuration.GetConnectionString("connect"));
});
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowOrgin", policy =>
    {
        policy.WithOrigins("http://localhost:4200/")
        .AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors("AllowOrgin");
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
