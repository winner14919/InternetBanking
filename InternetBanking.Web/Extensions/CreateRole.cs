using InternetBanking.Core.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBanking.Web.Extensions
{
	public static class CreateRole
	{
		public static void Create(IServiceProvider serviceProvider, IConfiguration configuration)
		{
			//adding custom roles
			var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();
			string[] roleNames = { "Admin", "Manager", "Member" };
			IdentityResult roleResult;
            foreach (var roleName in roleNames)
			{
				//creating the roles and seeding them to the database
				var roleExist =  RoleManager.RoleExistsAsync(roleName).Result;
				if (!roleExist)
				{
					roleResult = RoleManager.CreateAsync(new IdentityRole(roleName)).Result;
				}
			}
            //creating a super user who could maintain the web app
            var poweruser = new User
			{
				UserName = configuration.GetSection("UserSettings")["UserEmail"],
				Email = configuration.GetSection("UserSettings")["UserEmail"]
			};
            string UserPassword = configuration.GetSection("UserSettings")["UserPassword"];
			var _user = UserManager.FindByEmailAsync(configuration.GetSection("UserSettings")["UserEmail"]).Result;
            if (_user == null)
			{
				var createPowerUser = UserManager.CreateAsync(poweruser, UserPassword).Result;
				if (createPowerUser.Succeeded)
				{
					//here we tie the new user to the "Admin" role 
					var role =  UserManager.AddToRoleAsync(poweruser, "Admin").Result;
                    }
			}
		}
	}
}
