using AutoMapper;
using BookManagement.Application;
using BookManagement.Infrastructure;
using BookManagement.Application.Mapper;
using BookManagement.Infrastructure.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<DatabaseContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddInInfrastructureServices(builder.Configuration);
builder.Services.AddInApplicationServices();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(config =>
{
    config.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
MapperHelper.Configure(mapper);
builder.Services.AddSingleton(mapper);



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
