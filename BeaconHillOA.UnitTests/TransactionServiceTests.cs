using BeaconHillOA.Core.Contracts.Repositories;
using BeaconHillOA.Core.Entities;
using BeaconHillOA.Infrastructure.Services;
using Moq;

namespace BeaconHillOA.UnitTests;

public class TransactionServiceTests
{
    private TransactionService _transactionService;
    private Mock<ITransactionRepository> _transactionRepositoryMock;
    [SetUp]
    public void Setup()
    {
        _transactionRepositoryMock = new Mock<ITransactionRepository>();
        _transactionService = new TransactionService(_transactionRepositoryMock.Object);
    }

    [Test]
    public void GetAllTransactions_ReturnsTransactionsFromRepository()
    {
        // Arrange
        var transactions = new List<Transaction>
        {
            new Transaction { Amount = 10, CustomerId = 1, TransactionDate = DateTime.Today },
            new Transaction { Amount = 20, CustomerId = 2, TransactionDate = DateTime.Today }
        };
        _transactionRepositoryMock.Setup(repo => repo.GetAll()).Returns(transactions);

        // Act
        var result = _transactionService.GetAllTransactions();

        // Assert
        Assert.That(result.Count(), Is.EqualTo(2));
        Assert.That(result.FirstOrDefault().Amount, Is.EqualTo(10));
        Assert.That(result.FirstOrDefault().CustomerId, Is.EqualTo(1));
        Assert.That(result.FirstOrDefault().TransactionDate, Is.EqualTo(DateTime.Today));
        Assert.That(result.LastOrDefault().Amount, Is.EqualTo(20));
        Assert.That(result.LastOrDefault().CustomerId, Is.EqualTo(2));
        Assert.That(result.LastOrDefault().TransactionDate, Is.EqualTo(DateTime.Today));
    }

    [Test]
    public void GetRewardsByCustomerPerMonth_ReturnsCorrectRewards()
    {
        // Arrange
        var transactions = new List<Transaction>
        {
            new Transaction { Amount = 100, CustomerId = 1, TransactionDate = DateTime.Today.AddMonths(-2) },
            new Transaction { Amount = 200, CustomerId = 1, TransactionDate = DateTime.Today.AddMonths(-1) },
            new Transaction { Amount = 50, CustomerId = 1, TransactionDate = DateTime.Today },
            new Transaction { Amount = 50, CustomerId = 2, TransactionDate = DateTime.Today }
        };
        _transactionRepositoryMock.Setup(repo => repo.GetAll()).Returns(transactions);

        // Act
        var result = _transactionService.GetRewardsByCustomerPerMonth(1, 1);

        // Assert
        Assert.That(result, Is.EqualTo(250));
    }


    [Test]
    public void GetTotalRewardsByCustomerInThreeMonths_ReturnsCorrectRewards()
    {
        // Arrange
        var transactions = new List<Transaction>
        {
            new Transaction { Amount = 100, CustomerId = 1, TransactionDate = DateTime.Today.AddMonths(-3) },
            new Transaction { Amount = 200, CustomerId = 1, TransactionDate = DateTime.Today.AddMonths(-2) },
            new Transaction { Amount = 50, CustomerId = 1, TransactionDate = DateTime.Today.AddMonths(-1) },
            new Transaction { Amount = 50, CustomerId = 2, TransactionDate = DateTime.Today }
        };
        _transactionRepositoryMock.Setup(repo => repo.GetAll()).Returns(transactions);

        // Act
        var result = _transactionService.GetTotalRewardsByCustomerInThreeMonths(1);

        // Assert
        Assert.That(result, Is.EqualTo(300));
    }
}