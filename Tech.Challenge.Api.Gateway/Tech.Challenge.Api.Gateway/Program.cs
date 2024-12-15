using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String("YTJVPzlCM3Q1KVkoPGM1PlgqNit8MjR4O3Jba1ZR"))
        };
    });

builder.Services.AddOcelot();

var app = builder.Build();

app.UseOcelot();

app.Run();