using CardStorageService.Data;
using CardStorageService.Services.Interfaces;

using Castle.Core.Logging;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;

namespace CardStorageService.Services
{
	public class ClientRepository : IClientRepository//написать методы
	{

		private readonly CardStorageServiceDbContext _dbContext;

		public ClientRepository(CardStorageServiceDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public int Create(Client data)
		{
			_dbContext.Add(data);

			_dbContext.SaveChanges();

			return data.ClientId;
		}

		public int Delete(int id)
		{
			var client = _dbContext.Clients.Find(id);

			if (client==null)
			{
				return 0;
				throw new Exception("Client not found");			
			}

			_dbContext.Remove(client);
			_dbContext.SaveChanges();

			return 1;
		}
		public IList<Client> GetAll()
		{
			return _dbContext.Clients.ToList();
		}

		public Client GetById(int id)
		{
			return _dbContext.Find<Client>(id);
		}

		public int Update(Client data)
		{
			_dbContext.Update(data);
			_dbContext.SaveChanges();
			return data.ClientId;
		}
	}
}
