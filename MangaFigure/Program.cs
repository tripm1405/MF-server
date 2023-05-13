using MangaFigure.Extension;
using MangaFigure.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });
builder.Services.AddControllers(options =>
{
    options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
    options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web)
    {
        ReferenceHandler = ReferenceHandler.Preserve,
    }));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<MangaFigureContext>((optionsBuilder) =>
{
#if DEBUG
    var sqlConnectionString = builder.Configuration.GetConnectionString("AppDbContext");
    var keepAliveConnection = new SqlConnection(sqlConnectionString);
    keepAliveConnection.Open();
    optionsBuilder.UseSqlServer(keepAliveConnection);
#else
    // optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext"));
#endif
});
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();
builder.Services.AddRepositories();
builder.Services.AddMvc()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.Converters = new List<Newtonsoft.Json.JsonConverter>
        {
            new StringEnumConverter()
        };
    })
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();

