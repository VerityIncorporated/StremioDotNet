using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stream = StremioDotNet.Structs.Stream.Stream;
using Structs_Stream = StremioDotNet.Structs.Stream.Stream;

namespace StremioDotNet.Results
{
    public class StreamsResult(params Structs_Stream[] streams) : StatusCodeResult(200)
    {
        [NonAction]
        public static StreamsResult Streams(params Structs_Stream[] streams)
            => new(streams);
        
        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            await response.WriteAsJsonAsync(new { streams });
        }
    }
}