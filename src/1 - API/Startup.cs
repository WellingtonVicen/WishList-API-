using API.ViewModels;
using AutoMapper;
using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services.DTO;
using Services.Interfaces;
using Services.Services;
using System;
using System.IO;
using System.Reflection;

namespace API
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
            services.AddCors();

            #region swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WishList.API",
                    Version = "v1",
                    Description = "API Rest Desenvolvida para Portifolio Pessoal",
                    Contact = new OpenApiContact
                    {
                        Name = "Wellington Vicencio",
                        Email = "wellington.vicencio@uni9.edu.br",
                        Url = new Uri("https://www.linkedin.com/in/wellington-vicencio-396655181/"),

                    },

                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            #endregion

            #region AutoMapper
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, ItemDTO>().ReverseMap();
                cfg.CreateMap<CreateViewModel, ItemDTO>().ReverseMap();
                cfg.CreateMap<UpdateViewModel, ItemDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());
            #endregion

            //Injeção de Dependencia
            #region DI

            services.AddSingleton(d => Configuration);

            services.AddDbContext<ItemContext>(options =>
            options.UseMySql(Configuration["ConnectionStrings:ITEM"]), ServiceLifetime.Transient);

            services.AddScoped<IitemService, ItemService>();
            services.AddScoped<IitemRepository, ItemRepository>();


            #endregion
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

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()); // allow credentials

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

             app.UseSwagger(c =>
             {
                    c.RouteTemplate = "WishListAPI/swagger/{documentName}/swagger.json";
             });
                app.UseSwaggerUI(c =>
                 {
                     c.SwaggerEndpoint("/WishListAPI/swagger/v1/swagger.json", "WishListAPI v1");
                     c.RoutePrefix = "WishListAPI/swagger";
                 });

           
        }
    }
}
