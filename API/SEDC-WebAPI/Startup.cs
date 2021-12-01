using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SEDC_WebAPI.Middlewares;
using SEDC_WebAPI.Repositories.Implementations;
using SEDC_WebAPI.Repositories.Interfaces;
using SEDC_WebAPI.Services.Implementations;
using SEDC_WebAPI.Services.Interfaces;
using SEDC_WebApplication.BLL.Logic.Implementations;
using SEDC_WebApplication.BLL.Logic.Interfaces;
using SEDC_WebApplicationDataBaseFactory;
using SEDC_WebApplicationDataBaseFactory.GenericRepository;
using SEDC_WebApplicationDataBaseFactory.Implementations;
using SEDC_WebApplicationDataBaseFactory.Interfaces;
//using SEDC_WebApplicationEntityFactory.Implementations;
//using SEDC_WebApplicationEntityFactory.Interfaces;
//using SEDC_WebApplication.DAL.Data.Implementations;
//using SEDC_WebApplication.DAL.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebAPI
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
            //services.AddControllers(options =>
            //{
            //    var jsonInputFormatter = options.InputFormatters
            //    .OfType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>()
            //    .Last();
            //    jsonInputFormatter.SupportedMediaTypes.Add("application/csp-report");
            //    jsonInputFormatter.SupportedMediaTypes.Add("application/json");
            //});

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SEDC2")));

            // configuration of JWT Authentication
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings")["Secret"]);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });

            services.AddAutoMapper(typeof(EmployeeManager));
            services.AddAutoMapper(typeof(CustomerManager));
            services.AddAutoMapper(typeof(ProductManager));
            services.AddAutoMapper(typeof(OrderManager));


            //services.AddScoped<ICustomerRepository, DataBaseCustomerRepository>();
            //services.AddScoped<IProductRepository, DataBaseProductRepository>();
            //services.AddScoped<IEmployeeRepository, DataBaseEmployeeRepository>();
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IUserService, UserService>();

            //BLL
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IUserManager, UserManager>();

            //DAL 
            //services.AddScoped<IEmployeeDAL, EmployeeDAL>();
            services.AddScoped<IEmployeeDAL, EmployeeRepository>();
            //services.AddScoped<ICustomerDAL, CustomerDAL>();
            services.AddScoped<ICustomerDAL, CustomerRepository>();
            //services.AddScoped<IProductDAL, ProductDAL>();
            services.AddScoped<IProductDAL, ProductRepository>();
            services.AddScoped<IOrderDAL, OrderRepository>();
            services.AddScoped<IUserDAL, UserRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SEDC_WebAPI", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SEDC_WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            //custom jwt middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
