using BeaconHillOA.Core.Contracts.Repositories;
using BeaconHillOA.Core.Contracts.Services;
using BeaconHillOA.Core.Models.ResponseModels;
using BeaconHillOA.Infrastructure.Helpers;

namespace BeaconHillOA.Infrastructure.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }
    public IEnumerable<TransactionResponseModel> GetAllTransactions()
    {
        var transactions = _transactionRepository.GetAll();
        var response = transactions.Select(t => t.ToTransactionResponseModel());
        return response;
    }

    public decimal GetRewardsByCustomerPerMonth(int customerId, int monthsFromNow)
    {
        var transactions = _transactionRepository.GetAll();
        var transactionsByCustomer = transactions.Where(t => t.CustomerId == customerId && 
                                                             ((DateTime.Today.Year - t.TransactionDate.Year) * 12 + 
                                                                 DateTime.Today.Month - t.TransactionDate.Month == monthsFromNow));
        decimal rewards = 0;
        foreach (var transaction in transactionsByCustomer)
        {
            rewards += GetRewards(transaction.Amount);
        }

        return rewards;
    }

    public decimal GetTotalRewardsByCustomerInThreeMonths(int customerId)
    {
        var transactions = _transactionRepository.GetAll();
        var transactionsByCustomer = transactions.Where(t => t.CustomerId == customerId && 
                                                             ((DateTime.Today.Year - t.TransactionDate.Year) * 12 + 
                                                                 DateTime.Today.Month - t.TransactionDate.Month <= 3));
        decimal rewards = 0;
        foreach (var transaction in transactionsByCustomer)
        {
            rewards += GetRewards(transaction.Amount);
        }

        return rewards;
    }
    
    private decimal GetRewards(decimal amount)
    {
        decimal rewards = 0;
        if (amount > 100)
        {
            rewards += 2 * (amount - 100);
        }

        if (amount > 50)
        {
            rewards += Math.Min(amount, 100) - 50;
        }

        return rewards;
    }
}