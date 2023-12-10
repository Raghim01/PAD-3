using Common.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MovieAPI.Repositories;
using MovieAPI.Services;
using MovieAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI
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
            services.AddHttpContextAccessor();
            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDBSettings"));

            services.Configure<SyncServiceSettings>(Configuration.GetSection("SyncServiceSettings"));

            services.AddSingleton<IMongoDbSettings>(provider =>
            provider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            services.AddSingleton<ISyncServiceSettings>(provider =>
             provider.GetRequiredService<IOptions<SyncServiceSettings>>().Value);

            services.AddScoped<IMongoRepository<Movie>, MongoRepository<Movie>>();
            services.AddScoped<ISyncService<Movie>, SyncService<Movie>>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
