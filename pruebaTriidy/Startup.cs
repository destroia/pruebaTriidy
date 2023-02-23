using AutoMapper;
using Data;
using Data.AccesData;
using Data.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
using pruebaTriidy.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaTriidy
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "pruebaTriidy", Version = "v1" });
            });

            var tokenPro = new JwtProvider("issuer", "audience", "norn");
            services.AddSingleton<ITokenProvider>(tokenPro);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.RequireHttpsMetadata = true;
                    opt.TokenValidationParameters = tokenPro.GetTokenValidation();
                });
            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });

            var mapperConfug = new MapperConfiguration(x => {
                x.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfug.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvcCore();

            services.AddDbContext<contextDBTriidy>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionMain")));
            services.AddScoped<ICitiesData, ContryData>();
            services.AddScoped<ICityData, CityData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "pruebaTriidy v1"));
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
