using Microsoft.AspNetCore.Mvc;
using PFM_project.Command;
using PFM_project.Database.Entities;
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
    public async Task<IActionResult> GetTransactions([FromQuery] string kind_str,[FromQuery] string starts,[FromQuery] string ends, [FromQuery] int? page, [FromQuery] int? pageSize, [FromQuery] string sortBy, [FromQuery] SortOrder sortOrder)
    {
            page = page ?? 1;
            pageSize = pageSize ?? 10;
            _logger.LogInformation("Returning {page}. page of products", page);
            try
            {
            DateOnly start=DateOnly.Parse(starts);
            DateOnly end=DateOnly.Parse(ends);
            TransactionKind kind=Enum.Parse<TransactionKind>(kind_str);
            return Ok(await _transactionsService.GetProducts(kind,start,end, page.Value, pageSize.Value, sortBy, sortOrder));
            }
            catch (ArgumentException e)
            {
                return BadRequest();
            }
    }


    [HttpPost]
    [Consumes("text/csv")]
    public async Task<IActionResult> CreateProduct()
    {  
        StreamReader reader=  new StreamReader(Request.Body);
        List<string> result= new List<string>();
        int i=0;
        string line="";
        while ((line = await reader.ReadLineAsync()) != null)
                {
                    i+=1;
                    result.Add(line);
                }
        var j=0;   
        foreach(string elem in result)
        {
            j+=1;
            if(j<6)
            {
                continue;
            }
            CreateTransactionsCommand command=new CreateTransactionsCommand();
            string[] lista=elem.Split(",");
            try{
            command.id="1";
            command.beneficiaryname="nam1";
            command.date=DateOnly.Parse(lista[2]);
            command.Directions=Directions.d;
            command.amount=1.20;
            command.description="opis";
            command.currency="USD";
            command.mcc=MccCodeEnum.NUMBER_4814;
            command.TransactionKind=TransactionKind.dep;
             var result1 = await _transactionsService.CreateTransactions(command);
            }
            catch(Exception e)
            {
                
                return BadRequest();
            }
           
        }
        return Ok();
    }
}