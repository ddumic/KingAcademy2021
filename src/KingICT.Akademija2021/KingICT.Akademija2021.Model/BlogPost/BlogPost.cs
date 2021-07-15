namespace KingICT.Akademija2021.Model.BlogPost
{
	public class BlogPost
	{
		public int Id { get; private set; }

		public string Title { get; private set; }

		public string Text { get; private set; }

		public int UserId { get; private set; }


		public void SetTitle(string title)
		{
			Title = title;
		}

		public void SetText(string text)
		{
			Text = text;
		}

		public void SetUserId(int userId)
		{
			UserId = userId;
		}
	}
}
