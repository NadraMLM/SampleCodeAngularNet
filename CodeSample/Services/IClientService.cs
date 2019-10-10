using CodeSample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeSample.Services
{
	public interface IClientService
    {
		Task Save(Client oldClient, Client client);
		Task Delete(string id);
		Task Delete(Client client);
		int GetCount();
		IEnumerable<Client> GetAll();
		Task<Client> GetById(string id);
		Task<Client> GetByIdentityId(string identityId);
	}
}
