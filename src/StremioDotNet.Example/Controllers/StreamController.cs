using Microsoft.AspNetCore.Mvc;
using StremioDotNet.Attributes;
using StremioDotNet.Builders;
using static StremioDotNet.Results.StreamsResult;

namespace StremioDotNet.Example.Controllers;

[ApiController]
public class StreamController : ControllerBase
{
    [StreamHandler("movie")]
    public IActionResult MovieHandler(string id)
    {
        dynamic? metadata = HttpContext.Items[id];
        
        if (metadata is null)
        {
            return Streams();
        }

        var streamBuilder = new StreamBuilder().SetName($"{metadata.meta.name}").SetDescription("Stream Description").SetUrl("http://distribution.bbb3d.renderfarming.net/video/mp4/bbb_sunflower_1080p_30fps_normal.mp4").Build();

        return Streams(streamBuilder);
    }
    
    [StreamHandler("series", true)]
    public IActionResult SeriesHandler(string id)
    {
        var metadata = HttpContext.Items[id];
        return Ok(metadata);
    }
}