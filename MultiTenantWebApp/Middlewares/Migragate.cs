using Microsoft.EntityFrameworkCore;
using MultiTenantWebApp.Data;

namespace MultiTenantWebApp.Middlewares
{
    public class Migragate
    {
        private readonly RequestDelegate _next;
        private readonly bool _needMigrate;
        public Migragate(RequestDelegate next, bool needMigrate)
        {
            _next = next;
            _needMigrate = needMigrate;
        }
        public async Task Invoke(HttpContext httpContext,ProductDatabaseContext appDbCtx)
        {
            if(_needMigrate)
                await appDbCtx.Database.MigrateAsync();
            await _next.Invoke(httpContext);
        }
    }
}
