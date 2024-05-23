
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Testing
{
    public class Startup
    {
        Configuration = Configuration;
    }

    public IConfiguration configuration {  get; }


    public void ConfigureService(IServiceCollection services)
    {
        services.AddScoped<IDbConnection>((s) =>
        {
            IDbConnection conn = new MySqlConnection(Configuration.GetConnectionString("bestbuy"));
            conn.Open();
            return conn;

            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddControllersWithViews();
        };
    }

    

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
        }

    }
}
