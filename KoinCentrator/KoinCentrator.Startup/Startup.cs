using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using KoinCentrator.MarketData.Providers;
using KoinCentrator.MarketData.Providers.Cryptonator;
using KoinCentrator.MarketData.Providers.CryptoCompare;
using System.Reflection;
using KoinCentrator.MarketData.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using KoinCentrator.Tools.Web;
using KoinCentrator.MarketData.Providers.Coinigy;

namespace KoinCentrator.Startup
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "koincentrator", Version = "v1" });
            });

            services
                .AddMvc(o =>
                {
                    o.Conventions.Add(new CommaSeparatedQueryStringConvention());
                })
                .AddApplicationPart(Assembly.Load(new AssemblyName(typeof(QuotesController).Namespace))); // because TestServer bug when controller in other project;

            // DI of quote providers
            services.AddTransient<IQuoteProvider, CryptonatorQuoteProvider>();
            services.AddTransient<IQuoteProvider, CryptoCompareQuoteProvider>();
            services.AddTransient<IQuoteProvider, CoinigyQuoteProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "koincentrator V1");
            });

            app.UseMvc();
        }
    }
}
