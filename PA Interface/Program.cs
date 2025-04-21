using AgricultureOptimization.Data;
using AgricultureOptimization.Models;

namespace AgricultureOptimization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Register HttpClient for MongoService dependency
            builder.Services.AddHttpClient();

            // Register MongoService as a singleton or transient service
            // Get MongoDB connection string from appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                   ?? throw new InvalidOperationException("Connection string 'MongoDbConnection' not found.");
            // Register MongoService as a singleton, scoped, or transient service
            builder.Services.AddScoped<MongoService>(sp =>
                new MongoService(builder.Configuration)); //sp.GetRequiredService<HttpClient>()));


            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
