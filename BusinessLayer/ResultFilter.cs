using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluCo.Bank.BusinessLayer
{
    public class ResultFilter : IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("Res",DateTime.Now.ToString()); 
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Req", DateTime.Now.ToString());
        }
    }
    /*public class FilterData
    {
        public FilterData(string reqOrRes, DateTime dateTime)
        {
            ReqOrRes = reqOrRes;
            DateTime = dateTime;
        }

        public string ReqOrRes { get; set; }
        public DateTime DateTime { get; set; }
    }*/
}
