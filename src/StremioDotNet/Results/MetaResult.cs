using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StremioDotNet.Structs;

namespace StremioDotNet.Results
{
    public class MetaResult(Meta meta) : StatusCodeResult(200)
    {
        [NonAction]
        public static MetaResult Meta(Meta meta)
            => new(meta);
        
        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            await response.WriteAsJsonAsync(new { meta });
        }
    }
}