using Microsoft.EntityFrameworkCore;

namespace KingICT.Akademija2021.Repository.Common
{
	public class AcademyDbContext : DbContext
	{
		public virtual DbSet<Model.Academy.Academy> Academies { get; set; }

		public virtual DbSet<Model.User.User> Users { get; set; }

		public virtual DbSet<Model.BlogPost.BlogPost> BlogPosts { get; set; }


		public AcademyDbContext(DbContextOptions<AcademyDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcademyDbContext).Assembly);
		}
	}
}
