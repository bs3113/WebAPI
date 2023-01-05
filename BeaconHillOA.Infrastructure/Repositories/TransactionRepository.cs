using BeaconHillOA.Core.Contracts.Repositories;
using BeaconHillOA.Core.Entities;
using System.Linq;

namespace BeaconHillOA.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    //use hard coded data instead of db connection
    public Transaction Create(Transaction entity)
    {
        throw new NotImplementedException();
    }

    public Transaction Update(Transaction entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetAll()
    {
        var transactions = new List<Transaction>();
        transactions.Add(new Transaction()
        {
            TransactionId = 1, 
            TransactionDate = new DateTime(2022, 12, 01),
            CustomerId = 1,
            Amount = 120
        });
        transactions.Add(new Transaction()
        {
            TransactionId = 1,
            TransactionDate = new DateTime(2019, 12, 01),
            CustomerId = 1,
            Amount = 120
        });
        transactions.Add(new Transaction()
        {
            TransactionId = 1,
            TransactionDate = new DateTime(2023, 01, 01),
            CustomerId = 1,
            Amount = 120
        });
        return transactions;
    }
    
    public  Transaction GetById(int id)
    {
        throw new NotImplementedException();
    }

}