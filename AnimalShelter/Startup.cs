using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System;

using AnimalShelter.Models;

namespace AnimalShelter
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy("AllowSpecificOrigin",
              builder =>
              {
                builder.WithOrigins("http://localhost:5000", "https://localhost:5001");
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
              });
      });

      services.AddControllers();
      services.AddDbContext<AnimalShelterContext>(opt =>
                opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
      services.AddControllers();
      services.AddSwaggerGen(c =>
        {
          c.SwaggerDoc("v1", new OpenApiInfo 
          {
            Title = "AnimalShelter",
            Version = "v1", 
            Description = "A simple yet functional of an animal shelter ASP.NET Core Web API",
            Contact = new OpenApiContact
            {
              Name = "Erika Debelis",
              Email = "erika.debelis@gmail.com",
              Url = new Uri("https://www.linkedin.com/in/erika-debelis/")
            },
            License = new OpenApiLicense
            {
              Name = "Use under AFL",
              Url = new Uri("https://opensource.org/licenses/AFL-3.0"),
            }
          });
        });
      services.AddApiVersioning(o =>
      {
        o.ReportApiVersions = true;
        o.AssumeDefaultVersionWhenUnspecified = true;
        o.DefaultApiVersion = new ApiVersion(1, 0);
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger(c =>
        {
        c.SerializeAsV2 = true;
        });
        app.UseSwaggerUI(c => 
        {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnimalShelter v1");
        });
      }

      // app.UseHttpsRedirection();
      app.UseRouting();
      app.UseCors();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}