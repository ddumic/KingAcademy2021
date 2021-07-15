using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KingICT.Akademija2021.Repository.ModelBuilders
{
	public class BlogPostModelBuilder : IEntityTypeConfiguration<Model.BlogPost.BlogPost>
	{
		public void Configure(EntityTypeBuilder<Model.BlogPost.BlogPost> builder)
		{
			builder
				.ToTable("BlogPost", "dbo")
				.HasKey(e => e.Id);
		}
	}
}
