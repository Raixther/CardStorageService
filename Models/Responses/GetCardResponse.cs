using CardStorageService.Data;

namespace CardStorageService.Models.Responses
{
	public class GetCardResponse : IOperationResult
	{
		public Card? Card{ get; set; }
		public int ResponseCode { get; set; }
		public string Message { get; set; }
	}
}
