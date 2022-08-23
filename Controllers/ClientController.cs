using CardStorageService.Data;
using CardStorageService.Models.Requests;
using CardStorageService.Models.Responses;
using CardStorageService.Services.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;

namespace CardStorageService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClientController : ControllerBase
	{
		private readonly IClientRepository _repository;

		public ClientController(IClientRepository repository)
		{
			_repository = repository;
		}

		[HttpPost]
		public ActionResult<CreateClientResponse> Create([FromBody] CreateClientRequest request)
		{
			try
			{
				var client = _repository.Create(new Client
				{
					FirstName = request.FirstName,
					Surname =  request.Surname,
					Patronymic = request.Patronimic
				});

				var response = new CreateClientResponse();

				response.ClientId = client;

				response.ResponseCode = 0;

				response.Message = "Success";

				return Ok(response);
			}
			catch (Exception)
			{
				var response = new CreateClientResponse();

				response.ResponseCode = 1;

				response.Message = "Operation failed";

				return Ok(response);
			
			}
	
		}


		[HttpDelete]

		public ActionResult<DeleteClientResponse> Delete([FromBody] DeleteClientRequest request)
		{
			try
			{
				_repository.Delete(request.Id);
				var response = new DeleteClientResponse();
				response.Message = "Success";
				response.ResponseCode = 0;
				return Ok(response);
			}
			catch (Exception)
			{
				var response = new DeleteClientResponse();

				response.ResponseCode = 1;

				response.Message = "Operation failed";

				return Ok(response);

			}
		
		}

		[HttpGet]

		public ActionResult<GetClientResponse> Get([FromBody] GetClientRequest request)
		{
			try
			{
				var client = _repository.GetById(request.Id);
				var response = new GetClientResponse();
				response.Message = "Success";
				response.Client = client;
				response.ResponseCode = 0;
				return Ok(response);
			}
			catch (Exception)
			{
				var response = new GetClientResponse();
				response.Message = "Operation failed";
				response.Client = null;
				response.ResponseCode = 0;
				return Ok(response);
			}	
		}

		[HttpGet]

		public ActionResult<GetAllClientsResponse> GetAll([FromBody] GetAllClientsRequest request)
		{
			try
			{
				var clients = _repository.GetAll();
				var response = new GetAllClientsResponse();
				response.Clients = clients;
				response.Message = "Success";
				response.ResponseCode = 0;
				return Ok(response);
			}
			catch (Exception)
			{
				var response = new GetAllClientsResponse();
				response.Clients = null;
				response.Message = "Success";
				response.ResponseCode = 1;
				return Ok(response);
			}
		}

		[HttpPost]

		public ActionResult<UpdateClientResponse> Update([FromBody] UpdateClientRequest request)
		{
			try
			{
				 _repository.Update(request.Client);
				var response = new UpdateClientResponse();
				response.Message = "Success";
				response.ResponseCode = 0;
				return Ok(response);
			}
			catch (Exception)
			{
				var response = new UpdateClientResponse();
				response.Message = "Operation failed";
				response.ResponseCode = 1;
				return Ok(response);
			}
			
		}
	}
}
