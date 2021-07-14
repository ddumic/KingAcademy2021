using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KingICT.Akademija2021.Repository.ModelBuilders
{
	public class AcademyModelBuilder : IEntityTypeConfiguration<Model.Academy.Academy>
	{
		public void Configure(EntityTypeBuilder<Model.Academy.Academy> builder)
		{
			builder
				.ToTable("Akademija", "dbo")
				.HasKey(e => e.Id);
		}
	}
}
