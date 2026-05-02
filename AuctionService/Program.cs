using AplicationLayer.Interfaces.Repo;
using AplicationLayer.Interfaces.Service;
using AplicationLayer.Service;
using AplicationLayer.Mapping;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer;
using PersistanceLayer.Repository;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddMassTransit(x =>
{
    x.AddEntityFrameworkOutbox<Context>(opt =>
    {
        // si es servis bus no esta disponible cada 10 segundos se intentara enviar los mensajes pendientes
        opt.QueryDelay = TimeSpan.FromSeconds(5);
        // defina que base de datos se usara para almacenar los mensajes pendientes
        opt.UsePostgres();
        //
        opt.UseBusOutbox();
    });

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.UseMessageRetry(r=> r.Interval(5, TimeSpan.FromSeconds(5)));
        cfg.UseDelayedRedelivery(r =>{r.Interval(3, TimeSpan.FromSeconds(10));});
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddTransient<IAuctionRepository, AuctionRepository>();
builder.Services.AddTransient<IAuctonService, AuctonService>();
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
