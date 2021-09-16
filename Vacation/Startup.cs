using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using ItmCode.Common.Identity.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Vacation.Entities;
using Vacation.Middleware;
using Vacation.Models;
using Vacation.Models.Validation;
using Vacation.Services;


namespace Vacation
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

            services.ConfigureIdentity(Configuration);
            services.AddDbContext<VacationDbContext>();
            services.AddControllers();

            services.AddScoped<IValidator<CreateUserModel>,CreateUserModelValidator>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IDepartmentService,DepartmentService>();

            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddControllers().AddFluentValidation();
            services.AddAutoMapper(this.GetType().Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vacation", Version = "v1" });
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vacation v1"));
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseAuthentication().UseAuthorization();

          //  app.UseHttpsRedirection();


            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
