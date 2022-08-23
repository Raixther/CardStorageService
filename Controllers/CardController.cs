
using System;

using CardStorageService.Data;
using CardStorageService.Models.Requests;
using CardStorageService.Models.Responses;
using CardStorageService.Services.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardStorageService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CardController : ControllerBase
	{

		private readonly ICardRepository _repository;
		

		public CardController(ICardRepository repository)
		{
			_repository = repository;
		}
		
		[HttpPost]

		public ActionResult<CreateCardResponse> Create(CreateCardRequest request)
		{
			try
			{
				var CardNo = _repository.Create(new Card
				{
					ClientId = request.ClientId,
					CVV2 = request.CVV2,
					Name = request.Name,
					ExpDate = request.ExpDate
				}
			);
				var response = new CreateCardResponse();
				response.CardNo = CardNo;
				response.Message = "Success";
				response.ResponseCode = 0;
				return Ok(response);
			}

			catch (Exception)
			{
				var response = new CreateCardResponse();
				response.CardNo = null;
				response.Message = "Operation failed";
				response.ResponseCode = 1;
				return Ok(response);
			}
		}


		[HttpDelete]

		public ActionResult<DeleteCardResponse> Delete(DeleteCardRequest request)
		{
			try
			{
				_repository.Delete(request.Id);
				var response = new DeleteCardResponse();
				response.Message = "Success";
				response.ResponseCode = 0;
				return Ok(response);
			}
			catch (Exception)
			{
				var response = new DeleteCardResponse();
				response.Message = "Operation failed";
				response.ResponseCode = 1;
				return Ok(response);
			}
		}
		[HttpGet]

		public ActionResult<GetCardResponse> Get(GetCardRequest request)
		{
			try
			{
				var card = _repository.GetById(request.Id);
				var response = new GetCardResponse();
				response.Card = card;
				response.Message = "Success";
				response.ResponseCode = 0;
				return Ok(response);
			}
			catch (Exception)
			{

				var response = new GetCardResponse();
				response.Card = null;
				response.Message = "Operation Failed";
				response.ResponseCode = 1;
				return Ok(response);
			}
		}

		[HttpGet]

		public ActionResult<GetAllCardsResponse> GetAll(GetAllCardsRequest request)
		{
			try
			{
				var cards = _repository.GetAll();
				var response = new GetAllCardsResponse();
				response.Cards = cards;
				response.Message = "Success";
				response.ResponseCode = 0;
				return Ok(response);
			}
			catch (Exception)
			{

				var response = new GetAllCardsResponse();
				response.Cards = null;
				response.Message = "Operation Failed";
				response.ResponseCode = 1;
				return Ok(response);
			}
		}

	}
}
