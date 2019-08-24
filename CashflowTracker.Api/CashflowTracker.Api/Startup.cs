using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using CashflowTracker.Api.Configurations;
using CashflowTracker.Contracts;
using CashflowTracker.Contracts.Mediator;
using CashflowTracker.Contracts.Mediator.Interfaces;
using CashflowTracker.Data;
using CashflowTracker.Handlers;
using CashflowTracker.Models;
using CashflowTracker.Repositories;
using CashflowTracker.Repositories.Implementations;
using CashflowTracker.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace CashflowTracker.Api
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
            services.Configure<MediatorOptions>(Configuration.GetSection(nameof(MediatorOptions)));

            services.AddAutoMapper(
                typeof(HandlersAssemblyAnchor).Assembly,
                typeof(Startup).Assembly);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info() { Title = "CashflowTracker", Version = "v1" });
            });

            services.AddDbContext<CashflowTrackerContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CashflowTrackerDb"));
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<AutofacModule>();
            builder.RegisterModule<HandlerModule>();
            builder.RegisterModule<RepositoryModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var swaggerOptions = new CashflowTracker.Api.Configurations.SwaggerOptions();
            Configuration.GetSection(nameof(Swashbuckle.AspNetCore.Swagger.SwaggerOptions)).Bind(swaggerOptions);

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseStaticFiles();
            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerOptions.JsonRoute, "CashflowTracker API");
                c.RoutePrefix = String.Empty;
            });
        }
    }
}
