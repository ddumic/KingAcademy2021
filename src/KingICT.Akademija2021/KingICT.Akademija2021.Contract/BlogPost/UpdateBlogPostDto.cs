namespace KingICT.Akademija2021.Contract.BlogPost
{
	public class UpdateBlogPostDto
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Text { get; set; }

		public int UserId { get; set; }
	}
}
