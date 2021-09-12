using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SEDC_WebApplication.BLL.Logic.Interfaces;
using SEDC_WebApplication.BLL.Logic.Implementations;
using SEDC_WebApplication.Models.Repositories.Implementations;
using SEDC_WebApplication.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDC_WebApplication.DAL.Data.Interfaces;
using SEDC_WebApplication.DAL.Data.Implementations;

namespace SEDC_WebApplication
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
            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(EmployeeManager));
            services.AddAutoMapper(typeof(CustomerManager));
            services.AddAutoMapper(typeof(ProductManager));


            services.AddScoped<ICustomerRepository, DataBaseCustomerRepository>();

            services.AddScoped<IProductRepository, DataBaseProductRepository>();

            services.AddScoped<IEmployeeRepository, DataBaseEmployeeRepository>();

            //BLL
            services.AddScoped<IEmployeeManager, EmployeeManager>();

            services.AddScoped<ICustomerManager, CustomerManager>();

            services.AddScoped<IProductManager, ProductManager>();

            //DAL 
            services.AddScoped<IEmployeeDAL, EmployeeDAL>();

            services.AddScoped<ICustomerDAL, CustomerDAL>();

            services.AddScoped<IProductDAL, ProductDAL>();

            //services.AddScoped<IOrderDAL, OrderDAL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
