using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeSample.Models
{
	public class Client: IEntity
	{
		public Client() : base() {
			CreationDate = DateTime.Now.ToString();
		}
		public Client(string firstName, string lastName) : base()
		{
			CreationDate = DateTime.Now.ToString();
			FirstName = firstName;
			LastName = lastName;
		}

		[Key]
		public string Id { get; set; }
		public string IdentityId { get; set; }
		public virtual IdentityUser Identity { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string CreationDate { get; set; }
	}
}
