using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForMoreMoney.Documents.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ForMoreMoney.Documents.Extensions
{
    public static class StartupDocuments
    {
        public static IServiceCollection SetupDocuments(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IDocumentsService), typeof(DocumentsTestService));

            return services;
        }
    }
}
