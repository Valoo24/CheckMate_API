using CheckMate_API.Infrastructure;
using CheckMate_BLL.Services;
using CheckMate_DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Data.SqlClient;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// permet d'avoir la gestion du token directement sur le Swagger de l'API
 // ********************************************************************** //
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyProject", Version = "v1.0.0" });

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securitySchema);

    var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                };

    c.AddSecurityRequirement(securityRequirement);

});
// *************************************************************************//
builder.Services.AddScoped<MemberService, MemberService>();
builder.Services.AddScoped<MemberRepository, MemberRepository>();
builder.Services.AddScoped<TournamentService, TournamentService>();
builder.Services.AddScoped<TournamentRepository, TournamentRepository>();

// - IDbConnection
builder.Services.AddScoped<IDbConnection>(sp =>
{
    return new SqlConnection(builder.Configuration.GetConnectionString("default"));
});


// Creation + Gestion du Token
builder.Services.AddSingleton<TokenManager>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenInfo").GetSection("secret").Value)),
        ValidateIssuer = false,
        ValidIssuer = builder.Configuration.GetSection("TokenInfo").GetSection("issuer").Value,
        ValidateAudience = false,
        ValidAudience = builder.Configuration.GetSection("TokenInfo").GetSection("audience").Value
    };
});


// Verif de l'authentification + verif droit admin 
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Auth", policy => policy.RequireAuthenticatedUser());
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();