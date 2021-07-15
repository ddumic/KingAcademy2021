using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KingICT.Akademija2021.Repository.ModelBuilders
{
	public class UserModelBuilder : IEntityTypeConfiguration<Model.User.User>
	{
		public void Configure(EntityTypeBuilder<Model.User.User> builder)
		{
			builder
				.ToTable("User", "dbo")
				.HasKey(e => e.Id);
		}
	}
}
