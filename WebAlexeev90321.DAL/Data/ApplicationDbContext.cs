using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAlexeev90321.DAL.Entities;


namespace WebAlexeev90321.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<RadioComponent> RadioComponents { get; set; }
        public DbSet<RadioComponentGroup> RadioComponentGroups { get; set; }

        public
       ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
    }
}
