using System.Collections.Generic;

namespace CardStorageService.Services.Interfaces
{
	public interface IReposiotory<T, TId>
	{
		IList<T> GetAll();
		T GetById(TId id);

		TId Create(T data);

		int Update(T data);

		int Delete(TId id);

	}
}
