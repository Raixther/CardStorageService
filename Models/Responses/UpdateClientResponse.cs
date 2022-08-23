namespace CardStorageService.Models.Responses
{
	public class UpdateClientResponse : IOperationResult
	{
		public int ResponseCode { get; set; }
		public string Message { get; set; }
	}
}
