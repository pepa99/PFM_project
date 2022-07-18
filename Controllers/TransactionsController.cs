using Microsoft.AspNetCore.Mvc;
using PFM_project.Command;
using PFM_project.Models;
using PFM_project.Services;

namespace PFM_project;

[ApiController]
[Route("transactions")]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionsService _transactionsService;

    private readonly ILogger<TransactionsController> _logger;

    public TransactionsController(ITransactionsService transactionsService, ILogger<TransactionsController> logger)
    {
        _transactionsService=transactionsService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactions([FromQuery] int? page, [FromQuery] int? pageSize, [FromQuery] string sortBy, [FromQuery] SortOrder sortOrder)
    {
            page = page ?? 1;
            pageSize = pageSize ?? 10;
            _logger.LogInformation("Returning {page}. page of products", page);
            var result = await _transactionsService.GetProducts(page.Value, pageSize.Value, sortBy, sortOrder);
            return Ok(result);
    }
            [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateTransactionsCommand command)
        {
            var result = await _transactionsService.CreateTransactions(command);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
}