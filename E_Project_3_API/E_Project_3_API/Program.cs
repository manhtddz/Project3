using E_Project_3_API.Models;
using E_Project_3_API.Services.Interfaces;
using E_Project_3_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "AllowAll";


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(op => op.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));
builder.Services.AddScoped<IAuthentication, AuthenticationServices>();
builder.Services.AddScoped<ITypeServices, TypeServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IShopServices, ShopServices>();
builder.Services.AddScoped<IShowtimeServices, ShowtimeServices>();
builder.Services.AddScoped<ISeatServices, SeatServices>();
builder.Services.AddScoped<IGenreServices, GenreServices>();
builder.Services.AddScoped<IDateServices, DateServices>();
builder.Services.AddScoped<ITheaterServices, TheaterServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IMovieServices, MovieServices>();
builder.Services.AddScoped<ITicketServices, TicketServices>();
builder.Services.AddScoped<IFeedbackServices, FeedbackServices>();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidIssuer = builder.Configuration.GetSection("AppSettings:Token").Value!,
            ValidAudience = builder.Configuration.GetSection("AppSettings:Audience").Value!,

            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:Token").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
