using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Onion.Core.Entities;
using Onion.Core.Enums;
using Onion.DataAccess.Abstractions;
using Onion.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.DataAccess.DataInitializers
{
    internal class DbContextInitializer : IContextInitializer
    {

        private readonly AppDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly string _adminUsername;
        private readonly string _adminEmail;
        private readonly string _adminFullname;
        private readonly string _adminPassword;

        public DbContextInitializer(AppDbContext context, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;

            var section = _configuration.GetSection("AdminSettings");

            _adminEmail = section.GetValue<string>("Email")!;
            _adminUsername = section.GetValue<string>("Username")!;
            _adminPassword = section.GetValue<string>("Password")!;
            _adminFullname = section.GetValue<string>("Fullname")!;
        }

        public async Task InitDatabaseAsync()
        {
            await _context.Database.MigrateAsync();

            await CreateRolesAsync();

            await CreateAdminAsync();


        }

        private async Task CreateAdminAsync()
        {
            AppUser adminUser = new()
            {
                Email = _adminEmail,
                UserName = _adminUsername,
                FullName = _adminFullname,
            };


            var result = await _userManager.CreateAsync(adminUser, _adminPassword);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(adminUser, IdentityRoles.Admin.ToString());
            }
        }

        private async Task CreateRolesAsync()
        {
            foreach (var role in Enum.GetNames(typeof(IdentityRoles)))
            {
                AppRole appRole = new()
                {
                    Name = role
                };

                await _roleManager.CreateAsync(appRole);
            }
        }
    }
}
