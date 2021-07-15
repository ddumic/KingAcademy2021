using KingICT.Akademija2021.Contract.BlogPost;
using KingICT.Akademija2021.Model.BlogPost;
using KingICT.Akademija2021.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingICT.Akademija2021.Service.BlogPost
{
	public class BlogPostService : IBlogPostService
	{
		private readonly IBlogPostRepository _blogPostRepository;
		private readonly IUserRepository _userRepository;

		public BlogPostService(IBlogPostRepository blogPostRepository, IUserRepository userRepository)
		{
			_blogPostRepository = blogPostRepository;
			_userRepository = userRepository;
		}

		public async Task<BlogPostDto> CreateBlogPostAsync(CreateBlogPostDto blogPostDto)
		{
			if (string.IsNullOrWhiteSpace(blogPostDto.Title))
			{
				throw new ArgumentException(nameof(blogPostDto.Title));
			}

			if (string.IsNullOrWhiteSpace(blogPostDto.Text))
			{
				throw new ArgumentException(nameof(blogPostDto.Text));
			}

			var user = await _userRepository.GetUserByIdAsync(blogPostDto.UserId);

			if (user is null)
			{
				throw new ArgumentException(nameof(blogPostDto.UserId));
			}

			var blogPostObject = new Model.BlogPost.BlogPost();
			blogPostObject.SetTitle(blogPostDto.Title);
			blogPostObject.SetText(blogPostDto.Text);
			blogPostObject.SetUserId(blogPostDto.UserId);

			var blogPost = await _blogPostRepository.CreateBlogPostAsync(blogPostObject);

			return new BlogPostDto
			{
				Id = blogPost.Id,
				Text = blogPost.Text,
				Title = blogPost.Title,
				UserId = blogPost.UserId
			};
		}

		public async Task<bool> DeleteBlogPostByIdAsync(int id)
		{
			var blogPost = await _blogPostRepository.GetBlogPostByIdAsync(id);

			if (blogPost is null)
			{
				throw new ArgumentException(nameof(id));
			}

			await _blogPostRepository.DeleteBlogPostAsync(blogPost);

			return true;
		}

		public async Task<BlogPostDto> GetBlogPostByIdAsync(int id)
		{
			var blogPost = await _blogPostRepository.GetBlogPostByIdAsync(id);

			return new BlogPostDto
			{
				Id = blogPost.Id,
				Text = blogPost.Text,
				Title = blogPost.Title,
				UserId = blogPost.UserId
			};
		}

		public async Task<IEnumerable<BlogPostDto>> GetBlogPostsAsync()
		{
			var blogPosts = await _blogPostRepository.GetBlogPostsAsync();

			return blogPosts.Select(blogPost => new BlogPostDto
			{
				Id = blogPost.Id,
				Text = blogPost.Text,
				Title = blogPost.Title,
				UserId = blogPost.UserId
			});
		}

		public async Task<IEnumerable<BlogPostDto>> GetBlogPostsByUserIdAsync(int userId)
		{
			var blogPosts = await _blogPostRepository.GetBlogPostsByUserIdAsync(userId);

			return blogPosts.Select(blogPost => new BlogPostDto
			{
				Id = blogPost.Id,
				Text = blogPost.Text,
				Title = blogPost.Title,
				UserId = blogPost.UserId
			});
		}

		public async Task<BlogPostDto> UpdateBlogPostAsync(UpdateBlogPostDto blogPostDto)
		{
			if (string.IsNullOrWhiteSpace(blogPostDto.Title))
			{
				throw new ArgumentException(nameof(blogPostDto.Title));
			}

			if (string.IsNullOrWhiteSpace(blogPostDto.Text))
			{
				throw new ArgumentException(nameof(blogPostDto.Text));
			}

			var blogPost = await _blogPostRepository.GetBlogPostByIdAsync(blogPostDto.Id);

			if (blogPost is null)
			{
				throw new ArgumentException(nameof(blogPostDto.Id));
			}

			var user = await _userRepository.GetUserByIdAsync(blogPostDto.UserId);

			if (user is null)
			{
				throw new ArgumentException(nameof(blogPostDto.UserId));
			}

			blogPost.SetTitle(blogPostDto.Title);
			blogPost.SetText(blogPostDto.Text);
			blogPost.SetUserId(blogPostDto.UserId);

			await _blogPostRepository.UpdateBlogPostAsync(blogPost);

			return new BlogPostDto
			{
				Id = blogPost.Id,
				Text = blogPost.Text,
				Title = blogPost.Title,
				UserId = blogPost.UserId
			};
		}
	}
}
