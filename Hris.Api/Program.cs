using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Hris.Api.Security;
using Hris.Api.Settings;
using Hris.Business.Config;
using Hris.Business.Service.Administrator;
using Hris.Business.Service.Common;
using Hris.Business.Service.GraphApi;
using Hris.Data.DataContext;
using Hris.Data.Models.Clock;
using Hris.Data.Models.Administrator;
using Hris.Data.Models.Employee;
using Hris.Data.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Hris.Data.Models.Settings;
using Hris.Data.Models.Leave;
using Hris.Api.Extensions;
using Hris.Data.Models.Payroll;
using Hris.Business.Service.Leave;
using QuestPDF.Infrastructure;
using Hris.Data.UnitOfWork;
using Hris.Business.Extensions;
using Hris.Api.Utilities;
using System.Linq;
using Hris.Data.DTO;
using Hris.Api.Hub;
using Hris.Business.Service.v1.Notification;
using Hris.Api.Extensions.Seed;
using Hris.Data.Models.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Hris.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Configuration.GetSection("UserClaims").Bind(ApplicationSettings.UserClaims);
builder.Configuration.GetSection("Security").Bind(ApplicationSettings.SecurityConfig);
builder.Configuration.GetSection("StorageAccountConfig").Bind(ApplicationSettings.StorageAccountConfig);
builder.Configuration.GetSection(AzureAdConfig.Name).Bind(ApplicationSettings.AzureAdConfig);

builder.Services.Configure<AzureAdConfig>(builder.Configuration.GetSection(AzureAdConfig.Name));

//ConnectionString
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration["Data:ConnectionString:DefaultConnection"]));



builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = long.MaxValue;
    options.MemoryBufferThreshold = Int32.MaxValue;
});

//Add SignalR

//CORS Configuration

builder.Services.AddCors(options =>
{
    options.AddPolicy(ApplicationSettings.SecurityConfig.Name!, policy =>
    {
        policy.AllowCredentials()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins(ApplicationSettings.SecurityConfig.AllowedHosts!);
    });
});

//MS Identity Provider
//builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration);

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApi(builder.Configuration);

//setup SignalR
builder.Services.HubJwtConfigure();
builder.Services.AddSignalR();

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

#region
//Swagger AD Provider
//builder.Services.AddSwaggerGen(c =>
//    {
//        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
//        {
//            Title = "HRIS API Endpoints",
//            Version = "v1"
//        });

//        c.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
//        {

//            Description = "Oauth2.0",
//            Name = "oauth2.0",
//            Type = Microsoft.OpenApi.Models.SecuritySchemeType.OAuth2,
//            Flows = new Microsoft.OpenApi.Models.OpenApiOAuthFlows
//            {
//                AuthorizationCode = new Microsoft.OpenApi.Models.OpenApiOAuthFlow
//                {
//                    AuthorizationUrl = new Uri(builder.Configuration["SwaggerAzureAD:AuthorizationUrl"]!),
//                    TokenUrl = new Uri(builder.Configuration["SwaggerAzureAD:TokenUrl"]!),
//                    Scopes = new Dictionary<string, string>
//                        {
//                            {builder.Configuration["SwaggerAzureAD:Scope"]!,"Access API" },
//                            { "openid","Token" },
//                            { "profile","profile"},
//                            { "offline_access","Offline Access"}
//                        }
//                }
//            }

//        });

//        c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
//            {
//                {
//                    new OpenApiSecurityScheme
//                    {
//                        Reference= new OpenApiReference{Type=ReferenceType.SecurityScheme,Id="oauth2" }
//                    },
//                    new[]{builder.Configuration["SwaggerAzureAD:Scope"]}
//                }
//            });
//    });

#endregion

//SERILOG
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "HrisAPIWithIdentityServer", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer",
                    
                }
            },             new string[]{}
        }
    });
});


#region
//builder.Services.AddScoped<HrisActionFilterAttribute>();
builder.Services.AddScoped<INotificationHelper, NotificationHelper>();
builder.Services.AddScoped<GenerateEncryptionProvider, HrisEncryptionProvider>();
builder.Services.AddScoped<IRepository<Employee>, Repository<Employee>>();
builder.Services.AddScoped<IRepository<Position>, Repository<Position>>();
builder.Services.AddScoped<IRepository<Address>, Repository<Address>>();
builder.Services.AddScoped<IRepository<Family>, Repository<Family>>();
builder.Services.AddScoped<IRepository<SalaryHistory>, Repository<SalaryHistory>>();
builder.Services.AddScoped<IRepository<Statutory>, Repository<Statutory>>();
builder.Services.AddScoped<IRepository<Department>, Repository<Department>>();
builder.Services.AddScoped<IRepository<EmploymentHistory>, Repository<EmploymentHistory>>();
builder.Services.AddScoped<IRepository<AllowanceEntitlement>, Repository<AllowanceEntitlement>>();
builder.Services.AddScoped<IRepository<AllowanceType>, Repository<AllowanceType>>();
builder.Services.AddScoped<IRepository<Team>, Repository<Team>>();
builder.Services.AddScoped<IRepository<TeamMember>, Repository<TeamMember>>();
builder.Services.AddScoped<IRepository<Track>, Repository<Track>>();
builder.Services.AddScoped<IRepository<Permission>, Repository<Permission>>();
builder.Services.AddScoped<IRepository<Client>, Repository<Client>>();
builder.Services.AddScoped<IRepository<Project>, Repository<Project>>();
builder.Services.AddScoped<IRepository<ProjectTask>, Repository<ProjectTask>>();
builder.Services.AddScoped<EnumService, EnumService>();
builder.Services.AddScoped<SmtpService, SmtpService>();
builder.Services.AddScoped<AzureAdService, AzureAdService>();
builder.Services.AddScoped<PermissionService, PermissionService>();
builder.Services.AddScoped<IRepository<UserSettings>, Repository<UserSettings>>();
builder.Services.AddScoped<IRepository<AssignedProject>, Repository<AssignedProject>>();
builder.Services.AddScoped<IRepository<Access>, Repository<Access>>();
builder.Services.AddScoped<IRepository<LeaveType>, Repository<LeaveType>>();
builder.Services.AddScoped<IRepository<LeaveEntitlement>, Repository<LeaveEntitlement>>();
builder.Services.AddScoped<IRepository<LeaveApplication>, Repository<LeaveApplication>>();
builder.Services.AddScoped<IRepository<Calendar>, Repository<Calendar>>();
builder.Services.AddSingleton(ApplicationSettings.CreateBlobContainer());
builder.Services.AddSingleton<StorageCloudService>();
builder.Services.AddScoped<ICustomClaimPrincipal, CustomClaimPrincipal>();

#endregion

//service repository extension
builder.Services.RepositoryServiceCollectionExtension();

//services business services extension
builder.Services.ServiceBusinessICollectionExtension();
// Hosted Services
builder.Services.AddHostedService<ScheduledLeaveReportService>();

QuestPDF.Settings.License = LicenseType.Professional;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.OAuthClientId(builder.Configuration["SwaggerAzureAD:ClientId"]);
        c.OAuthUsePkce();
        c.OAuthScopeSeparator(" ");
    });
}

app.UseSerilogRequestLogging();
app.UseCors(ApplicationSettings.SecurityConfig.Name!);
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();

app.MapGroup("/auth").MapIdentityApi<User>();

#region

//app.Use(async (context, next) =>
//{
//    if (!context.User.Identity?.IsAuthenticated ?? false)
//    {

//        bool isAllowed = false;
//        Defaults.ALLOWED_PATHS.ForEach(e =>
//        {

//            isAllowed = context.Request.Path.ToString().Contains(e);

//            if (isAllowed)
//                return;

//        });

//        if (isAllowed)
//        {
//            await next();
//            return;
//        }

//        context.Response.StatusCode = 401;
//    }
//    else
//        await next();
//});

#endregion

app.UseAuthorization();

app.MapControllers();
app.SeedSuperUsers();
app.SeedTaxTable();
app.SeedAccessData();
app.SeedUserTable();
app.SeedUserSettings();
app.SeedPHICTable();
app.SeedHDMFTable();
app.SeedSSSTable();

app.MapHub<NotificationHub>("/hubs/notifications");

app.Run();

