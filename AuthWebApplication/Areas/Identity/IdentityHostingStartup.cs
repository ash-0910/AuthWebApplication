﻿using System;
using AuthWebApplication.Areas.Identity.Data;
using AuthWebApplication.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AuthWebApplication.Areas.Identity.IdentityHostingStartup))]
namespace AuthWebApplication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthWebApplicationContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthWebApplicationContextConnection")));

                services.AddDefaultIdentity<AuthWebApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AuthWebApplicationContext>();
            });
        }
    }
}