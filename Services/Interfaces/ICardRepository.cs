using CardStorageService.Data;

using System.Collections.Generic;

namespace CardStorageService.Services.Interfaces
{
	public interface ICardRepository : IReposiotory<Card, string>
	{
		IList<Card> GetByClientId(int id);
	}
}
