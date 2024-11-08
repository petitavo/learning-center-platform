using ACME.LearningCenterPlatform.API.Discipline.Application.Internal.CommandServices;
using ACME.LearningCenterPlatform.API.Discipline.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Discipline.Domain.Services;
using ACME.LearningCenterPlatform.API.Discipline.Infrastructure.Persistence.EFC.Repositories;
using ACME.LearningCenterPlatform.API.Hr.Application.Internal.CommandServices;
using ACME.LearningCenterPlatform.API.Hr.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Hr.Domain.Services;
using ACME.LearningCenterPlatform.API.Hr.Infrastructure.Persistence.EFC.Repositories;
using ACME.LearningCenterPlatform.API.Kr.Application.Internal.CommandServices;
using ACME.LearningCenterPlatform.API.Kr.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Kr.Domain.Services;
using ACME.LearningCenterPlatform.API.Kr.Infrastructure.Persistence.EFC.Repositories;
using ACME.LearningCenterPlatform.API.Publishing.Application.Internal.CommandServices;
using ACME.LearningCenterPlatform.API.Publishing.Application.Internal.QueryServices;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Publishing.Infrastructure.Persistence.EFC.Repositories;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ACME.LearningCenterPlatform.API.SoccerPlayer.Application.Internal.CommandServices;
using ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Repositories;
using ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Services;
using ACME.LearningCenterPlatform.API.SoccerPlayer.Infrastructure.Persistence.EFC.Repositories;
using ACME.LearningCenterPlatform.API.Subscriptions.Application.Internal.CommandServices;
using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Services;
using ACME.LearningCenterPlatform.API.Subscriptions.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString == null) throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Dependency Injection

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Publishing Bounded Context
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITutorialRepository, TutorialRepository>();
builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();
builder.Services.AddScoped<ITutorialCommandService, TutorialCommandService>();
builder.Services.AddScoped<ITutorialQueryService, TutorialQueryService>();


builder.Services.AddScoped<ISoccerPlayerRepository, SoccerPlayerRepository>();
builder.Services.AddScoped<ISoccerPlayerCommandService, SoccerPlayerCommandService>();

builder.Services.AddScoped<IAthleticDisciplineRepository, AthleticDisciplineRepository>();
builder.Services.AddScoped<IAthleticDisciplineCommandService, AthleticDisciplineCommandService>();


// Plan 

builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IPlanCommandService, PlanCommandService>();


// KIINGrental
builder.Services.AddScoped<IKingrentalRepository, KingrentalRepository>();
builder.Services.AddScoped<IKingrentalCommandService, KingrentalCommandService>();

// Hr

builder.Services.AddScoped<IAppointmentsRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentCommandService, AppointmentCommandService>();

var app = builder.Build();





// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}

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