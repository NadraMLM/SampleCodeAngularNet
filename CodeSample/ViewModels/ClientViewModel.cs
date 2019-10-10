namespace CodeSample.ViewModels
{
	public class ClientViewModel
    {
		public string Id { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string CreationDate { get; set; }
		public ClientViewModel()
		{
		}

		public ClientViewModel(string id, string email, string firstName, string lastName, string creationDate)
		{
			Id = id;
			Email = email;
			FirstName = firstName;
			LastName = lastName;
			CreationDate = creationDate;
		}
	}
}
