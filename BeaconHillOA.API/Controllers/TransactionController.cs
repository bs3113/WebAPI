using BeaconHillOA.Core.Contracts.Services;
using BeaconHillOA.Core.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace BeaconHillOA.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TransactionResponseModel>> GetAllTransactions()
    {
        var transactions = _transactionService.GetAllTransactions();
        return Ok(transactions);
    }

    [HttpGet]
    [Route("{customerId:int}")]
    public ActionResult<decimal> GetRewardsByCustomerInThreeMonths(int customerId)
    {
        var rewards = _transactionService.GetTotalRewardsByCustomerInThreeMonths(customerId);
        return Ok(rewards);
    }

    [HttpGet]
    [Route("{customerId:int}/{monthsFromNow:int}")]
    public ActionResult<decimal> GetRewardsByCustomerPerMonth(int customerId, int monthsFromNow)
    {
        var rewards = _transactionService.GetRewardsByCustomerPerMonth(customerId, monthsFromNow);
        return Ok(rewards);
    }

}