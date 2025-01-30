using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TransferCompressor.Server.Data;
using TransferCompressor.Server.Repositories;
using TransferCompressor.Server.Services;

namespace TransferCompressor.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
        });

            builder.Services.AddAuthorization();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Allowvite",
                    builder => builder.AllowAnyOrigin()
                        .WithOrigins("http://localhost:54512")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            // Database setup
            builder.Services.AddDbContext<CompressorContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Dependency Injection

            builder.Services.AddScoped<IEmbedVideoRepository, EmbedVideoRepository>();
            builder.Services.AddScoped<IVideoRepository, VideoRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<VideoService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<IEmailService, EmailService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors("Allowvite");

            app.MapControllers(); // Zorgt ervoor dat controllers worden gemapt naar routes

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
