using Microsoft.AspNetCore.Mvc;
using PFM_project.Models;

namespace PFM_project;

[ApiController]
[Route("transactions")]
public class TransactionsController : ControllerBase
{

    private readonly ILogger<TransactionsController> _logger;

    public TransactionsController(ILogger<TransactionsController> logger)
    {
        _logger = logger;
    }

    //[HttpGet(Name = "GetTransactions")]
    //public  Task<IActionResult>  GetTransactions()
    //{
    //    return Ok();
    //}
}