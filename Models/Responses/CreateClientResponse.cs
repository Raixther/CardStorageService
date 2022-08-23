namespace CardStorageService.Models.Responses
{
	public class CreateClientResponse : IOperationResult
	{
		public int? ClientId { get; set; }
		public int ResponseCode { get; set;}
		public string Message { get; set ; }

	}
}
