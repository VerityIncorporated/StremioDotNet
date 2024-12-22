using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StremioDotNet.Structs.Meta;

namespace StremioDotNet.Results
{
    /// <summary>
    /// Represents the result of a metadata request in the Stremio addon.
    /// This class is used to return the metadata (such as information about a specific movie or series)
    /// as part of the response to a metadata API request.
    /// </summary>
    public class MetaResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetaResult"/> class.
        /// </summary>
        /// <param name="meta">The metadata of the requested item to be included in the response.</param>
        private MetaResult(Meta meta) : base(200)
        {
            Metas = meta;
        }

        /// <summary>
        /// Gets the metadata of the requested item.
        /// </summary>
        private Meta Metas { get; }

        /// <summary>
        /// A factory method to create a new <see cref="MetaResult"/> instance with the provided metadata.
        /// This method is marked as non-action to prevent it from being treated as an API endpoint action.
        /// </summary>
        /// <param name="meta">The metadata of the requested item to be included in the response.</param>
        /// <returns>A new instance of <see cref="MetaResult"/> containing the provided metadata.</returns>
        [NonAction]
        public static MetaResult Meta(Meta meta)
            => new(meta);

        /// <summary>
        /// Asynchronously executes the result, writing the metadata to the HTTP response as JSON.
        /// This method is invoked by the ASP.NET Core framework when returning the result from an action.
        /// </summary>
        /// <param name="context">The context for the current action execution.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            await response.WriteAsJsonAsync(new { meta = Metas });
        }
    }
}
