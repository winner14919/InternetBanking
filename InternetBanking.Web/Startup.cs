using InternetBanking.Core;
using InternetBanking.Core.Admin;
using InternetBanking.Core.Currency.Rate;
using InternetBanking.Core.Order;
using InternetBanking.Core.TransactionService;
using InternetBanking.Core.User;
using InternetBanking.Data.Context;
using InternetBanking.Data.Repository;
using InternetBanking.Web.Extensions;
using InternetBanking.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InternetBanking.Web
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
            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

			services.AddDbContext<TransactionDbContext>(options =>
			   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

			services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddSingleton<IEmailSender, EmailSender>();

			services.AddSingleton<IRepository<TransactionOrder>, TransactionRepository>();

			services.AddSingleton<IRepository<User>, UserRepository>();

			services.AddSingleton<ITransactionService, TransferService>();


			services.AddMvc();

			Resource.Init();
			SetDefault.Set();

			//var config = new AutoMapper.MapperConfiguration(cfg =>
			//{
			//	cfg.AddProfile(new AutoMapperProfileConfiguration());
			//});

			//var mapper = config.CreateMapper();
			//services.AddSingleton(mapper);
			//services.AddMvc();

		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

			CreateRole.Create(serviceProvider, configuration).Wait();

		}
    }
}
