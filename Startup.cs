using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Db;
using BurgerShack.Repositories;
using BurgerShack.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace BurgerShack
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();

      //NOTE: Register all Services
      services.AddScoped<IDbConnection>(x => CreateDbConnection());

      //Temporary only while we dont have an actual db
      // services.AddSingleton<FakeDb>();

      // this is how you create a service available for dependency injection
      //STUB This is unique to this project
      services.AddTransient<BurgersService>();
      services.AddTransient<BurgerRepository>();
      services.AddTransient<ItemService>();
      services.AddTransient<ItemRepository>();
    }

    private IDbConnection CreateDbConnection()
    {
      var connectionString = Configuration.GetSection("db").GetValue<string>("gearhost");
      return new MySqlConnection(connectionString);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
