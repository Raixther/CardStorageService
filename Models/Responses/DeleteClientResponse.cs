namespace CardStorageService.Models.Responses
{
	public class DeleteClientResponse : IOperationResult
	{
		public int ResponseCode { get; set; }
		public string Message { get; set; }
	}
}
