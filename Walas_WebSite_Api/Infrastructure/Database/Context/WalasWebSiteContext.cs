using Infrastructure.Database.Entitites.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context
{
    public class WalasWebSiteContext(DbContextOptions<WalasWebSiteContext> options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        #region DBSets
        public virtual DbSet<UserEntity> User { get; set; }

        #endregion
    }
}
