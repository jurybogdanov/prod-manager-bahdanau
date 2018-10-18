using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProductionManager.DbModel.Models;
using ProductionManager.Services;
using ProductionManager.WebApi.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using ProductionManager.WebApi.Middleware;

namespace ProductionManager.WebApi
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
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {Title = "Production Manager API"});
            });

            services.AddDbContext<AdventureContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("default")));
            services.AddScoped<ProductController>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ILoggerService, LoggerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseStaticFiles();

            var loggingOptions = this.Configuration.GetSection("Log4NetCore")
                .Get<Log4NetProviderOptions>();

            loggerFactory.AddLog4Net(loggingOptions);

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Production Manager API");
                c.RoutePrefix = "docs";
            });
        }
    }
}
