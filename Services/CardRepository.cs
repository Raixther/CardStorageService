using CardStorageService.Data;
using CardStorageService.Services.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;

namespace CardStorageService.Services
{
	public class CardRepository : ICardRepository
	{
		private readonly CardStorageServiceDbContext _dbContext;
	

		public CardRepository(CardStorageServiceDbContext dbContext)
		{
			_dbContext = dbContext;	
		}

		public string Create(Card data)
		{
			var client = _dbContext.Clients.FirstOrDefault(client => client.ClientId == data.ClientId);

			if (client==null)
				throw new Exception("Client not found");

			_dbContext.Add(data);

			_dbContext.SaveChanges();

			return data.CardNo;
		}

		public int Delete(string id)
		{
			var card = _dbContext.Cards.FirstOrDefault(card => card.CardNo == id);

			if (card == null)
			{
				return 0;
				throw new Exception("Card not found");
			}

			_dbContext.Remove(card);

			return 1;
		}

		public IList<Card> GetAll()
		{

			return _dbContext.Cards.ToList();			
		}

		public IList<Card> GetByClientId(int id)
		{
			return _dbContext.Cards.Where(card=>card.ClientId==id).ToList();
		}

		public Card GetById(string id)
		{
			return _dbContext.Find<Card>(id);
		}

		public int Update(Card data)
		{
			var client = _dbContext.Clients.FirstOrDefault(client => client.ClientId == data.ClientId);

			if (client==null)
				throw new Exception("Client not found");

			_dbContext.Update(data);

			return 0;// заглушка
		}
	}
}
