using AutoMapper;
using CodeSample.Models;
using CodeSample.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSample.Services
{
    public class ClientService: IClientService
	{
		private readonly IClientRepository _repository;
		public ClientService(
			IClientRepository repository)
		{
			_repository = repository;
		}

		public IEnumerable<Client> GetAll()
		{
			return _repository.AllIncluding(u => u.Identity).OrderBy(u => u.Id);	
		}

		public async Task<Client> GetById(string id)
		{
			Client client= await _repository.GetSingle(u => u.Id == id, u => u.Identity);
			return client;
		}

		public async Task<Client> GetByIdentityId(string identityId)
		{
			Client client = await _repository.GetSingle(u => u.IdentityId == identityId, u => u.Identity);
			return client;
		}

		public async Task Delete(string id)
		{
			var entity = await _repository.GetSingle(u => u.Id == id, u => u.Identity);

			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			await _repository.Delete(entity);
		}

		public async Task Delete(Client client)
		{
			if (client == null)
			{
				throw new ArgumentNullException(nameof(client));
			}

			await _repository.Delete(client);
		}

		public int GetCount()
		{
			return _repository.Count();
		}

		public async Task Save(Client oldClient, Client client)
		{
			if (client == null)
			{
				throw new ArgumentNullException(nameof(client));
			}
			if (string.IsNullOrEmpty(client.Id))
			{
				await _repository.Add(client);
				return;
			}

			if (oldClient == null)
				await _repository.Add(client);
			else
				await _repository.Update(oldClient, client);
		}
	}
}
