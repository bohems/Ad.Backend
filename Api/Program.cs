using Application;
using Application.Common.Mappings;
using Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;
using WebApi;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApiVersioning();
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
});

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "<h4>Вставьте Токен (JWT) полученный после регистрации</h3>"
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();

    options.SwaggerDoc("v1", new()
    {
        Title = "Advertisements API",
        Description = "Тестовый WEB API проект для работы с объявлениями." +
                      "<br><br> Версия API (version): 1" +
                      "<br><br>Владимир Сорокин <a href='https://t.me/bohemsru'>telegram</a>"
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"])),
            
        };
    });

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IAdvertisementsDbContext).Assembly));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();

app.ApplyMigration<AdvertisementsDbContext>();

app.UseHttpsRedirection();

app.UseAuthentication();
 
app.UseAuthorization();

app.MapControllers();

app.Run();


