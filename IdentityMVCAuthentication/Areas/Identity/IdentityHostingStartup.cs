using System;
using IdentityMVCAuthentication.Areas.Identity.Data;
using IdentityMVCAuthentication.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(IdentityMVCAuthentication.Areas.Identity.IdentityHostingStartup))]
namespace IdentityMVCAuthentication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityMVCAuthenticationContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityMVCAuthenticationContextConnection")));

                services.AddDefaultIdentity<IdentityMVCAuthenticationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityMVCAuthenticationContext>();
            });
        }
    }
}