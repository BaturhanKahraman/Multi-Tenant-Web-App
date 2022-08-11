using Microsoft.EntityFrameworkCore;
using MultiTenantWebApp.Data;
namespace MultiTenantWebApp.Middlewares;

public class SelectConnectionString
{
    private readonly RequestDelegate _next;

    public SelectConnectionString(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext,ProductDatabaseContext appDbCtx)
    {
        if(httpContext.Request.Headers.Any(h => h.Key.ToLower() == "admin"))
            await _next.Invoke(httpContext);
        else
        {
            string customerName = httpContext.Request.Headers.SingleOrDefault(h => h.Key == "MyCustomerName").Value;
            if(string.IsNullOrEmpty(customerName))
                throw new Exception("Customer not found!");
            await using var mainCtx = new MainContext();
            var customer = mainCtx.Customers.SingleOrDefault(c => customerName.ToLower() == c.Name.ToLower());
            //you can verify customer
            appDbCtx.Database.SetConnectionString(customer?.ConnectionString);
            await _next.Invoke(httpContext);
        }
    }
}