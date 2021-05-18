using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task InsertParamatersPaginationInHeaders<T>(this HttpContext httpContext, IQueryable<T> queryable)
        {
            if(httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            //this counts the amount of rcors in the table regardless of their type -- OOP reusable code
            double count = await queryable.CountAsync();
            //this adds that count to the response headers that will be sent back to the view
            httpContext.Response.Headers.Add("totalAmountOfRecords", count.ToString());

        }
    }
}
