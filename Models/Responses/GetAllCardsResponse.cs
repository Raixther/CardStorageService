using System.Collections.Generic;

using CardStorageService.Data;

namespace CardStorageService.Models.Responses
{
	public class GetAllCardsResponse : IOperationResult
	{
		public IList<Card> Cards { get; set; }
		public int ResponseCode { get; set; }
		public string Message { get ; set; }
	}
}
