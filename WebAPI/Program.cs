using Application.IDao;
using Application.Logic;
using Application.ILogic;
using EfcDataAccess;
using EfcDataAccess.DAOs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DBContext>();

builder.Services.AddScoped<IUserDao, UserDao>();
builder.Services.AddScoped<IPostDao, PostDao>();

builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<IPostLogic, PostLogic>();


var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());

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

