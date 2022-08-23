using System.Collections.Generic;

using CardStorageService.Data;

namespace CardStorageService.Models.Responses
{
	public class GetAllClientsResponse : IOperationResult
	{
		public IList<Client> Clients{ get; set; }
		public int ResponseCode { get; set; }
		public string Message { get; set; }
	}
}
