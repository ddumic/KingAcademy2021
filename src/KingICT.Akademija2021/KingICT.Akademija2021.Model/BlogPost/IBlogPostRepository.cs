using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingICT.Akademija2021.Model.BlogPost
{
	public interface IBlogPostRepository
	{
		Task<BlogPost> GetBlogPostByIdAsync(int id);

		Task<IEnumerable<BlogPost>> GetBlogPostsAsync();

		Task<IEnumerable<BlogPost>> GetBlogPostsByUserIdAsync(int userId);

		Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost);

		Task<BlogPost> UpdateBlogPostAsync(BlogPost blogPost);

		Task<bool> DeleteBlogPostAsync(BlogPost blogPost);
	}
}
