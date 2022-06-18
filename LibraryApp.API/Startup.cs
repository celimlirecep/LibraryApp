using LibraryApp.API.Identity;
using LibraryApp.BL.Abstract;
using LibraryApp.BL.Concreate;
using LibraryApp.DAL.Abstract;
using LibraryApp.DAL.Concreate.EfCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyPolicy = "_MyAllowAll";
        private readonly string key = "we push the impossible to see the limits of possibility";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
    
            services.AddDbContext<LibraryContext>(options => options.UseSqlite(Configuration.GetConnectionString("SqLiteConnection")));
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite(Configuration.GetConnectionString("SqLiteConnection")));

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            services.AddAuthentication(configureOptions =>
            {
                configureOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                configureOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                
                
            }).AddJwtBearer(x => {

                //No metadata needed when sending http packet
                
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime=true,
                    RequireExpirationTime=true
                };
            });

          



            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserCardService, UserCardManager>();
            services.AddScoped<IBookService, BookManager>();
            services.AddCors(
               options =>
               {
                   options.AddPolicy(
                       name: MyPolicy,
                       policy =>
                       {
                           policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                       });
               });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryApp.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryApp.API v1"));
            }

            app.UseHttpsRedirection();
        
            app.UseCors(MyPolicy);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
