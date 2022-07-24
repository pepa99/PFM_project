using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using PFM_project.Commands;
using PFM_project.Database.Entities;
using PFM_project.Models;
using PFM_project.Services;

namespace PFM_project.Controllers;

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
              error.error="Start date format is wrong.";
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
                error.error="End date format is wrong";
                lista.Add(error);
            } 
            TransactionKind kind=new TransactionKind();
            try
            {
            kind=Enum.Parse<TransactionKind>(kind_str);
            }
            catch
            {
                Error error=new Error();
                error.tag="kind";
                error.error="Transaction kind is not supported.";
                lista.Add(error);
            }
            if(lista.Count>0)
            {
                return BadRequest(lista);
            }
            return Ok(await _transactionsService.GetProducts(kind,start,end, page.Value, pageSize.Value, sortBy, sortOrder));
        }
            
    


    [HttpPost("import")]
    [Consumes("text/csv")]
    public async Task<IActionResult> CreateProduct()
    {  
        StreamReader reader=  new StreamReader(Request.Body);
        List<string> result= new List<string>();
        int i=0;
        string line="";
        List<String> greske=new List<string>();
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
            var errors=false;
            CreateTransactionsCommand command=new CreateTransactionsCommand();
            string[] lista=elem.Split(",");
            try{
            command.id=lista[0];
            command.beneficiaryname=lista[1];
            command.date=DateTime.Parse(lista[2]);
            command.Directions=Enum.Parse<Directions>(lista[3]);
            var k=4;
            try
            {
            command.amount=Double.Parse(lista[4]);
            }
            catch(Exception e)
            {
                k+=1;
                var n=lista[5].Length;
                StringBuilder sb=new StringBuilder();
                sb.Append(lista[4][1]);
                for(var iter=0;iter<n-1;iter++)
                {
                    sb.Append(lista[5][iter]);
                }
                command.amount=Double.Parse(sb.ToString());
            }
            k++;
            command.description=lista[k];
            k++;
            command.currency=lista[k];
            k++;
            try
            {
            command.mcc=Enum.Parse<MccCodeEnum>(lista[k]);
            }
            catch(Exception e)
            {
                //command.mcc=null;
            }
            k++;
            command.TransactionKind=Enum.Parse<TransactionKind>(lista[k]);
            //return Ok(command.TransactionKind);
            
             var result1 = await _transactionsService.CreateTransactions(command);
            }
            catch(Exception e)
            {
                errors=true;
                greske.Add(elem);
            }
           
        }
        return Ok(greske);
    }
    [HttpPost("{id}/categorize")]
    //[Consumes("application/json")]
    public async Task<IActionResult> Categorize([FromRoute] string id,[FromQuery] string catcode)
    {
        var  transaction_entity= await _transactionsService.GetTransaction(id);
        if(transaction_entity==null)
        {
            return BadRequest(id);
        }
        //HttpClient client=new HttpClient();
        //string URL="https://localhost:7087/categories";
        //client.BaseAddress=new Uri(URL);
        //string parameters="?parent_id="+catcode.ToString();
         //client.DefaultRequestHeaders.Accept.Add(
         //   new MediaTypeWithQualityHeaderValue("application/json"));
        //var response = client.GetAsync(parameters).Result; 
        transaction_entity.catcode=catcode;
        try
        {
            await _transactionsService.Update(transaction_entity);
            return Ok(transaction_entity);
        }
        catch(Exception e)
        {
            return BadRequest("There is no category with given catcode.");
        }
        
    }
}