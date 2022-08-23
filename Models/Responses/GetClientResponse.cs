using CardStorageService.Data;

namespace CardStorageService.Models.Responses
{
	public class GetClientResponse : IOperationResult
	{
		public Client? Client { get; set; }
		public int ResponseCode { get; set ; }
		public string Message { get ; set; }
	}
}
