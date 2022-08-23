namespace CardStorageService.Models.Responses
{
	public class CreateCardResponse : IOperationResult
	{
		public string? CardNo{ get; set; }
		public int ResponseCode {get; set; }
		public string Message { get; set; }
	}
}
