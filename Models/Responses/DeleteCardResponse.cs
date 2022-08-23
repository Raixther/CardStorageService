namespace CardStorageService.Models.Responses
{
	public class DeleteCardResponse : IOperationResult
	{
		public int ResponseCode { get; set; }
		public string Message { get ; set; }
	}
}
