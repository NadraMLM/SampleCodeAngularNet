using CodeSample.Data;
using CodeSample.Models;

namespace CodeSample.Repositories
{
	public class ClientRepository: EntityRepository<Client>, IClientRepository
    {
		public ClientRepository(ApplicationDbContext context) : base(context) { }
    }
}
