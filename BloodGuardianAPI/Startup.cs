using BloodGuardianAPI.Business;
using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Data;
using BloodGuardianAPI.DataAccess;
using BloodGuardianAPI.DataAccess.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BloodGuardianAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        private IConfiguration _config;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("BloodGuardianDBConn"));
            });

            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BloodGuardian",
                    Description = "A blood drop can save a life.",
                });
            });

            services.AddScoped<IBloodRequestsBusiness, BloodRequestsBusiness>();
            services.AddScoped<IAuthBusiness, AuthBusiness>();
            services.AddScoped<IBloodBankBusiness, BloodBankBusiness>();
            services.AddScoped<IBloodDonationCampBusiness, BloodDonationCampBusiness>();
            services.AddScoped<IBloodTransferReceiptsBusiness, BloodTransferReceiptsBusiness>();
            services.AddScoped<IUsersBusiness, UsersBusiness>();
            services.AddScoped<IUsersData, UsersData>();
            services.AddScoped<IBloodBanksData, BloodBanksData>();
            services.AddScoped<IBloodDonationCampsData, BloodDonationCampsData>();
            services.AddScoped<IBloodTransferReceiptsData, BloodTransferReceiptsData>();
            services.AddScoped<IBloodRequestsData,BloodRequestsData>();




            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing API V1");
                });
            }



            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
