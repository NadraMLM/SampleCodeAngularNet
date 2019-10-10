using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CodeSample.Models;
using CodeSample.Services;
using CodeSample.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CodeSample.Controllers
{
	[Route("api/[controller]")]
	public class ClientController : Controller
	{
		private readonly IClientService _clientService;
		protected readonly UserManager<IdentityUser> _userManager;
		private readonly IMapper _mapper;

		public ClientController(IClientService clientService,
			UserManager<IdentityUser> userManager,
			IMapper mapper) :base()
		{
			_clientService = clientService;
			_userManager = userManager;
			_mapper = mapper;
		}

		#region GETALLCLIENTS
		[HttpGet("[action]")]
		public IEnumerable<ClientViewModel> GetAll()
		{
			IEnumerable<Client> clients = _clientService.GetAll();
			return _mapper.Map<IEnumerable<ClientViewModel>>(clients);
		}
		#endregion

		#region GETBYID
		[HttpGet("[action]")]
		public async Task<ClientViewModel> GetById(string id)
		{
			Client client = await _clientService.GetById(id);
			return _mapper.Map<ClientViewModel>(client);
		}
		#endregion

		#region SAVECLIENT
		[HttpPost("[action]")]
		public async Task<IActionResult> Save([FromBody] SaveClientViewModel client)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			Client clientM = _mapper.Map<Client>(client);
			var oldEntity = await _clientService.GetById(client.Id);

			if (oldEntity != null)
			{
				IdentityUser user = oldEntity.Identity;
				if (user.Email != client.Email)
				{
					user.Email = client.Email;
					user.UserName = client.Email;
					await _userManager.UpdateAsync(user);
					clientM.Identity = user;
				}

				await _clientService.Save(oldEntity, clientM);
				return Ok(new { message = "Client updated" });
			}
			else
			{
				clientM.Identity.SecurityStamp = Guid.NewGuid().ToString();
				await _clientService.Save(oldEntity, clientM);
				return Ok(new { message = "Client added" });
			}
		}
		#endregion

		#region DeleteCLIENT
		[HttpDelete("[action]")]
		public async Task<IActionResult> Delete(string id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Client client =await _clientService.GetById(id);
			if(client == null)
			{
				return NotFound();
			}
			await _clientService.Delete(id);
			await _userManager.DeleteAsync(client.Identity);
			return Ok(new { message = "Client deleted" });
		}
		#endregion
	}
}
