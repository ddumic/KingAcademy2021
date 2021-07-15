using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingICT.Akademija2021.Contract.BlogPost
{
	public interface IBlogPostService
	{
		Task<BlogPostDto> GetBlogPostByIdAsync(int id);

		Task<IEnumerable<BlogPostDto>> GetBlogPostsAsync();

		Task<IEnumerable<BlogPostDto>> GetBlogPostsByUserIdAsync(int userId);

		Task<BlogPostDto> CreateBlogPostAsync(CreateBlogPostDto blogPostDto);

		Task<BlogPostDto> UpdateBlogPostAsync(UpdateBlogPostDto blogPostDto);

		Task<bool> DeleteBlogPostByIdAsync(int id);
	}
}
