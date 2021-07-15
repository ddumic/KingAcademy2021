namespace KingICT.Akademija2021.Model.User
{
	public class User
	{
		public int Id { get; private set; }

		public string FirstName { get; private set; }

		public string LastName { get; private set; }


		public void SetFirstName(string firstName)
		{
			FirstName = firstName;
		}

		public void SetLastName(string lastName)
		{
			LastName = lastName;
		}
	}
}
