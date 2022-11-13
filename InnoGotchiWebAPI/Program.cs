using AutoMapper;
using InnoGotchiWebAPI.Domain.Service;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Infrastructure;
using InnoGotchiWebAPI.Infrastructure.Repositories;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using InnoGotchiWebAPI.Mapper;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
//var mapperConfig = new MapperConfiguration(mc =>
//{
//    mc.AddProfile(new UserMapProfile());
//});

//IMapper mapper = mapperConfig.CreateMapper();
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MainDbContext>(options => options.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<ILookRepository, LookRepository>();
builder.Services.AddScoped<IFarmRepository, FarmRepository>();
builder.Services.AddScoped<ICollaborationRepository, CollaborationRepository>();
builder.Services.AddScoped<ICharacteristicRepository, CharacteristicRepository>();
// Add services to the container.
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IPetService, PetService>();
builder.Services.AddTransient<ILookService, LookService>();
builder.Services.AddTransient<IFarmService, FarmService>();
builder.Services.AddTransient<ICollaborationService, CollaborationService>();
builder.Services.AddTransient<ICharacteristicService, CharacteristicService>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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

app.Run();
