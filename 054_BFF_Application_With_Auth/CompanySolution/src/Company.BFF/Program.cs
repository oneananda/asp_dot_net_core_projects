using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();

var jwtKey = builder.Configuration["Jwt:Key"]!;
var jwtIssuer = builder.Configuration["Jwt:Issuer"]!;
var jwtAudience = builder.Configuration["Jwt:Audience"]!;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Company BFF",
        Version = "v1",
        Description = "Backend for Frontend — the single public gateway. " +
                      "Get a dev token first: GET /dev/token (Development only)."
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Paste your token as:  Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// YARP reads routes + clusters from appsettings "ReverseProxy" section
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json",              "Company BFF v1");
    c.SwaggerEndpoint("/user-mgmt/swagger/v1/swagger.json",   "User Management API v1");
    c.SwaggerEndpoint("/prod-mgmt/swagger/v1/swagger.json",   "Product Management API v1");
    c.RoutePrefix = "swagger";

    // Persist the token to localStorage so it survives page reload
    c.ConfigObject.AdditionalItems["persistAuthorization"] = true;

    // Forward the stored Bearer token on every request Swagger UI makes,
    // including the spec-fetch calls that load the downstream swagger.json files.
    // Must be a single-line string — Swashbuckle embeds this inside a JSON value
    // and JSON does not allow literal newline characters in strings.
    c.UseRequestInterceptor("(req) => { try { var auth = JSON.parse(localStorage.getItem('authorized') || '{}'); var bearer = auth['Bearer']; if (bearer && bearer.value) { req.headers['Authorization'] = bearer.value; } } catch(e) {} return req; }");
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapReverseProxy();

app.Run();
