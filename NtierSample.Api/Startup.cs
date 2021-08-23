using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NtierSample.Core.Repositories;
using NtierSample.Core.Services;
using NtierSample.Core.UnitOfWorks;
using NtierSample.Data;
using NtierSample.Data.Repositories;
using NtierSample.Data.UnitOfWorks;
using NtierSample.Service.Services;
using AutoMapper;
using NtierSample.Api.Filters;
using Microsoft.AspNetCore.Diagnostics;
using NtierSample.Api.DTOs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NtierSample.Api.Extension;

namespace NtierSample.Api
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
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<NotFoundFilter>();
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped(typeof(IService<>),typeof(Service<>));
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();

            services.AddDbContext<AppDbContext>(options => {
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),o => 
            {
                o.MigrationsAssembly("NtierSample.Data");
                });            
            });

            services.AddControllers();

            services.Configure<ApiBehaviorOptions>(options => 
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NtierSample.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NtierSample.Api v1"));
            }

            //TODO:Extension Methodları araştır!
            app.UseCustomException();

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
