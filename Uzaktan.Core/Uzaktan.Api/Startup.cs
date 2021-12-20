using FluentValidation.AspNetCore;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authentication.JwtBearer;
=======
>>>>>>> 218d2fe05b357eafa4273f988f16f8c8ac457bf6
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
<<<<<<< HEAD
using System.Text;
=======
>>>>>>> 218d2fe05b357eafa4273f988f16f8c8ac457bf6
using Uzaktan.Core.Mappers;
using Uzaktan.Core.Repositories;
using Uzaktan.Core.Service;
using Uzaktan.Data.SqlServer;
using Uzaktan.Data.SqlServer.Repositories;
using Uzaktan.Services;

namespace Uzaktan.Api
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
            //Jwt Token için eklenen ifadeler
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            services.AddDbContext<MembershipContext>();

            services.AddIdentity<IdentityUser, IdentityRole>(opt=> {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireDigit = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<MembershipContext>();


            services.AddControllers();

            //FluentValidation ekleniyor
            services.AddFluentValidation(v=>v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            //Validation Tipler DI container'a ekleniyor

            //CategoryRepository ekleniyor.
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            //CategoryService ekleniyor
            services.AddScoped<ICategoryService, CategoryService>();

            //CategoryService ekleniyor
            services.AddScoped<IAccountService, AccountService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Uzaktan.Api", Version = "v1" });
            });

            services.AddAutoMapper(
                typeof(CategoryMapper)    
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Uzaktan.Api v1"));
            }

            app.UseAuthentication();

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
