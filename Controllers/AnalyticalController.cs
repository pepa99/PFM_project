using Microsoft.AspNetCore.Mvc;
using PFM_project.Database.Entities;
using PFM_project.Services;

namespace PFM_project.Commands
{
    [ApiController]
    [Route("spending-analytics")]
    public class AnalyticalController:ControllerBase
    {
        private readonly ITransactionsService _transactionsService;
        private readonly ILogger<AnalyticalController> _logger;
        public AnalyticalController(ILogger<AnalyticalController> logger,ITransactionsService transactionService)
        {
            _transactionsService=transactionService;
            _logger=logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAnalytics([FromQuery] string catcode,[FromQuery] DateTime start,[FromQuery] DateTime end,[FromQuery] Directions direction)
        {
            var result= await _transactionsService.GetTransactionsByCat(catcode,start,end,direction);
            return Ok(result);
             
        }
    }
}