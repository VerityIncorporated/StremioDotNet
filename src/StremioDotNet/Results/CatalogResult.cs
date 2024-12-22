using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StremioDotNet.Structs.Meta;

namespace StremioDotNet.Results
{
    /// <summary>
    /// Represents the result of a catalog request in the Stremio addon.
    /// This class is used to return a catalog of metadata (such as movies or series)
    /// as part of the response to a catalog API request.
    /// </summary>
    public class CatalogResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogResult"/> class.
        /// </summary>
        /// <param name="metas">The metadata of the catalog items to be included in the response.</param>
        private CatalogResult(params Meta[] metas) : base(200)
        {
            Metas = metas;
        }

        /// <summary>
        /// Gets the metadata of the catalog items.
        /// </summary>
        private Meta[] Metas { get; }

        /// <summary>
        /// A factory method to create a new <see cref="CatalogResult"/> instance with the provided metadata.
        /// This method is marked as non-action to prevent it from being treated as an API endpoint action.
        /// </summary>
        /// <param name="metas">The metadata of the catalog items to be included in the response.</param>
        /// <returns>A new instance of <see cref="CatalogResult"/> containing the provided metadata.</returns>
        [NonAction]
        public static CatalogResult Catalog(params Meta[] metas)
            => new(metas);

        /// <summary>
        /// Asynchronously executes the result, writing the metadata to the HTTP response as JSON.
        /// This method is invoked by the ASP.NET Core framework when returning the result from an action.
        /// </summary>
        /// <param name="context">The context for the current action execution.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            await response.WriteAsJsonAsync(new { metas = Metas });
        }
    }
}
