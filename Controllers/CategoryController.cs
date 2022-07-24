using Microsoft.AspNetCore.Mvc;
using PFM_project.Commands;
using PFM_project.Services;

namespace PFM_project.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController:ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ICategoryService service, ILogger<CategoryController> logger)
        {
            _categoryService=service;
            _logger=logger;
        }
        [HttpPost("import")]
        [Consumes("text/csv")]
        public async Task<IActionResult> CreateCategory()
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
            CategoryCsv categoryCsv=new CategoryCsv();
            string[] lista=elem.Split(",");
            try{
            categoryCsv.code=lista[0];
            categoryCsv.name=lista[2];
            categoryCsv.parent_code=lista[1];
            await _categoryService.Create(categoryCsv);

            }
            catch(Exception e)
            {

            }
        }
        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetCategories([FromQuery] string parent_id)
    {
        return Ok(await _categoryService.GetCategories(parent_id));
    }
}
}