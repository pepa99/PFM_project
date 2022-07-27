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
        public async Task<IActionResult> GetAnalytics([FromQuery] string catcode,[FromQuery] string starts,[FromQuery] string ends,[FromQuery] Directions direction)
        {
            List<Error> lista=new List<Error>();
            DateTime start=new DateTime();
            DateTime end=new DateTime();
            try
            {
             start=DateTime.Parse(starts);
            }
            catch(Exception e)
            {
              Error error=new Error();
              error.tag="start";
              error.error=ErrorEnum.invalid_format;
              error.message="Start date format is wrong.";
              lista.Add(error);
            }
            try
            {
             end=DateTime.Parse(ends);
            }
            catch(Exception e)
            {
                Error error=new Error();
                error.tag="end";
                error.error=ErrorEnum.invalid_format;
                error.message="End date format is wrong";
                lista.Add(error);
            } 
            if(lista.Count()>0)
            {
                return BadRequest(lista);
            }
            var result= await _transactionsService.GetTransactionsByCat(catcode,start,end,direction);
            return Ok(result);
             
        }
    }
}