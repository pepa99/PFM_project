using Microsoft.AspNetCore.Mvc;
using PFM_project.Database.Entities;
using PFM_project.Models;
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
            if(starts==null)
            {
                starts="1/1/1900";
            }
            if(ends==null)
            {
                ends="1/1/2023";
            }
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
            if(catcode=="A"){
               var result1= await _transactionsService.GetTransactionsByCat("0",start,end,direction);
            return Ok(result1);
            }
            if(catcode=="B"){
               SpendingInCategory  resB=new SpendingInCategory();
               resB.catcode="B";
               for(int i=1;i<8;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resB.amount+=temp.amount;
                resB.count+=temp.count;
               }
            return Ok(resB);
            }
            if(catcode=="C"){
               SpendingInCategory  resC=new SpendingInCategory();
               resC.catcode="C";
               for(int i=9;i<15;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resC.amount+=temp.amount;
                resC.count+=temp.count;
               }
            return Ok(resC);
            }
            if(catcode=="D"){
               SpendingInCategory  resD=new SpendingInCategory();
               resD.catcode="D";
               for(int i=15;i<18;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resD.amount+=temp.amount;
                resD.count+=temp.count;
               }
            return Ok(resD);
            }
            if(catcode=="E"){
               SpendingInCategory  resE=new SpendingInCategory();
               resE.catcode="E";
               for(int i=20;i<25;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resE.amount+=temp.amount;
                resE.count+=temp.count;
               }
            return Ok(resE);
            }
            if(catcode=="F"){
               SpendingInCategory  resF=new SpendingInCategory();
               resF.catcode="F";
               for(int i=25;i<29;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resF.amount+=temp.amount;
                resF.count+=temp.count;
               }
            return Ok(resF);
            }
            if(catcode=="G"){
               SpendingInCategory  resG=new SpendingInCategory();
               resG.catcode="G";
               for(int i=33;i<34;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resG.amount+=temp.amount;
                resG.count+=temp.count;
               }
            return Ok(resG);
            }
            if(catcode=="U"){
               SpendingInCategory  resU=new SpendingInCategory();
               resU.catcode="U";
               for(int i=38;i<40;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resU.amount+=temp.amount;
                resU.count+=temp.count;
               }
            return Ok(resU);
            }
            if(catcode=="H"){
               SpendingInCategory  resH=new SpendingInCategory();
               resH.catcode="H";
               for(int i=41;i<43;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resH.amount+=temp.amount;
                resH.count+=temp.count;
               }
            return Ok(resH);
            }
            if(catcode=="I"){
               SpendingInCategory  resI=new SpendingInCategory();
               resI.catcode="I";
               for(int i=45;i<51;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resI.amount+=temp.amount;
                resI.count+=temp.count;
               }
            return Ok(resI);
            }
            if(catcode=="J"){
               SpendingInCategory  resJ=new SpendingInCategory();
               resJ.catcode="J";
               for(int i=53;i<59;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resJ.amount+=temp.amount;
                resJ.count+=temp.count;
               }
            return Ok(resJ);
            }
            if(catcode=="K"){
               SpendingInCategory  resK=new SpendingInCategory();
               resK.catcode="K";
               for(int i=59;i<65;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resK.amount+=temp.amount;
                resK.count+=temp.count;
               }
            return Ok(resK);
            }
            if(catcode=="L"){
               SpendingInCategory  resL=new SpendingInCategory();
               resL.catcode="L";
               for(int i=67;i<73;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resL.amount+=temp.amount;
                resL.count+=temp.count;
               }
            return Ok(resL);
            }
            if(catcode=="M"){
               SpendingInCategory  resM=new SpendingInCategory();
               resM.catcode="M";
               for(int i=74;i<78;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resM.amount+=temp.amount;
                resM.count+=temp.count;
               }
            return Ok(resM);
            }
            if(catcode=="N"){
               SpendingInCategory  resM=new SpendingInCategory();
               resM.catcode="N";
               for(int i=80;i<83;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resM.amount+=temp.amount;
                resM.count+=temp.count;
               }
            return Ok(resM);
            }
            if(catcode=="O"){
               SpendingInCategory  resM=new SpendingInCategory();
               resM.catcode="O";
               for(int i=83;i<87;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resM.amount+=temp.amount;
                resM.count+=temp.count;
               }
            return Ok(resM);
            }
            if(catcode=="P"){
               SpendingInCategory  resM=new SpendingInCategory();
               resM.catcode="P";
               for(int i=88;i<93;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resM.amount+=temp.amount;
                resM.count+=temp.count;
               }
            return Ok(resM);
            }
            if(catcode=="R"){
               SpendingInCategory  resM=new SpendingInCategory();
               resM.catcode="R";
               for(int i=96;i<99;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resM.amount+=temp.amount;
                resM.count+=temp.count;
               }
            return Ok(resM);
            }
            if(catcode=="S"){
               SpendingInCategory  resM=new SpendingInCategory();
               resM.catcode="S";
               for(int i=100;i<101;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resM.amount+=temp.amount;
                resM.count+=temp.count;
               }
            return Ok(resM);
            }
            if(catcode=="T"){
               SpendingInCategory  resM=new SpendingInCategory();
               resM.catcode="T";
               for(int i=103;i<107;i++){
                var temp=await _transactionsService.GetTransactionsByCat(i.ToString(),start,end,direction);
                resM.amount+=temp.amount;
                resM.count+=temp.count;
               }
            return Ok(resM);
            }
            var result= await _transactionsService.GetTransactionsByCat(catcode,start,end,direction);
            return Ok(result);
             
        }
    }
}