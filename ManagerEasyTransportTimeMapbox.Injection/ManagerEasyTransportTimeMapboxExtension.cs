using ManagerEasyTransportTimeMapbox.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasyTransportTimeMapbox.Injection
{
    public static class ManagerEasyTransportTimeMapboxExtension
    {
        /// <summary>
        /// Agrega la injeccion de dependencias
        /// </summary>
        /// <param name="services"></param>
        public static void AddManagerEasyTransportTimeMapbox(this IServiceCollection services,string mapBoxToken)
        {
            services.AddHttpClient();
            services.AddScoped<IManagerEasyTransportTimeMapboxProvider>(x =>
                                new ManagerEasyTransportTimeMapboxProvider(mapBoxToken, x.GetService<IHttpClientFactory>().CreateClient()));
        }
    }
}
