using KingICT.Akademija2021.Contract.BlogPost;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KingICT.Akademija2021.WebAPI.Controllers
{
	[ApiController, Route("api/v{version:apiVersion}/blog-posts"), ApiVersion("1")]
	public class BlogPostController : ControllerBase
	{
		private readonly IBlogPostService _blogPostService;

		public BlogPostController(IBlogPostService blogPostService)
		{
			_blogPostService = blogPostService;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBlogPostByIdAsync([FromRoute] int id)
		{
			return Ok(await _blogPostService.GetBlogPostByIdAsync(id));
		}

		[HttpGet("")]
		public async Task<IActionResult> GetBlogPostsAsync()
		{
			return Ok(await _blogPostService.GetBlogPostsAsync());
		}


		[HttpPost("")]
		public async Task<IActionResult> CreateBlogPostAsync([FromBody] CreateBlogPostDto blogPost)
		{
			try
			{
				return Ok(await _blogPostService.CreateBlogPostAsync(blogPost));
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateBlogPostAsync([FromRoute] int id, [FromBody] UpdateBlogPostDto blogPost)
		{
			if (id != blogPost.Id)
			{
				return BadRequest(nameof(blogPost.Id));
			}

			try
			{
				return Ok(await _blogPostService.UpdateBlogPostAsync(blogPost));
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBlogPostByIdAsync([FromRoute] int id)
		{
			try
			{
				await _blogPostService.DeleteBlogPostByIdAsync(id);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok();
		}
	}
}
