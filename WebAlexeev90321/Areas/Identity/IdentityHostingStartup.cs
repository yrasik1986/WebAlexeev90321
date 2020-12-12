using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAlexeev90321.DAL.Data;
using WebAlexeev90321.DAL.Entities;

[assembly: HostingStartup(typeof(WebAlexeev90321.Areas.Identity.IdentityHostingStartup))]
namespace WebAlexeev90321.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}