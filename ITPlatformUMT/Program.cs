using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;
using BusinessObjects;
using DataAccessObjects;
using System.Text.Json.Serialization;
using Services.Interfaces;
using Services.Implementations;
using Repositories.Interfaces;
using Repositories.Implementations;
using Helpers;
using System.Net.WebSockets;
using Microsoft.AspNetCore.WebSockets;
using ITPlatformUMT.WebSockets;

var builder = WebApplication.CreateBuilder(args);

// ===== Add DbContext with PostgreSQL =====
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly("BusinessObjects")
    )
);

// Thêm CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // địa chỉ frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// ===== Register DAOs, Repositories, Services =====

// Account
builder.Services.AddScoped<AccountDAO>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

// Application
builder.Services.AddScoped<ApplicationDAO>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();

// Client
builder.Services.AddScoped<ClientDAO>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();

// Freelancer
builder.Services.AddScoped<FreelancerDAO>();
builder.Services.AddScoped<IFreelancerRepository, FreelancerRepository>();
builder.Services.AddScoped<IFreelancerService, FreelancerService>();

// Project
builder.Services.AddScoped<ProjectDAO>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();

// Milestone
builder.Services.AddScoped<IMilestoneRepository, MilestoneRepository>();
builder.Services.AddScoped<IMilestoneService, MilestoneService>();

// Submittions
builder.Services.AddScoped<ISubmittionRepository, SubmittionRepository>();
builder.Services.AddScoped<ISubmittionService, SubmittionService>();

// Skill
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ISkillService, SkillService>();

// ExpertiseProfiles
builder.Services.AddScoped<IExpertiseProfileRepository, ExpertiseProfileRepository>();
builder.Services.AddScoped<IExpertiseProfileService, ExpertiseProfileService>();

// Certification
builder.Services.AddScoped<ICertificationRepository, CertificationRepository>();
builder.Services.AddScoped<ICertificationService, CertificationService>();

// Location
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();

// Subscription
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();

// SkillRequirement
builder.Services.AddScoped<ISkillRequirementRepository, SkillRequirementRepository>();
builder.Services.AddScoped<ISkillRequirementService, SkillRequirementService>();

// SkillInProfile
builder.Services.AddScoped<ISkillInProfileRepository, SkillInProfileRepository>();
builder.Services.AddScoped<ISkillInProfileService, SkillInProfileService>();

// Package
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IPackageService, PackageService>();

// Message
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageService, MessageService>();

// Chat
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IChatService, ChatService>();

// ===== Add Controllers and JSON Options =====
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// ===== Swagger / OpenAPI =====
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ===== AutoMapper =====
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Bật CORS
app.UseCors("AllowFrontend");
app.UseCors("AllowLocalhost3000");


app.UseWebSockets();

app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/ws"))
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            var socket = await context.WebSockets.AcceptWebSocketAsync();
            await WebSocketHandler.Handle(context, socket);
        }
        else
        {
            context.Response.StatusCode = 400;
        }
    }
    else
    {
        await next();
    }
});


// ===== Configure Middleware =====
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();       // Optional: Enable in production
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
