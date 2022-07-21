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
    [Consumes("application/csv")]
    public async Task<IActionResult> CreateProduct([FromForm] IFormFile file)
    {       

        var result = new List<string>();
        var reader= new StreamReader(file.OpenReadStream());
        string line="";
        while((line=reader.ReadLine())!=null)
        {
            result.Add(line);
        }
        int i=0;
        foreach(string elem in result)
        {
            i+=1;
            if(i==1)
            {
                continue;
            }
            CreateTransactionsCommand command=new CreateTransactionsCommand();
            string[] lista=elem.Split(",");
            command.id=lista[0];
            command.beneficiaryname=lista[1];
            command.date=DateOnly.Parse(lista[2]);
            command.Directions=Directions.d;
            command.amount=Int32.Parse(lista[4]);
            command.description=lista[5];
            command.currency=lista[6];
            command.mcc=MccCodeEnum.NUMBER_4814;
            command.TransactionKind=TransactionKind.dep;
            var result1 = await _transactionsService.CreateTransactions(command);
            return Ok(result1);

        }
        return Ok();
    }
}