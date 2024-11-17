using Application.Common;
using Application.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Reflection;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //services.AddScoped<IRequestHandler<FileDownloadCommand<ReferrerResponseOutputViewModel>, Result<byte[]>>, FileDownloadCommandHandler<ReferrerResponseOutputViewModel>>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(configuration["ApiSettings:TisspUrl"]) });
            services.AddScoped<InvoiceService>();
            services.AddScoped<InquiryService>();

            return services;
        }
    }
}