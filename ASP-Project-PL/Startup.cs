using ASP_Project_BLL.Interface;
using ASP_Project_BLL.Mapper;
using ASP_Project_BLL.Repository;
using ASP_Project_DAL.DataBase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project_PL
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
           services.AddControllersWithViews().AddNewtonsoftJson(opt => {
               opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
           });
            services.AddControllersWithViews();
            services.AddDbContextPool<DbContainer>(opts =>
            opts.UseSqlServer(Configuration.GetConnectionString("DataConnection")));
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
            services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<ICountryRepo, CountryRepo>();
            services.AddScoped<ICityRep, CityRepo>();
            services.AddScoped<IDistrictRepo,DistrictRepo>();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DbContainer>().AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider); ;
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
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


          

           
            app.UseEndpoints(endpoints =>
            {
          
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
            
        }
    }
}
