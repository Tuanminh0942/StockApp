using System.Runtime.CompilerServices;

namespace StockAppApi.Extensions
{
    public static class HttpContextExtension
    {
        public static int GetUserId(this HttpContext httpContext)
        {
            return httpContext.Items["UserId"] as int? ??
                throw new Exception("User Id not found in HttpContext.Items");
        }
    }
}
