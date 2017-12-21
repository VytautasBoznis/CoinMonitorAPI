using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CoinMonitroDomainLayer.Entities;

namespace CoinMonitroDomainLayer.Contexts
{
	public class UserContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<KeyAndSecret> KeysAndSecrets { get; set; }
		public DbSet<CoinModel> CoinModels { get; set; }
		
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Entity<User>()
				.HasMany(u => u.CoinModel);

			modelBuilder.Entity<CoinModel>()
				.HasKey(cm => new {cm.CoinModelID, cm.UserId})
				.Property(cm => cm.CoinModelID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			modelBuilder.Entity<User>()
				.HasMany(u => u.KeysAndSecrets);

			modelBuilder.Entity<KeyAndSecret>()
				.HasKey(ks => new { ks.PairId, ks.UserId })
				.Property(ks => ks.PairId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
	}
}
