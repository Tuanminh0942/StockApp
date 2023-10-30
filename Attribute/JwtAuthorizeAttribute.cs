using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Filters;

namespace StockAppApi.Attribute
{
    public class JwtAuthorizeAttribute:TypeFilterAttribute
    {
        public JwtAuthorizeAttribute() : base(typeof(JwtAuthorizeFilter))
        {
        }
    }
}
