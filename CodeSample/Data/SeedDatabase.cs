using CodeSample.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSample.Data
{
	public class SeedDatabase
	{
		private List<Client> GetClients()
		{
			List<Client> clients = new List<Client>
			{
				new Client{
					FirstName="jhon",
					LastName="doe",
					CreationDate=DateTime.Now.ToString(),
					Identity=new IdentityUser
					{
						UserName="john.doe@email.com",
						Email="john.doe@email.com",
						SecurityStamp = Guid.NewGuid().ToString()
					}
				}
				,
				new Client{
					FirstName="carry",
					LastName="doe",
					CreationDate=DateTime.Now.ToString(),
					Identity=new IdentityUser
					{
						UserName="carry.doe@email.com",
						Email="caarry.doe@email.com",
						SecurityStamp = Guid.NewGuid().ToString()
					}
				}
			};
			return clients;
		}

		public async Task SeedClients(ApplicationDbContext _context)
		{
			var userStore = new UserStore<IdentityUser>(_context);
			List<Client> clients = GetClients();
			foreach(Client client in clients)
			{
				await userStore.CreateAsync(client.Identity);
				client.IdentityId = client.Identity.Id;
				_context.Add(client);
			}
			await _context.SaveChangesAsync();
		}

		public async Task Initialize(IApplicationBuilder app)
		{
			var provider = app.ApplicationServices;
			var scopeFactory = provider.GetRequiredService<IServiceScopeFactory>();

			using (var scope = scopeFactory.CreateScope())
			using (var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
			{
				context.Database.EnsureCreated();

				if (context.Clients == null || !context.Clients.Any())
					await SeedClients(context);
			}
		}
	}
}
