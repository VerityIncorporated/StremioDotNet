using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stream = StremioDotNet.Structs.Stream.Stream;

namespace StremioDotNet.Results
{
    /// <summary>
    /// Represents the result of a stream request in the Stremio addon.
    /// This class is used to return a collection of stream objects as part of the response
    /// to a stream API request.
    /// </summary>
    public class StreamsResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StreamsResult"/> class.
        /// </summary>
        /// <param name="streams">The array of streams to be included in the response.</param>
        private StreamsResult(params Stream[] streams) : base(200)
        {
            StreamArray = streams;
        }

        /// <summary>
        /// Gets the array of stream objects to be included in the response.
        /// </summary>
        private Stream[] StreamArray { get; }

        /// <summary>
        /// A factory method to create a new <see cref="StreamsResult"/> instance with the provided streams.
        /// This method is marked as non-action to prevent it from being treated as an API endpoint action.
        /// </summary>
        /// <param name="streams">The streams to be included in the response.</param>
        /// <returns>A new instance of <see cref="StreamsResult"/> containing the provided streams.</returns>
        [NonAction]
        public static StreamsResult Streams(params Stream[] streams)
            => new(streams);

        /// <summary>
        /// Asynchronously executes the result, writing the streams to the HTTP response as JSON.
        /// This method is invoked by the ASP.NET Core framework when returning the result from an action.
        /// </summary>
        /// <param name="context">The context for the current action execution.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            await response.WriteAsJsonAsync(new { streams = StreamArray });
        }
    }
}
