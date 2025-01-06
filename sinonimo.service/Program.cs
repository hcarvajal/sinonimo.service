using sinonimo.service;
using Microsoft.AspNetCore.StaticFiles;
using Serilog;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Reflection;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography;
using Asp.Versioning;
using Persistence;
using Service.Abstraction;
using Services;
using Models.RepositoryManager;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("Logs/sinonimo.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var SinonimoSpecificOrigings = "_sinonimoSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddCors(options =>
  options.AddPolicy(name: SinonimoSpecificOrigings,
                    policy =>
                    {
                        policy.WithOrigins("http://www.sinonimo.com")
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    }
   ));

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;

}).AddNewtonsoftJson()
  .AddXmlDataContractSerializerFormatters();



  

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setupAction =>
{
    var xmlCommentFIle = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFIle);

   // setupAction.IncludeXmlComments(xmlCommentsFullPath);

    setupAction.AddSecurityDefinition("SinonimoApiBearerAuth", new OpenApiSecurityScheme()
        {
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            Description = "Input a valid token to access this api"
        });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "SinonimoApiBearerAuth"
                }
            }, new List<string>() 
        }
    });


});

builder.Services.AddSingleton<FileExtensionContentTypeProvider>();





builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

builder.Services.AddDbContextPool<SinonimoContext>(option =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    //option.UseNpsql(connectionString);
    option.UseMySQL(connectionString);
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretForKey"]))

        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IsAdmin", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Admin");
    });
    options.AddPolicy("IsUser", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("User");
    });
});

builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.DefaultApiVersion = new Asp.Versioning.ApiVersion(1);
    setupAction.ReportApiVersions = true;
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(SinonimoSpecificOrigings);

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
  
     endpoints.MapControllers(); 

});


//app.MapControllers();

app.Run();
