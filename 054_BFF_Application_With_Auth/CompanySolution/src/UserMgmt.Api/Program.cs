using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var jwtKey = builder.Configuration["Jwt:Key"]!;
var jwtIssuer = builder.Configuration["Jwt:Issuer"]!;
var jwtAudience = builder.Configuration["Jwt:Audience"]!;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // Keep original JWT claim names (sub, name, role) instead of Microsoft's long URN aliases
        options.MapInboundClaims = false;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            // ── What to validate ────────────────────────────────────────────
            ValidateIssuer            = true,
            ValidateAudience          = true,
            ValidateLifetime          = true,
            ValidateIssuerSigningKey  = true,

            // ── Trusted values ───────────────────────────────────────────────
            ValidIssuer               = jwtIssuer,
            ValidAudience             = jwtAudience,
            IssuerSigningKey          = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),

            // ── Hardening ────────────────────────────────────────────────────
            // No grace period — token is invalid the moment it expires
            ClockSkew                 = TimeSpan.Zero,
            // Reject tokens that have no expiry claim at all
            RequireExpirationTime     = true,
            // Reject unsigned tokens (blocks the alg:none attack)
            RequireSignedTokens       = true,
            // Whitelist only HS256 — reject RS256, PS256, none, etc.
            ValidAlgorithms           = new[] { SecurityAlgorithms.HmacSha256 },

            // ── Claim mapping ────────────────────────────────────────────────
            NameClaimType             = "name",
            RoleClaimType             = "role",
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "User Management API",
        Version = "v1",
        Description = "Internal API — direct access for development/testing only."
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

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Management API v1");
    c.RoutePrefix = "swagger";
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
