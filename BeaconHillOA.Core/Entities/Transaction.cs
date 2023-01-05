namespace BeaconHillOA.Core.Entities;

public class Transaction
{
    public int TransactionId { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public int CustomerId { get; set; }
    
    //Navigation property
    public Customer Customer { get; set; }
}