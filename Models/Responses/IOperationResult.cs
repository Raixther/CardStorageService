namespace CardStorageService.Models.Responses
{
	public interface IOperationResult
	{
		public int ResponseCode{ get; set; }

		public string? Message { get; set; }
	}
}
