using KingICT.Akademija2021.Configuration;
using KingICT.Akademija2021.Contract.Academy;
using KingICT.Akademija2021.Contract.BlogPost;
using KingICT.Akademija2021.Contract.User;
using KingICT.Akademija2021.Model.Academy;
using KingICT.Akademija2021.Model.BlogPost;
using KingICT.Akademija2021.Model.User;
using KingICT.Akademija2021.Repository.Academy;
using KingICT.Akademija2021.Repository.BlogPost;
using KingICT.Akademija2021.Repository.Common;
using KingICT.Akademija2021.Repository.User;
using KingICT.Akademija2021.Service.Academy;
using KingICT.Akademija2021.Service.BlogPost;
using KingICT.Akademija2021.Service.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KingICT.Akademija2021.WebAPI
{
	public class Startup
	{
		public IConfiguration Configuration { get; }


		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(options =>
			{
				options.EnableEndpointRouting = false;
			}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

			services.AddApiVersioning(o =>
			{
				o.ReportApiVersions = true;
				o.AssumeDefaultVersionWhenUnspecified = true;
				o.DefaultApiVersion = new ApiVersion(1, 0);
			});

			services.AddControllers();

			var dbConfig = Configuration.GetSection(nameof(DatabaseConfiguration)).Get<DatabaseConfiguration>();

			services.AddTransient<IAcademyService, AcademyService>();
			services.AddTransient<IAcademyRepository, AcademyRepository>();
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IBlogPostService, BlogPostService>();
			services.AddTransient<IBlogPostRepository, BlogPostRepository>();

			services
				.AddDbContext<AcademyDbContext>
				(
					options => options.UseSqlServer(dbConfig.ConnectionString), ServiceLifetime.Singleton
				);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
				app.UseHttpsRedirection();
			}

			app.UseMvc();
		}
	}
}
