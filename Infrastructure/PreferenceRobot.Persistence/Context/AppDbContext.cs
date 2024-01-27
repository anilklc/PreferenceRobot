using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PreferenceRobot.Domain.Common;
using PreferenceRobot.Domain.Entities;
using PreferenceRobot.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<User,Role,string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UniversityInfo> Universities { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas) 
            {
                var _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    _ => DateTime.Now
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
