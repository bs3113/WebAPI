using BeaconHillOA.Core.Entities;
using BeaconHillOA.Core.Models.ResponseModels;

namespace BeaconHillOA.Infrastructure.Helpers;

public static class ModelWrapper
{
    public static TransactionResponseModel ToTransactionResponseModel(this Transaction transaction)
    {
        return new TransactionResponseModel
        {
            TransactionId = transaction.TransactionId,
            TransactionDate = transaction.TransactionDate,
            CustomerId = transaction.CustomerId,
            Amount = transaction.Amount
        };
    }
}