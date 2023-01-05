namespace BeaconHillOA.Core.Models.ResponseModels;

public class TransactionResponseModel
{
    public int TransactionId { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public int CustomerId { get; set; }
}