using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Web_Form_API.Data;
using Microsoft.EntityFrameworkCore;
using Web_Form_API.Repository;

namespace Web_Form_API
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
            // setting up application to connect with environment variable
            var connectionString = Environment.GetEnvironmentVariable("WebFormAPI_DB_ConnectionString");


            // DB context using sql server, connection using environment variable 
            services.AddDbContext<FormDBContext>(options =>
            options.UseSqlServer(connectionString));  


            // FormsRespositoy dependency injection for application
            services.AddScoped<IFormsRespository, FormsRespository>();

            // user repository dependency injection
            services.AddScoped<IUsersRepository, UsersRepository>();

            // Generic Repository depency injection 
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            
            services.AddScoped(typeof(DbContext), typeof(FormDBContext));


            /* Adding these options allowed me to make request from th Web Form Frontend project*/
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000", "https://web-form-frontend.netlify.app") 
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials(); 
                });
            });


            // Ensure data is sent in Pascal case
            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });
            
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Form API", Version = "v1" });

                // Add support for XML comments
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // else condition added to handle cors when deployed
            else 
            { 
                app.UseExceptionHandler("/Home/Error"); 
                app.UseHsts(); 
            }

            app.UseHttpsRedirection();

            // Serve static files (to be used later if needed)
            app.UseStaticFiles(); // Uncomment this line if you add static files to serve

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Form API v1");
                options.RoutePrefix = string.Empty; // Set the Swagger UI at the root URL
            });

            app.UseRouting();

            app.UseCors("AllowAllOrigins"); // Enable CORS before authorization so frontend can use API

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
