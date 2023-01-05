using BeaconHillOA.Core.Models.ResponseModels;

namespace BeaconHillOA.Core.Contracts.Services;

public interface ITransactionService
{
    IEnumerable<TransactionResponseModel> GetAllTransactions();
    decimal GetRewardsByCustomerPerMonth(int customerId, int monthsFromNow);
    decimal GetTotalRewardsByCustomerInThreeMonths(int customerId);
}