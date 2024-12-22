using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StremioDotNet.Structs;

namespace StremioDotNet.Results
{
    public class CatalogResult(params Meta[] metas) : StatusCodeResult(200)
    {
        [NonAction]
        public static CatalogResult Catalog(params Meta[] metas)
            => new(metas);
        
        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            await response.WriteAsJsonAsync(new { metas });
        }
    }
}