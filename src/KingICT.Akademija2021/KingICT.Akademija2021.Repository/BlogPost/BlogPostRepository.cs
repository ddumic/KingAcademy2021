using KingICT.Akademija2021.Model.BlogPost;
using KingICT.Akademija2021.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingICT.Akademija2021.Repository.BlogPost
{
	public class BlogPostRepository : IBlogPostRepository
	{
		private readonly AcademyDbContext _dbContext;

		public BlogPostRepository(AcademyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Model.BlogPost.BlogPost> GetBlogPostByIdAsync(int id)
		{
			return await _dbContext.Set<Model.BlogPost.BlogPost>()
				.Where(x => x.Id == id)
				.SingleOrDefaultAsync();
		}

		public async Task<IEnumerable<Model.BlogPost.BlogPost>> GetBlogPostsAsync()
		{
			return await _dbContext.Set<Model.BlogPost.BlogPost>()
				.ToListAsync();
		}

		public async Task<IEnumerable<Model.BlogPost.BlogPost>> GetBlogPostsByUserIdAsync(int userId)
		{
			return await _dbContext.Set<Model.BlogPost.BlogPost>()
				.Where(x => x.UserId == userId)
				.ToListAsync();
		}

		public async Task<Model.BlogPost.BlogPost> CreateBlogPostAsync(Model.BlogPost.BlogPost blogPost)
		{
			await _dbContext.Set<Model.BlogPost.BlogPost>()
				.AddAsync(blogPost);

			await _dbContext.SaveChangesAsync();

			return blogPost;
		}

		public async Task<Model.BlogPost.BlogPost> UpdateBlogPostAsync(Model.BlogPost.BlogPost blogPost)
		{
			_dbContext.Set<Model.BlogPost.BlogPost>()
				.Update(blogPost);

			await _dbContext.SaveChangesAsync();

			return blogPost;
		}

		public async Task<bool> DeleteBlogPostAsync(Model.BlogPost.BlogPost blogPost)
		{
			_dbContext.Set<Model.BlogPost.BlogPost>()
				.Remove(blogPost);

			await _dbContext.SaveChangesAsync();

			return true;
		}
	}
}
